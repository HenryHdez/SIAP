//#region Definición de variables para municipio
//var raiz = '@(HttpContext.Current.Request.ApplicationPath)';
var codigoCapaActual = 99;
var estaciones, precipitacion;
var parcelas;
var highlight;
var coordinate, circle, circleFeature, circuloEstacion, circuloFuente;
extent = coordenadas;
var capa;
var exportPNGElement = document.getElementById('export-png');
var meses = ["ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic"];
var cultivo = cultivoNombre.substring(0, 3).toLocaleLowerCase();
var parcela = new Array(zonaIdV.length);
var pto_t = new Array(2);
for (i = 0; i < zonaIdV.length; i++) {
    pto_t[0] = parseFloat(zonLongV[i]);
    pto_t[1] = parseFloat(zonLatV[i]);
    var pto = ol.proj.transform(pto_t, "EPSG:4326", "EPSG:900913");
    parcela[i] = new ol.Feature({
        geometry: new ol.geom.Point(pto),
        name: cultivoV[i],
        id: zonaIdV[i],
    });
}
featureOverlay = new ol.layer.Vector({
    map: map,
    style: function (feature, resolution) {
        if (feature) {
            p = capa.get('title');
            l = feature.getId().split(".");
            l = l[0];
            if (l == "municipios") {
                var text = resolution < 5000 ? feature.get('name') : '';
                if (!highlightStyleCache[text]) {
                    highlightStyleCache[text] = [new ol.style.Style({
                        stroke: new ol.style.Stroke({
                            color: 'rgb(115,115,115)',
                            width: 5
                        }),
                        fill: new ol.style.Fill({
                            color: 'rgba(255,0,0,0.5)'
                        }),
                    })];
                }
            }
            if (p == "estaciones_spi") {
                for (j = 0; j < estacionesIDEAMV.length; j++) {
                    if (feature.get('codigo') == estacionesIDEAMV[j]) {
                        var radio = estacionesRadioV[j] * 1000 / view.getResolution();
                        if (estacionesSPIV[j] > 'sin dato' || estacionesSPIV[j] == 0) {
                            var color = 'rgba(130,130,130,0.5)';
                        } else {
                            if (parseFloat(estacionesSPIV[j]) < -1) {
                                var color = 'rgba(255,0,0,0.5)';
                            }
                            if (parseFloat(estacionesSPIV[j]) >= -1 && parseFloat(estacionesSPIV[j]) <= 1) {
                                var color = 'rgba(0,255,0,0.5)';
                            }
                            if (parseFloat(estacionesSPIV[j]) > 1) {
                                var color = 'rgba(0,0,255,0.5)';
                            }
                        }
                        var text = resolution < 5000 ? feature.get('name') : '';
                        if (!highlightStyleCache[text]) {
                            highlightStyleCache[text] = [new ol.style.Style({
                                image: new ol.style.Circle({
                                    radius: radio,
                                    fill: new ol.style.Fill({
                                        color: color
                                    }),
                                })
                            })];
                        }
                    }
                }
            }
            if (p == "estaciones_ppt") {
                for (j = 0; j < estacionesIDEAMV.length; j++) {
                    if (feature.get('codigo') == estacionesIDEAMV[j]) {
                        var radio = estacionesRadioV[j] * 1000 / view.getResolution();
                        if (estacionesPptV[j] > 'sin dato') {
                            var color = 'rgba(130,130,130,0.5)';
                        } else {
                            if (parseFloat(estacionesPptV[j]) == 1) {
                                var color = 'rgba(255,0,0,0.5)';
                            }
                            if (parseFloat(estacionesPptV[j]) == 3) {
                                var color = 'rgba(0,255,0,0.5)';
                            }
                            if (parseFloat(estacionesPptV[j]) == 2) {
                                var color = 'rgba(0,0,255,0.5)';
                            }
                            if (parseFloat(estacionesPptV[j]) == 0) {
                                var color = 'rgba(130,130,130,0.5)';
                            }
                        }
                        var text = resolution < 5000 ? feature.get('name') : '';
                        if (!highlightStyleCache[text]) {
                            highlightStyleCache[text] = [new ol.style.Style({
                                image: new ol.style.Circle({
                                    radius: radio,
                                    fill: new ol.style.Fill({
                                        color: color
                                    }),
                                })
                            })];
                        }
                    }
                }
            }
        }
        return highlightStyleCache[text];
    }
});
//#endregion

//#region Definición de capas que se pueden cargar desde GeoServer
//Creación de objeto de capa para municipio
arregloCapas.push({
    "nombre": "municipios",
    "url": "municipios",
    "filtro": "coddanemun='" + coddane + "'",
    "estilo": municipio_sty,
    "visible": true
});
//Creación de objeto de capa para anomalía NDVI
arregloCapas.push({
    "nombre": "anomalia_ndvi",
    "url": "anomalia_ndvi_" + coddane,
    "filtro": null,
    "estilo": anomalia_ndvi_sty,
    "visible": false,
    "categoria": 'anomalía',
    "convencion": convenciones
});
//Creación de objeto de capa para expansión
arregloCapas.push({
    "nombre": "expansion",
    "url": "expansion_" + coddane,
    "filtro": null,
    "estilo": expansion_contraccion_sty,
    "visible": false,
    "categoria": 'expansion',
    "convencion": convenciones
});
//Creación de objeto de capa para contracción
arregloCapas.push({
    "nombre": "contraccion",
    "url": "contraccion_" + coddane,
    "filtro": null,
    "estilo": expansion_contraccion_sty,
    "visible": false,
    "categoria": 'contraccion',
    "convencion": convenciones
});
//Creación de objeto de capa para aptitud normal
arregloCapas.push({
    "nombre": "aptitud_agroclimatica_normal",
    "url": "aptitud_agroclimatica_normal_" + coddane,
    "filtro": null,
    "estilo": aptitud_sty_normal,
    "visible": false,
    "categoria": 'categoría',
    "convencion": convenciones
});
//Creación de objeto de capa para aptitud exceso
arregloCapas.push({
    "nombre": "aptitud_agroclimatica_exceso",
    "url": "aptitud_agroclimatica_exceso_" + coddane,
    "filtro": null,
    "estilo": aptitud_sty_exceso,
    "visible": false,
    "categoria": 'categoría',
    "convencion": convenciones
});
//Creación de objeto de capa para aptitud déficit
arregloCapas.push({
    "nombre": "aptitud_agroclimatica_deficit",
    "url": "aptitud_agroclimatica_deficit_" + coddane,
    "filtro": null,
    "estilo": aptitud_sty_deficit,
    "visible": false,
    "categoria": 'categoría',
    "convencion": convenciones
});
//Creación de objeto de capa para drenaje
arregloCapas.push({
    "nombre": "drenaje",
    "url": "drenaje_" + coddane,
    "filtro": null,
    "estilo": drenaje_sty,
    "visible": false,
    "categoria": 'nombre',
    "convencion": convenciones
});
//Creación de objeto de capa para superficie de agua
arregloCapas.push({
    "nombre": "superficie",
    "url": "superficie_agua_" + coddane,
    "filtro": null,
    "estilo": superficie_agua_sty,
    "visible": false,
    "categoria": 'nombre',
    "convencion": convenciones
});
//Creación de objeto de capa para cobertura vegetal
arregloCapas.push({
    "nombre": "cobertura",
    "url": "cobertura_vegetal_" + coddane,
    "filtro": null,
    "estilo": cobertura_vegetal_sty,
    "visible": false,
    "categoria": 'nombre',
    "convencion": convenciones
});
//Creación de objeto de capa para las parcelas
var parcela = new Array(zonaIdV.length);
var pto_t = new Array(2);
for (i = 0; i < zonaIdV.length; i++) {
    pto_t[0] = parseFloat(zonLongV[i]);
    pto_t[1] = parseFloat(zonLatV[i]);
    var pto = ol.proj.transform(pto_t, "EPSG:4326", "EPSG:900913");
    parcela[i] = new ol.Feature({
        geometry: new ol.geom.Point(pto),
        name: cultivoV[i],
        id: zonaIdV[i],
    });
}
parcelas = new ol.layer.Vector({
    title: "parcelas",
    source: new ol.source.Vector({
        features: parcela
    }),
    visible: false,
    style: parcelas_sty
});
//map.addLayer(parcelas);
//Creación de objeto de capa para las estaciones SPI
arregloCapas.push({
    "nombre": "estaciones_spi",
    "url": "estaciones_climatologicas",
    "filtro": null,
    "estilo": estaciones_municipio_sty,
    "visible": false,
    "categoria": 'altitud',
    "convencion": null
});
//Creación de objeto de capa para las estaciones PPT
arregloCapas.push({
    "nombre": "estaciones_ppt",
    "url": "estaciones_climatologicas",
    "filtro": null,
    "estilo": estaciones_municipio_sty,
    "visible": false,
    "categoria": 'altitud',
    "convencion": null
});
//Creación de objeto de capa para escenarios
if (noEscenarios != "true") {
    for (var i = 0; i < numerosMeses.length; i++) {
        arregloCapas.push({
            "nombre": "nor_" + cultivo + "_" + meses[numerosMeses[i] - 1],
            "url": "nor_" + cultivo + "_" + meses[numerosMeses[i] - 1] + "_" + coddane,
            "filtro": null,
            "estilo": escenarios_tom_sty,
            "visible": false,
            "categoria": 'categoría',
            "convencion": escenarios
        });
        arregloCapas.push({
            "nombre": "hum_" + cultivo + "_" + meses[numerosMeses[i] - 1],
            "url": "hum_" + cultivo + "_" + meses[numerosMeses[i] - 1] + "_" + coddane,
            "filtro": null,
            "estilo": escenarios_tom_sty,
            "visible": false,
            "categoria": 'categoría',
            "convencion": escenarios
        });
        arregloCapas.push({
            "nombre": "sec_" + cultivo + "_" + meses[numerosMeses[i] - 1],
            "url": "sec_" + cultivo + "_" + meses[numerosMeses[i] - 1] + "_" + coddane,
            "filtro": null,
            "estilo": escenarios_tom_sty,
            "visible": false,
            "categoria": 'categoría',
            "convencion": escenarios
        });
    }
}
//Creación de objeto de capa para aptitud
arregloCapas.push({
    "nombre": "aptitud_agroclimatica_deficit",
    "url": "aptitud_agroclimatica_deficit_" + coddane,
    "filtro": null,
    "estilo": aptitud_sty_deficit,
    "visible": false,
    "categoria": 'categoría',
    "convencion": convenciones
});

//#endregion

//#region Elección del mapa base
if (localStorage.getItem("base") == null) {
    localStorage.setItem("base", 1);
}
//#endregion

//#region Objetos y acciones sobre el mapa
map.addLayer(featureOverlay);
parcelas.setZIndex(100);
map.addLayer(parcelas);
map.getView().fit(extent, map.getSize());
map.on('click', function (evt) {
    mostrarGloboLeyenda(evt.pixel);
});
//#endregion

//#region Control de descarga de mapas
if ('download' in exportPNGElement) {
    exportPNGElement.addEventListener('click', function (e) {
        map.once('postcompose', function (event) {
            var canvas = event.context.canvas;
            exportPNGElement.href = canvas.toDataURL('image/png');
        });
        map.renderSync();
    }, false);
} else {
    var info = document.getElementById('no-download');
    info.style.display = '';
}
//#endregion

//#region Funciones
function removeA(arr) {
    var what, a = arguments, L = a.length, ax;
    while (L > 1 && arr.length) {
        what = a[--L];
        while ((ax = arr.indexOf(what)) != -1) {
            arr.splice(ax, 1);
        }
    }
    return arr;
}

function seleccionCultivo(indicadorPrediccion) {
    container.style.display = 'none';
    closer.blur();
    if (codigoCapaActual !== 99) {
        apagarCapa(codigoCapaActual);
    }
    $('#heading3').removeClass('none');
    $('#heading5').removeClass('none');
    parcelas.setVisible(true);
    $("#globo-seleccion-cultivo").toggleClass('none');
}

function apagarCapas(capa) {
    j = capas.getLength() - 1;
    for (k = 1; k <= j; k++) {
        if (k != capa) {
            capas.item(k).setVisible(false);
        }
    }
}

function toggleGlobo1() {
    $("#globo-seleccion-cultivo").addClass('none');
    $("#globo-seleccion-municipio").addClass('none');
    var anchoGlobo = 180;
    var anchoMenu = $("#barra-departamento").width();
    var posicionMenu = $("#barra-departamento").position().left;
    var posicion = (anchoMenu / 2) - (anchoGlobo / 2);
    $("#globo-seleccion-departamento").css('left', posicion + "px");
    $("#globo-seleccion-departamento").toggleClass('none');
};


function toggleGloboM() {
    $("#globo-seleccion-cultivo").addClass('none');
    $("#globo-seleccion-departamento").addClass('none');
    var anchoGlobo = 180;
    var anchoMenu = $("#barra-municipio").width();
    var posicionMenu = $("#barra-municipio").position().left;
    var posicion = (anchoMenu / 2) - (anchoGlobo / 2);
    $("#globo-seleccion-municipio").css('left', posicion + "px");
    $("#globo-seleccion-municipio").toggleClass('none');
};

function toggleGlobo(indicador) {
    if (indicador = 1) {
        $("#globo-seleccion-municipio").addClass('none');
        $("#globo-seleccion-departamento").addClass('none');
        $('#cont').addClass('none');
        $("#globo-seleccion-cultivo").toggleClass('none');
    }
};

function cargarMapasIniciales() {
    cargando = 0;
    finalizados = 0;
    errores = 0;
    if (!primeraPublicacion) {
        publicarCapa(0);
        esperarCapa(0);
        primeraPublicacion = true;
    };
    $('#load').hide();
};

function cambiarCapa(nombreCapa) {
    parcelas.setVisible(false);
    if (circuloEstacion) {
        circuloEstacion.setVisible(false);
    }
    ocultarGlobo();
    htmlConvenciones = '';
    var codigoCapa = consultarCodigoCapa(nombreCapa);
    //Se reserva el código 100 para cuando se presiona un botón que no cambia capa
    if (codigoCapa != 100) {
        //Con el código 99 se conoce si no se ha cargado alguna capa 
        if (codigoCapaActual === 99) {
            $('#load').show();
            publicarCapa(codigoCapa);
            //esperarCapa(codigoCapa);
            codigoCapaActual = codigoCapa;
            primeraCapaPublicada = true;
        }
            //Pasa por aquí cuando no es la primera capa que se carga
        else {
            //Si se presionó el botón de la capa actualmente encendida
            if (codigoCapa === codigoCapaActual) {
                cambiarVisibilidadCapa(codigoCapa);
            }
                //Si se presiono el botón de una capa diferente a la actualmente encendida
            else {
                apagarCapa(codigoCapaActual);
                if (arregloCapas[codigoCapa].publicada) {
                    encenderCapa(codigoCapa);
                }
                else {
                    $('#load').show();
                    publicarCapa(codigoCapa);
                    //esperarCapa(codigoCapa);
                }
                codigoCapaActual = codigoCapa;
            }
        }
    }
        //Si se presiona un botón que no cambia a una capa es necesario apagar la actualmente encendida
    else if (codigoCapaActual !== 99) {
        apagarCapa(codigoCapaActual);
    }
    cambiarLeyenda(nombreCapa);
};

function consultarCodigoCapa(nombreCapa) {
    for (var i = 0; i < arregloCapas.length; i++) {
        if (arregloCapas[i].nombre === nombreCapa) {
            return i;
        }
    }
    return 100;
};

//function publicarCapa(codigo) {
//    var url = caracteresEspeciales(rutaServidor + "ows?service=WFS&version=1.0.0&request=GetFeature&typeName=Corpoica:" + arregloCapas[codigo].url + "&outputFormat=application/json");
//    if (arregloCapas[codigo].filtro != null) {
//        url = url + caracteresEspeciales("&cql_filter=(" + arregloCapas[codigo].filtro + ")");
//    }
//    arregloCapas[codigo].fuente = new ol.source.Vector({
//        projection: 'EPSG:900913',
//        url: ol.ProxyHost + '?url=' + url,
//        format: new ol.format.GeoJSON()
//    });
//    arregloCapas[codigo].capa = new ol.layer.Vector({
//        source: arregloCapas[codigo].fuente,
//        style: arregloCapas[codigo].estilo,
//        title: arregloCapas[codigo].nombre,
//        visible: true
//    });
//    arregloCapas[codigo].publicada = true;
//    map.addLayer(arregloCapas[codigo].capa);
//};

function esperarCapa(codigo) {
    var listenerKey = arregloCapas[codigo].fuente.on('change', function (e) {
        if (arregloCapas[codigo].fuente.getState() === 'ready') {
            $('#load').hide();
            ol.Observable.unByKey(listenerKey);
            if (codigo === 0) {
                console.log("Extent: "+ arregloCapas[codigo].fuente.getExtent());
                ajustarMapa(arregloCapas[codigo].fuente.getExtent());
            }
        }
    });
};

function cambiarLeyenda(capa) {
    $('#cont').removeClass('none');
    $('#municipio').addClass('none');
    var cuadros = ['#estaciones_municipio', '#estaciones-spi', '#estaciones-ppt', '#anomalia', '#inundacion', '#inundacion-expansion', '#inundacion-contraccion', '#aptitud', '#aptitud-normal', '#aptitud-exceso',
        '#aptitud-deficit', '#escenarios', '#drenaje', '#superficie', '#cobertura','#practicas'];
    var iconos = ['#icono-estaciones', '#icono-anomalia', '#icono-inundacion', '#icono-aptitud', '#icono-escenarios', '#icono-drenaje', '#icono-superficie', '#icono-cobertura','#icono-practica'];
    var cuadrosVisibles = [];
    var iconosVisibles = [];
    var filtro = '';
    switch (capa) {
        case 1:
            $('#municipio').removeClass('none');
            break;
        case 'estaciones':
            $('#boton-estaciones-spi').removeClass('active');
            $('#boton-estaciones-ppt').removeClass('active');
            cuadrosVisibles.push('#estaciones_municipio');
            iconosVisibles.push('#icono-estaciones');
            break;
        case 'estaciones_spi':
            //**$('.caja-convenciones').html(convencionesSPI);
            $('#estaciones_municipio').addClass('none');
            $('#icono-estaciones').removeClass('icono-sombra');
            cuadrosVisibles.push('#estaciones_municipio');
            cuadrosVisibles.push('#estaciones-spi');
            iconosVisibles.push('#icono-estaciones');
            //$('#boton-estaciones-spi').toggleClass('active');
            //$('#boton-estaciones-ppt').removeClass('active');
            break;
        case 'estaciones_ppt':
            //**$('.caja-convenciones').html(convencionesPPT);
            $('#estaciones_municipio').addClass('none');
            $('#icono-estaciones').removeClass('icono-sombra');
            cuadrosVisibles.push('#estaciones_municipio');
            cuadrosVisibles.push('#estaciones-ppt');
            iconosVisibles.push('#icono-estaciones');
            //$('#boton-estaciones-spi').removeClass('active');
            //$('#boton-estaciones-ppt').toggleClass('active');
            break;
        case 'anomalia_ndvi':
            $('.caja-convenciones').html(convencionesNDVI);
            cuadrosVisibles.push('#anomalia');
            iconosVisibles.push('#icono-anomalia');
            break;
        case 'inundacion':
            cuadrosVisibles.push('#inundacion');
            iconosVisibles.push('#icono-inundacion');
            break;
        case 'expansion':
            $('.caja-convenciones').html(convencionesExpansionContraccion);
            $('#inundacion').addClass('none');
            $('#icono-inundacion').removeClass('icono-sombra');
            cuadrosVisibles.push('#inundacion');
            cuadrosVisibles.push('#inundacion-expansion');
            iconosVisibles.push('#icono-inundacion');
            $('#boton-inundacion-expansion').toggleClass('active');
            $('#boton-inundacion-contraccion').removeClass('active');
            break;
        case 'contraccion':
            $('.caja-convenciones').html(convencionesExpansionContraccion);
            $('#inundacion').addClass('none');
            $('#icono-inundacion').removeClass('icono-sombra');
            cuadrosVisibles.push('#inundacion');
            cuadrosVisibles.push('#inundacion-contraccion');
            iconosVisibles.push('#icono-inundacion');
            $('#boton-inundacion-expansion').removeClass('active');
            $('#boton-inundacion-contraccion').toggleClass('active');
            break;
        case 'aptitud':
            cuadrosVisibles.push('#aptitud');
            iconosVisibles.push('#icono-aptitud');
            $('#boton-aptitud-normal').removeClass('active');
            $('#boton-aptitud-exceso').removeClass('active');
            $('#boton-aptitud-deficit').removeClass('active');
            break;
        case 'aptitud_agroclimatica_normal':
            $('.caja-convenciones').html(convencionesAptitudNormal);
            $('#aptitud').addClass('none');
            $('#icono-aptitud').removeClass('icono-sombra');
            cuadrosVisibles.push('#aptitud');
            cuadrosVisibles.push('#aptitud-normal');
            iconosVisibles.push('#icono-aptitud');
            break;
        case 'aptitud_agroclimatica_exceso':
            $('.caja-convenciones').html(convencionesAptitudExceso);
            $('#aptitud').addClass('none');
            $('#icono-aptitud').removeClass('icono-sombra');
            cuadrosVisibles.push('#aptitud');
            cuadrosVisibles.push('#aptitud-exceso');
            iconosVisibles.push('#icono-aptitud');
            break;
        case 'aptitud_agroclimatica_deficit':
            $('.caja-convenciones').html(convencionesAptitudDeficit);
            $('#aptitud').addClass('none');
            $('#icono-aptitud').removeClass('icono-sombra');
            cuadrosVisibles.push('#aptitud');
            cuadrosVisibles.push('#aptitud-deficit');
            iconosVisibles.push('#icono-aptitud');
            break;
        case 'escenarios':
            cuadrosVisibles.push('#escenarios');
            iconosVisibles.push('#icono-escenarios');
            break;
        case 'drenaje':
            $('.caja-convenciones').html(convencionesDrenaje);
            cuadrosVisibles.push('#drenaje');
            iconosVisibles.push('#icono-drenaje');
            break;
        case 'superficie':
            $('.caja-convenciones').html(convencionesSuperficie);
            cuadrosVisibles.push('#superficie');
            iconosVisibles.push('#icono-superficie');
            break;
        case 'cobertura':
            $('.caja-convenciones').html(convencionesCobertura);
            cuadrosVisibles.push('#cobertura');
            iconosVisibles.push('#icono-cobertura');
            break;
        case 'practicas':
            cuadrosVisibles.push('#practicas');
            iconosVisibles.push('#icono-practica');
            break;
        case capa:
            $('#escenarios').addClass('none');
            $('#icono-escenarios').removeClass('icono-sombra');
            cuadrosVisibles.push('#escenarios');
            iconosVisibles.push('#icono-escenarios');
            break;
        default:
            break;
    }
    for (var cv = 0; cv < iconosVisibles.length; cv++) {
        $(iconosVisibles[cv]).toggleClass('icono-sombra');
        if ($(iconosVisibles[cv]).hasClass('icono-sombra')) {
            $('.contenedor-caja-flecha').addClass('none');
            $('#cont').removeClass('none');
        }
        else {
            $('.contenedor-caja-flecha').removeClass('none');
            $('#cont').addClass('none');
        }
        iconos = removeA(iconos, iconosVisibles[cv]);
        $("#globo-seleccion-departamento").addClass("none");
        $("#globo-seleccion-municipio").addClass("none");
        $("#globo-seleccion-cultivo").addClass("none");
    };
    for (var cv = 0; cv < cuadrosVisibles.length; cv++) {
        $(cuadrosVisibles[cv]).toggleClass('none');
        cuadros = removeA(cuadros, cuadrosVisibles[cv]);
    };
    for (var c = 0; c < cuadros.length; c++) {
        $(cuadros[c]).addClass('none');
        $(iconos[c]).removeClass('icono-sombra');
    };
};

function mostrarGloboLeyenda(pixel) {
    if (circuloEstacion) {
        circuloEstacion.setVisible(false);
    }
    var highlight;
    var capa;
    container.style.display = 'none';
    closer.blur();
    feature = map.forEachFeatureAtPixel(pixel, function (feature, vectorLayer) {
        capa = vectorLayer;
        return feature;
    });
    if (feature) {
        l = capa.get('title');
        console.log("l: " + l);
        if (feature.get('codigo')) {
            for (j = 0; j < estacionesIDEAMV.length; j++) {
                if (feature.get('codigo') == estacionesIDEAMV[j]) {
                    var radio = estacionesRadioV[j] * 10000 / view.getResolution();
                    if (estacionesSPIV[j] > 'sin dato' || estacionesSPIV[j] == 0) {
                        var color = 'rgba(130,130,130,0.5)';
                    } else {
                        if (parseFloat(estacionesSPIV[j]) < -1) {
                            var color = 'rgba(255,0,0,0.5)';
                        }
                        if (parseFloat(estacionesSPIV[j]) >= -1 && parseFloat(estacionesSPIV[j]) <= 1) {
                            var color = 'rgba(0,255,0,0.5)';
                        }
                        if (parseFloat(estacionesSPIV[j]) > 1) {
                            var color = 'rgba(0,0,255,0.5)';
                        }
                    }

                    var style = new ol.style.Style({
                        fill: new ol.style.Fill({
                            //color: 'rgba(255, 100, 50, 0.3)'
                            color: color
                        }),
                        stroke: new ol.style.Stroke({
                            width: 2,
                            //color: 'rgba(255, 100, 50, 0.8)'
                            color: color
                        }),
                        image: new ol.style.Circle({
                            fill: new ol.style.Fill({
                                //color: 'rgba(55, 200, 150, 0.5)'
                                color: color
                            }),
                            stroke: new ol.style.Stroke({
                                width: 1,
                                //color: 'rgba(55, 200, 150, 0.8)'
                                color: color
                            }),
                            radius: radio
                        }),
                    });
                    coordinate = map.getCoordinateFromPixel(pixel);
                    circle = new ol.geom.Circle(coordinate, 5000);
                    circleFeature = new ol.Feature(circle);

                    circuloFuente = new ol.source.Vector({
                        projection: 'EPSG:4326',
                        features: [circleFeature]
                    });
                    circuloEstacion = new ol.layer.Vector({
                        source: circuloFuente,
                        style: style
                    });
                    map.addLayer(circuloEstacion);
                    break;
                }
            }
        }
        if (l == "parcelas") {
            if (indicadorPrediccion == 1) {
                window.open("../Alerta/Presentacion?ZonaId=" + feature.get('id'), "_parent");
            }
            else {
                $("#modal-no-prediccion").modal('show');
            }
        }
        for (var i = 1, len = arregloCapas.length; i < len; i++) {
            if (l == arregloCapas[i].nombre) {
                clicMapa(arregloCapas[i].convencion, feature, arregloCapas[i].categoria, pixel);
            }
        }
    }
};
//#endregion