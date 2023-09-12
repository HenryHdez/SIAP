//#region Definición de variables globales
var arregloCapas = new Array();
var arregloMapasBase = new Array();
var cargando = 0, finalizados = 0, errores = 0;
var map, info, bounds, feature, dptosV;
var primeraPublicacion = false;
var js = caracteresEspeciales(rutaServidor + encodeURIComponent(rutaServidor) + 'Corpoica%2Fwms%3F_dc%3D1298030235325%26service%3DWMS%26request%3Dgetcapabilities');
var rutaServidorProxy = ol.ProxyHost + '?url=' + js;
var container = document.getElementById('popup');
var content = document.getElementById('popup-content');
var closer = document.getElementById('popup-closer');
var highlightStyleCache = {};
var layerSwitcher = new ol.control.LayerSwitcher({
    tipLabel: 'Leyenda'
});
var collection = new ol.Collection();
var overlay = new ol.Overlay({
    element: container
});
var extent = [-8795801.562415265, -466393.3042026925, -7445942.483830706, 1399645.1725650658];
var view = new ol.View({
    projection: "EPSG:900913"
});
if (raiz.length == 1) {
    raiz = "";
}
ol.ProxyHost = raiz + "/Proxy/proxy.ashx";
var creditos = new ol.control.Attribution({
    collapsible: false
});
var texto = new ol.layer.Tile({
    source: new ol.source.XYZ({
        url: 'http://tile.openstreetmap.se/hydda/roads_and_labels/{z}/{x}/{y}.png'
    })
});
texto.setZIndex(99);
var featureOverlay;
var capaSeleccionada = false;
//#endregion

//#region Definición de fuentes para mapas base
//Mapa 1
var layer1 =
    new ol.layer.Tile({
        title: 'Google',
        type: 'base',
        visible: localStorage.getItem("base") == 1 ? true : false,
        source: new ol.source.OSM({
            url: 'http://mt{0-3}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}',
            attributions: [
                new ol.Attribution({ html: 'Datos del mapa ©2016 Google' }),
            ]
        })
    });
//Mapa 2
var layer2 =
    new ol.layer.Tile({
        title: 'Fisico',
        type: 'base',
        visible: localStorage.getItem("base") == 2 ? true : false,
        source: new ol.source.OSM({
            url: 'http://{a-c}.tile.openstreetmap.org/{z}/{x}/{y}.png'
        })
    });
//Mapa 3
var layer3 =
    new ol.layer.Tile({
        title: 'Acuarela',
        type: 'base',
        //visible: localStorage.getItem("base") == 3 ? true : false,
        visible: false,
        source: new ol.source.Stamen({
            layer: 'watercolor'
        })
    });
//#endregion

//#region Valida la carga del mapa base. Una vez finalizada procede con la carga de las capas fijas
//Mapa 1
layer1.getSource().on('tileloadend', function (event) {
    finalizados++;
    if (cargando === finalizados + errores) {
        localStorage.setItem("base", 1);
        cargarMapasIniciales();
    }
});
layer1.getSource().on('tileloadstart', function (event) {
    if (cargando === 0) {
        $('#load').show();
        texto.setVisible(false);
    }
    cargando++;
});
layer1.getSource().on('tileloaderror', function (event) {
    errores++;
    console.log("Error al cargar el mapa");
});
//Mapa 2
layer2.getSource().on('tileloadend', function (event) {
    finalizados++;
    if (cargando === finalizados + errores) {
        localStorage.setItem("base", 2);
        cargarMapasIniciales();
    }
});
layer2.getSource().on('tileloadstart', function (event) {
    if (cargando === 0) {
        $('#load').show();
        texto.setVisible(false);
    }
    cargando++;
});
layer2.getSource().on('tileloaderror', function (event) {
    errores++;
});
//Mapa 3
layer3.getSource().on('tileloadend', function (event) {
    finalizados++;
    if (cargando === finalizados + errores) {
        localStorage.setItem("base", 3);
        cargarMapasIniciales();
    }
});
layer3.getSource().on('tileloadstart', function (event) {
    if (cargando === 0) {
        $('#load').show();
        texto.setVisible(true);
    }
    cargando++;
});
layer3.getSource().on('tileloaderror', function (event) {
    errores++;
});
window.app = {};
var app = window.app;
//#endregion

// Control de orientación (puntos cardinales)
app.CustomToolbarControl = function (opt_options) {
    var options = opt_options || {};
    var imagenCardinal = document.createElement('img');
    imagenCardinal.innerHTML = 'N';
    imagenCardinal.src = '../Content/imagenes/iconos/icono-mapa-cardinal.png'
    var element = document.createElement('div');
    element.className = 'ol-unselectable ol-mycontrol';
    element.appendChild(imagenCardinal);
    ol.control.Control.call(this, {
        element: element,
        target: options.target
    });
};
var mousePositionControl = new ol.control.MousePosition({
    coordinateFormat: ol.coordinate.createStringXY(4),
    projection: 'EPSG:4326',
    undefinedHTML: 'coordenadas'
});
ol.inherits(app.CustomToolbarControl, ol.control.Control);

//#region Definición del mapa
map = new ol.Map({
    target: 'map',
    view: view,
    interactions: ol.interaction.defaults({ mouseWheelZoom: false }),
    controls: ol.control.defaults().extend([
        creditos,
        new ol.control.FullScreen({ tipLabel: "Pantalla completa" }),
        new ol.control.ScaleLine(),
        new ol.control.Zoom({ zoomInTipLabel: "Acercar", zoomOutTipLabel: "Alejar" })
    ]).extend([new app.CustomToolbarControl()]).extend([mousePositionControl]),
    layers: [new ol.layer.Group({
        'title': 'Mapas base',
        layers: [
            layer3,
            layer2,
            layer1
        ]
    })]
});
//#endregion

//#region Objetos y acciones sobre el mapa
map.addOverlay(overlay);
map.addControl(layerSwitcher);
closer.onclick = function cerrar_popup() {
    container.style.display = 'none';
    closer.blur();
};
map.addLayer(texto);
//#endregion

function publicarCapa(codigo) {
    //Presentación de ícono de carga
    $('#load').show();

    //Definición de ruta de servidor de mapas
    url = rutaServidor + "ows?";
    if (arregloCapas[codigo].filtro != null) {
        url = url + "&cql_filter=(" + arregloCapas[codigo].filtro + ")";
    };

    //Definición de fuente de capa
    arregloCapas[codigo].fuente = new ol.source.Vector({
        loader: function (extent) {
            format: new ol.format.GeoJSON(),
            $.ajax(url, {
                type: 'GET',
                data: {
                    service: 'WFS',
                    version: '1.0.0',
                    request: 'GetFeature',
                    typename: 'Corpoica:' + arregloCapas[codigo].url,
                    outputFormat: 'application/json',
                    srsname: 'EPSG:900913',
                    //bbox: extent.join(',') + ',EPSG:900913'
                }
            }).done(loadFeatures)
                .fail(function () {
                    //Ocultar ícono de carga
                    $('#load').hide();
                    $('#modal-error-carga').modal('show');
                });
        },
        strategy: ol.loadingstrategy.bbox
    });

    //Función de carga de 'features' de capa, que se llama luego de recibir respuesta del servidor
    function loadFeatures(response) {
        console.log("response: " + response);
        geoJSONFormat = new ol.format.GeoJSON();
        var features = geoJSONFormat.readFeatures(response);
        arregloCapas[codigo].fuente.addFeatures(features);
        console.log("features: " + arregloCapas[codigo].fuente);
        //Ocultar ícono de carga
        $('#load').hide();
    }

    //Definición de objeto de capa con fuente, estilo y nombres definidos
    arregloCapas[codigo].capa = new ol.layer.Vector({
        source: arregloCapas[codigo].fuente,
        style: arregloCapas[codigo].estilo,
        title: arregloCapas[codigo].nombre,
        visible: true
    });

    //Se agrega capa al mapa
    arregloCapas[codigo].publicada = true;
    map.addLayer(arregloCapas[codigo].capa);
};

//#region Funciones
function caracteresEspeciales(url) {
    var chars = [' ', '<', '>', '#', '%', '~', '/', '|', ';', ':', '=', '?', '&'];
    var source = url;
    var dest = "";
    for (var i = 0; i < source.length; i++) {
        var c = source.charAt(i);
        var found = 0;
        for (var j = 0; (!found) && (j < chars.length) ; j++) {
            if (chars[j] == c) {
                found = 1;
            }
        }
        if (found) {
            dest += "%" + source.charCodeAt(i).toString(16);
        } else {
            dest += c;
        }
    }
    return dest;
};

function clicMapa(modelo, feature, propiedad, pixel) {
    if (feature) {
        mostrarGlobo(modelo, feature, propiedad, pixel);
    }
    else {
        ocultarGlobo();
    };
};

function mostrarGlobo(modelo, feature, propiedad, pixel) {
    var texto = 'Zona sin información';
    if (feature.get(propiedad) == null) {
        propiedad = omitirAcentos(propiedad);
    }
    var coordinate = map.getCoordinateFromPixel(pixel);
    if (propiedad === "altitud") {
        var coord = ol.coordinate.toStringHDMS(ol.proj.transform(coordinate, 'EPSG:3857', 'EPSG:4326'));
        texto = feature.get('nombre') + "</br><code>" + coord + "</code></br>Altitud: " + feature.get('altitud') + "</br>Código IDEAM: " + feature.get('codigo');
    }
    else if (propiedad === "contraccion" || propiedad === "expansion") {
        texto = "Cuerpos de agua";
    }
    else {
        codigoCategoria = feature.get(propiedad).toString();
        console.log("Código de categoría: " + codigoCategoria);
        $.each(modelo, function (i, item) {
            if (modelo[i].Categoria == codigoCategoria || modelo[i].Layer == codigoCategoria) {
                texto = modelo[i].Convencion;
                return (false);
            }
        });
    }
    overlay.setPosition(coordinate);
    lnk = texto;
    content.innerHTML = lnk;
    container.style.display = 'block';
};

function ocultarGlobo() {
    highlightStyleCache = {};
    container.style.display = 'none';
    closer.blur();
};

function ajustarMapa(extent) {
    map.getView().fit(extent, map.getSize());
};

function cambiarVisibilidadCapa(codigoCapa) {
    if (arregloCapas[codigoCapa].capa.getVisible()) {
        apagarCapa(codigoCapa);
    }
    else {
        encenderCapa(codigoCapa);
    }
};

function encenderCapa(codigoCapa) {
    arregloCapas[codigoCapa].capa.setVisible(true);
};

function apagarCapa(codigoCapa) {
    arregloCapas[codigoCapa].capa.setVisible(false);
};

function omitirAcentos(text) {
    var acentos = "ÁÉÍÓÚÜÑáéíóúüñ";
    var original = "AEIOUUNaeiouun";
    for (var i = 0; i < acentos.length; i++) {
        text = text.replace(acentos.charAt(i), original.charAt(i));
    }
    return text;
}

var target = map.getTarget();
var jTarget = typeof target === "string" ? $("#" + target) : $(target);

// Cambio del cursor cuando pasa sobre una región del mapa
$(map.getViewport()).on('mousemove', function (e) {
    var pixel = map.getEventPixel(e.originalEvent);
    var hit = map.forEachFeatureAtPixel(pixel, function (feature, layer) {
        var capa = layer.get('title');
        if (capa !== "municipios" && capa !== "estaciones" && capa !== "departamentos") {
            return true;
        }
    });
    if (hit) {
        jTarget.css("cursor", "pointer");
    } else {
        jTarget.css("cursor", "");
    }
});
//#endregion