//#region Definición de variables para departamento
var exportPNGElement = document.getElementById('export-png');
var codigoCapaActual = 99;
featureOverlay = new ol.layer.Vector({
    source: new ol.source.Vector(),
    map: map,
    style: function (feature, resolution) {
        if (feature) {
            l = feature.getId().split(".");
            l = l[0];
            if (l == "municipios") {
                var text = resolution < 5000 ? feature.get('name') : '';
                if (!highlightStyleCache[text]) {
                    highlightStyleCache[text] = [new ol.style.Style({
                        stroke: new ol.style.Stroke({
                            color: 'rgb(115,115,115)',
                            width: 1.5
                        }),
                        fill: new ol.style.Fill({
                            color: 'rgba(255,0,0,0.5)'
                        }),
                    })];
                }
            }
        }
        return highlightStyleCache[text];
    }
});
extent = coordenadas;
//#endregion

//#region Definición de capas que se pueden cargar desde GeoServer
//Creación de objeto de capa para departamento
arregloCapas.push({
    "nombre": "departamentos",
    "url": "departamentos",
    "filtro": "cod_depart='" + dpto + "'",
    "estilo": null,
    "visible": true,
    "categoria": null
});
//Creación de objeto de capa para municipio
arregloCapas.push({
    "nombre": "municipios",
    "url": "municipios",
    "filtro": "cod_depart='" + dpto + "'",
    "estilo": municipios_sty,
    "visible": true,
    "categoria": null
});
//Creación de objeto de capa para subzonas
arregloCapas.push({
    "nombre": "subzonas_hidrograficas",
    "url": "subzonas_hidrograficas_" + dpto,
    "filtro": null,
    "estilo": subzonas_sty,
    "visible": false,
    "directa": true,
    "categoria": 'nomszh',
    "convencion": lsubzonas

});
//Creación de objeto de capa para estaciones
arregloCapas.push({
    "nombre": "estaciones_climatologicas",
    "url": "estaciones_climatologicas",
    "filtro": "departamen='" + dptonom.replace('&#241;', 'Ñ').replace('&#243; ', 'O').replace('&#243;', 'O').toUpperCase() + "'",
    "estilo": estaciones_sty,
    "visible": false,
    "categoria": 'altitud',
    "convencion": null
});
//Creación de objeto de capa para precipitación media multianual
arregloCapas.push({
    "nombre": "pm_multianual",
    "url": "pm_multianual_" + dpto,
    "filtro": null,
    "estilo": precipitacion_sty,
    "visible": false,
    "categoria": 'rango_mm',
    "convencion": lcaracterizaciones
});
//Creación de objeto de capa para conglomerados
arregloCapas.push({
    "nombre": "conglomerados_precipitacion",
    "url": "conglomerados_precipitacion_" + dpto,
    "filtro": null,
    "estilo": conglomerados_sty,
    "visible": false,
    "categoria": 'conglomera',
    "convencion": lconglomerados
});
//Creación de objeto de capa para tempratura mínima media multianual
arregloCapas.push({
    "nombre": "tmin_media_multianual",
    "url": "tmin_media_multianual_" + dpto,
    "filtro": null,
    "estilo": tmin_media_sty,
    "visible": false,
    "categoria": 'rango_c',
    "convencion": lcaracterizaciones
});
//Creación de objeto de capa para tempratura media multianual
arregloCapas.push({
    "nombre": "tmedia_multianual",
    "url": "tmedia_multianual_" + dpto,
    "filtro": null,
    "estilo": tmedia_sty,
    "visible": false,
    "categoria": 'rango_c',
    "convencion": lcaracterizaciones
});
//Creación de objeto de capa para tempratura máxima media multianual
arregloCapas.push({
    "nombre": "tmax_media_multianual",
    "url": "tmax_media_multianual_" + dpto,
    "filtro": null,
    "estilo": tmax_media_sty,
    "visible": false,
    "categoria": 'rango_c',
    "convencion": lcaracterizaciones
});
//Creación de objeto de capa para brillo solar
arregloCapas.push({
    "nombre": "brillo_solar_multianual",
    "url": "brillo_solar_multianual_" + dpto,
    "filtro": null,
    "estilo": brillo_solar_sty,
    "visible": false,
    "categoria": 'rango_h',
    "convencion": lcaracterizaciones
});
//Creación de objeto de capa para humedad relativa multianual
arregloCapas.push({
    "nombre": "hum_relativa_multianual",
    "url": "hum_relativa_multianual_" + dpto,
    "filtro": null,
    "estilo": humedad_sty,
    "visible": false,
    "categoria": 'rango',
    "convencion": lcaracterizaciones
});
//Creación de objeto de capa para evapotranspiracion
arregloCapas.push({
    "nombre": "evotranspiracion",
    "url": "evotranspiracion_" + dpto,
    "filtro": null,
    "estilo": evotranspiracion_sty,
    "visible": false,
    "categoria": 'rango_mm',
    "convencion": lcaracterizaciones
});
//Creación de objeto de capa para anomalía precipitación niño
arregloCapas.push({
    "nombre": "anomalia_nino",
    "url": "anomalia_nino_" + dpto,
    "filtro": null,
    "estilo": anomalia_p_nino_sty,
    "visible": false,
    "categoria": 'anomalía',
    "convencion": lNinoNina
});
//Creación de objeto de capa para anomalía precipitación niña
arregloCapas.push({
    "nombre": "anomalia_nina",
    "url": "anomalia_nina_" + dpto,
    "filtro": null,
    "estilo": anomalia_p_nina_sty,
    "visible": false,
    "categoria": 'anomalía',
    "convencion": lNinoNina
});
//Creación de objeto de capa para anomalía temperatura mínima niño
arregloCapas.push({
    "nombre": "anomalia_tmin_nino",
    "url": "anomalia_tmin_nino_" + dpto,
    "filtro": null,
    "estilo": anomalia_t_sty_min_nino,
    "visible": false,
    "categoria": 'anom_c',
    "convencion": lNinoNina
});
//Creación de objeto de capa para anomalía temperatura mínima niña
arregloCapas.push({
    "nombre": "anomalia_tmin_nina",
    "url": "anomalia_tmin_nina_" + dpto,
    "filtro": null,
    "estilo": anomalia_t_sty_min_nina,
    "visible": false,
    "categoria": 'anom_c',
    "convencion": lNinoNina
});
//Creación de objeto de capa para anomalía temperatura máxima niño
arregloCapas.push({
    "nombre": "anomalia_tmax_nino",
    "url": "anomalia_tmax_nino_" + dpto,
    "filtro": null,
    "estilo": anomalia_t_sty_max_nino,
    "visible": false,
    "categoria": 'anom_c',
    "convencion": lNinoNina
});
//Creación de objeto de capa para anomalía temperatura máxima niña
arregloCapas.push({
    "nombre": "anomalia_tmax_nina",
    "url": "anomalia_tmax_nina_" + dpto,
    "filtro": null,
    "estilo": anomalia_t_sty_max_nina,
    "visible": false,
    "categoria": 'anom_c',
    "convencion": lNinoNina
});
//Creación de objeto de capa para exceso hídrico
arregloCapas.push({
    "nombre": "exceso",
    "url": "exceso_" + dpto,
    "filtro": null,
    "estilo": exceso_sty,
    "visible": false,
    "categoria": 'frecuencia',
    "convencion": lAmenazas
});
//Creación de objeto de capa para déficit hídrico
arregloCapas.push({
    "nombre": "deficit",
    "url": "deficit_" + dpto,
    "filtro": null,
    "estilo": deficit_sty,
    "visible": false,
    "categoria": 'frecuencia',
    "convencion": lAmenazas
});
//Creación de objeto de capa para susceptibilidad a inundaciones
arregloCapas.push({
    "nombre": "inundacion_susceptibilidad",
    "url": "inundacion_susceptibilidad_" + dpto,
    "filtro": null,
    "estilo": inundacion_susceptibilidad_sty,
    "visible": false,
    "categoria": 'suscinunda',
    "convencion": lAmenazas
});
//Creación de objeto de capa para inundación 2010 2011 IGAC
arregloCapas.push({
    "nombre": "inundacion_2010_2011_igac",
    "url": "inundacion_2010_2011_igac_" + dpto,
    "filtro": null,
    "estilo": inundacion_2010_2011_sty,
    "visible": false,
    "categoria": 'inundatota',
    "convencion": lAmenazas
});
//#endregion

//#region Elección del mapa base
if (localStorage.getItem("base") == null) {
    localStorage.setItem("base", 1);
}
//#endregion

//#region Objetos y acciones sobre el mapa
map.addLayer(featureOverlay);
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

function apagarCapas(capa) {
    j = capas.getLength() - 2;
    for (k = 3; k <= j; k++) {
        if (k != capa) {
            capas.item(k).setVisible(false);
        }
    }
}

function cambiarCapa(nombreCapa) {
    console.log("por aqui capa");
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
            console.log("código de capa: " + codigoCapa);
            primeraCapaPublicada = true;
        }
        //Pasa por aquí cuando no es la primera capa que se carga
        else {
            //Si se presionó el botón de la capa actualmente encendida
            if (codigoCapa === codigoCapaActual) {
                cambiarVisibilidadCapa(codigoCapa);
                capaSeleccionada = false;
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
                capaSeleccionada = true;
            }
        }
    }
    //Si se presiona un botón que no cambia a una capa es necesario apagar la actualmente encendida
    else if (codigoCapaActual !== 99) {
        apagarCapa(codigoCapaActual);
        capaSeleccionada = false;
    }
    else {
        console.log("aqui?");
        capaSeleccionada = true;
    }
    console.log("capaSeleccionada: " + capaSeleccionada);
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

//function esperarCapa(codigo) {
//    arregloCapas[codigo].fuente.on('tileloadstart', function (event) {
//        //if (cargando === 0) {
//        //    $('#load').show();
//        //    texto.setVisible(false);
//        //}
//        //cargando++;
//        console.log("por aqui");
//    });
//    console.log("Esperando capa:"+arregloCapas[codigo].nombre);
//    var listenerKey = arregloCapas[codigo].fuente.on('change', function (e) {
//        if (arregloCapas[codigo].fuente.getState() == 'ready') {
//            capasFinalizadas = true;
//            $('#load').hide();
//            ol.Observable.unByKey(listenerKey);
//        }
//        else {
//            console.log("Estado de la capa: " + arregloCapas[codigo].fuente.getState());
//        }
//    });
//};

function cambiarLeyenda(capa) {
    console.log("por aqui leyenda");
    $('#cont').removeClass('none');
    $('#departamento').addClass('none');
    var cuadros = ['#subzonas', '#estaciones', '#pre-multianual', '#conglomerados', '#temp-multianual',
        '#temperatura-minima', '#temperatura-media', '#temperatura-maxima', '#brillo', '#evapotranspiracion',
        '#humedad', '#anomalia-p', '#anomalia-p-nina', '#anomalia-p-nino', '#anomalia-t', '#anomalia-t-min-nino',
        '#anomalia-t-min-nina', '#anomalia-t-max-nino', '#anomalia-t-max-nina', '#frecuencia', '#frecuencia-exceso',
        '#frecuencia-deficit', '#susceptibilidad', '#susceptibilidad-inundacion', '#susceptibilidad-igac'];
    var iconos = ['#icono-subzonas', '#icono-estaciones', '#icono-pre-multianual', '#icono-conglomerados',
        '#icono-temp-multianual', '#icono-brillo', '#icono-evapotranspiracion', '#icono-humedad',
        '#icono-anomalia-p', '#icono-anomalia-t', '#icono-frecuencia', '#icono-susceptibilidad'];
    var cuadrosVisibles = [];
    var iconosVisibles = [];
    var filtro = '';
    switch (capa) {
        case 2:
            $('#departamento').removeClass('none');
            break;
        case 'subzonas_hidrograficas':
            $('.caja-convenciones').html(convencionesSubzonas);
            cuadrosVisibles.push('#subzonas');
            iconosVisibles.push('#icono-subzonas');
            break;
        case 'estaciones_climatologicas':
            $('.caja-convenciones').html(convencionesEstaciones);
            cuadrosVisibles.push('#estaciones');
            iconosVisibles.push('#icono-estaciones');
            break;
        case 'pm_multianual':
            $('.caja-convenciones').html(convencionesPrecipitacion);
            cuadrosVisibles.push('#pre-multianual');
            iconosVisibles.push('#icono-pre-multianual');
            break;
        case 'conglomerados_precipitacion':
            $('.caja-convenciones').html(convencionesConglomerados);
            cuadrosVisibles.push('#conglomerados');
            iconosVisibles.push('#icono-conglomerados');
            break;
        case 'temp-multianual':
            cuadrosVisibles.push('#temp-multianual');
            iconosVisibles.push('#icono-temp-multianual');
            $('#boton-temp-minima').removeClass('active');
            $('#boton-temp-maxima').removeClass('active');
            $('#boton-temp-media').removeClass('active');
            break;
        case 'tmin_media_multianual':
            $('.caja-convenciones').html(convencionesTempMin);
            $('#temp-multianual').addClass('none');
            $('#icono-temp-multianual').removeClass('icono-sombra');
            cuadrosVisibles.push('#temp-multianual');
            cuadrosVisibles.push('#temperatura-minima');
            iconosVisibles.push('#icono-temp-multianual');
            break;
        case 'tmedia_multianual':
            $('.caja-convenciones').html(convencionesTempMed);
            $('#temp-multianual').addClass('none');
            $('#icono-temp-multianual').removeClass('icono-sombra');
            cuadrosVisibles.push('#temp-multianual');
            cuadrosVisibles.push('#temperatura-media');
            iconosVisibles.push('#icono-temp-multianual');
            break;
        case 'tmax_media_multianual':
            $('.caja-convenciones').html(convencionesTempMax);
            $('#temp-multianual').addClass('none');
            $('#icono-temp-multianual').removeClass('icono-sombra');
            cuadrosVisibles.push('#temp-multianual');
            cuadrosVisibles.push('#temperatura-maxima');
            iconosVisibles.push('#icono-temp-multianual');
            break;
        case 'brillo_solar_multianual':
            $('.caja-convenciones').html(convencionesBrillo);
            cuadrosVisibles.push('#brillo');
            iconosVisibles.push('#icono-brillo');
            break;
        case 'evotranspiracion':
            $('.caja-convenciones').html(convencionesETo);
            cuadrosVisibles.push('#evapotranspiracion');
            iconosVisibles.push('#icono-evapotranspiracion');
            break;
        case 'hum_relativa_multianual':
            $('.caja-convenciones').html(convencionesHumedad);
            cuadrosVisibles.push('#humedad');
            iconosVisibles.push('#icono-humedad');
            break;
        case 'anomalia_p':
            cuadrosVisibles.push('#anomalia-p');
            iconosVisibles.push('#icono-anomalia-p');
            $('#boton-anomalia-p-nino').removeClass('active');
            $('#boton-anomalia-p-nina').removeClass('active');
            break;
        case 'anomalia_nino':
            $('.caja-convenciones').html(convencionesPptNino);
            $('#anomalia-p').addClass('none');
            $('#icono-anomalia-p').removeClass('icono-sombra');
            cuadrosVisibles.push('#anomalia-p');
            cuadrosVisibles.push('#anomalia-p-nino');
            iconosVisibles.push('#icono-anomalia-p');
            break;
        case 'anomalia_nina':
            $('.caja-convenciones').html(convencionesPptNina);
            $('#anomalia-p').addClass('none');
            $('#icono-anomalia-p').removeClass('icono-sombra');
            cuadrosVisibles.push('#anomalia-p');
            cuadrosVisibles.push('#anomalia-p-nina');
            iconosVisibles.push('#icono-anomalia-p');
            break;
        case 'anomalia_t':
            cuadrosVisibles.push('#anomalia-t');
            iconosVisibles.push('#icono-anomalia-t');
            $('#boton-anomalia-t-min-nino').removeClass('active');
            $('#boton-anomalia-t-min-nina').removeClass('active');
            $('#boton-anomalia-t-max-nino').removeClass('active');
            $('#boton-anomalia-t-max-nina').removeClass('active');
            break;
        case 'anomalia_tmin_nina':
            $('.caja-convenciones').html(convencionesTempMinNina);
            $('#anomalia-t').addClass('none');
            $('#icono-anomalia-t').removeClass('icono-sombra');
            cuadrosVisibles.push('#anomalia-t');
            cuadrosVisibles.push('#anomalia-t-min-nina');
            iconosVisibles.push('#icono-anomalia-t');
            $('#boton-anomalia-t-min-nino').removeClass('active');
            $('#boton-anomalia-t-max-nino').removeClass('active');
            break;
        case 'anomalia_tmin_nino':
            $('.caja-convenciones').html(convencionesTempMinNino);
            $('#anomalia-t').addClass('none');
            $('#icono-anomalia-t').removeClass('icono-sombra');
            cuadrosVisibles.push('#anomalia-t');
            cuadrosVisibles.push('#anomalia-t-min-nino');
            iconosVisibles.push('#icono-anomalia-t');
            $('#boton-anomalia-t-min-nina').removeClass('active');
            $('#boton-anomalia-t-max-nina').removeClass('active');
            break;
        case 'anomalia_tmax_nina':
            $('.caja-convenciones').html(convencionesTempMaxNina);
            $('#anomalia-t').addClass('none');
            $('#icono-anomalia-t').removeClass('icono-sombra');
            cuadrosVisibles.push('#anomalia-t');
            cuadrosVisibles.push('#anomalia-t-max-nina');
            iconosVisibles.push('#icono-anomalia-t');
            $('#boton-anomalia-t-min-nino').removeClass('active');
            $('#boton-anomalia-t-max-nino').removeClass('active');
            break;
        case 'anomalia_tmax_nino':
            $('.caja-convenciones').html(convencionesTempMaxNino);
            $('#anomalia-t').addClass('none');
            $('#icono-anomalia-t').removeClass('icono-sombra');
            cuadrosVisibles.push('#anomalia-t');
            cuadrosVisibles.push('#anomalia-t-max-nino');
            iconosVisibles.push('#icono-anomalia-t');
            $('#boton-anomalia-t-min-nina').removeClass('active');
            $('#boton-anomalia-t-max-nina').removeClass('active');
            break;
        case 'frecuencia':
            cuadrosVisibles.push('#frecuencia');
            iconosVisibles.push('#icono-frecuencia');
            $('#boton-frecuencia-exceso').removeClass('active');
            $('#boton-frecuencia-deficit').removeClass('active');
            break;
        case 'exceso':
            $('.caja-convenciones').html(convencionesExceso);
            $('#frecuencia').addClass('none');
            $('#icono-frecuencia').removeClass('icono-sombra');
            cuadrosVisibles.push('#frecuencia');
            cuadrosVisibles.push('#frecuencia-exceso');
            iconosVisibles.push('#icono-frecuencia');
            break;
        case 'deficit':
            $('.caja-convenciones').html(convencionesDeficit);
            $('#frecuencia').addClass('none');
            $('#icono-frecuencia').removeClass('icono-sombra');
            cuadrosVisibles.push('#frecuencia');
            cuadrosVisibles.push('#frecuencia-deficit');
            iconosVisibles.push('#icono-frecuencia');
            break;
        case 'susceptibilidad':
            cuadrosVisibles.push('#susceptibilidad');
            iconosVisibles.push('#icono-susceptibilidad');
            $('#boton-susceptibilidad-inundacion').removeClass('active');
            $('#boton-susceptibilidad-igac').removeClass('active');
            break;
        case 'inundacion_susceptibilidad':
            $('.caja-convenciones').html(convencionesSusceptibilidad);
            $('#susceptibilidad').addClass('none');
            $('#icono-susceptibilidad').removeClass('icono-sombra');
            cuadrosVisibles.push('#susceptibilidad');
            cuadrosVisibles.push('#susceptibilidad-inundacion');
            iconosVisibles.push('#icono-susceptibilidad');
            break;
        case 'inundacion_2010_2011_igac':
            $('.caja-convenciones').html(convencionesInundacion);
            $('#susceptibilidad').addClass('none');
            $('#icono-susceptibilidad').removeClass('icono-sombra');
            cuadrosVisibles.push('#susceptibilidad');
            cuadrosVisibles.push('#susceptibilidad-igac');
            iconosVisibles.push('#icono-susceptibilidad');
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
    }

    for (var i = 2, len = arregloCapas.length; i < len; i++) {
        if (l == arregloCapas[i].nombre) {
            clicMapa(arregloCapas[i].convencion, feature, arregloCapas[i].categoria, pixel);
        }
    }
};

function cargarMapasIniciales() {
    cargando = 0;
    finalizados = 0;
    errores = 0;
    if (!primeraPublicacion) {
        publicarCapa(0);
        publicarCapa(1);
        //esperarCapa(1);
        primeraPublicacion = true;
    }
    else {
        $('#load').hide();
    }
};

function obtenerVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) {
            return pair[1];
        }
    }
    alert('Query Variable ' + variable + ' not found');
}

function toggleGlobo() {
    $("#globo-seleccion-departamento").addClass('none');
    $("#globo-seleccion-municipio").toggleClass('none');
};

function toggleGlobo1() {
    $("#globo-seleccion-municipio").addClass('none');
    var anchoGlobo = 180;
    var anchoMenu = $("#barra-departamento").width();
    var posicionMenu = $("#barra-departamento").position().left;
    var posicion = (anchoMenu / 2) - (anchoGlobo / 2);
    $("#globo-seleccion-departamento").css('left', posicion + "px");
    $("#globo-seleccion-departamento").toggleClass('none');
};
//Si el espacio del mapa es menor a 600px la caja de créditos se contrae
function checkSize() {
    var dimension = map.getSize()[0] < 600;
    creditos.setCollapsible(dimension);
    creditos.setCollapsed(dimension);
}
//#endregion