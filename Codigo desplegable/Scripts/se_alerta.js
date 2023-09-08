//#region Definición de variables globales
//var arregloCapas = new Array();
//var map, info, bounds, feature, dptosV;
//var cargando = 0, finalizados = 0, errores = 0;
//var primeraPublicacion = false;
//var js = caracteresEspeciales(rutaServidor + encodeURIComponent(rutaServidor) + 'Corpoica%2Fwms%3F_dc%3D1298030235325%26service%3DWMS%26request%3Dgetcapabilities');
//var rutaServidorProxy = ol.ProxyHost + '?url=' + js;
extent = coordenadas;
//var view = new ol.View({
//    projection: "EPSG:900913"
//});
//if (raiz.length == 1) {
//    raiz = "";
//}
//ol.ProxyHost = raiz + "/Proxy/proxy.ashx";
//var creditos = new ol.control.Attribution({
//    collapsible: false
//});
//var texto = new ol.layer.Tile({
//    source: new ol.source.XYZ({
//        url: 'http://tile.openstreetmap.se/hydda/roads_and_labels/{z}/{x}/{y}.png'
//    })
//});
//texto.setZIndex(99);
//var featureOverlay;
var estaciones = "";
var estacionesCoordenadas = "";
for (k = 0; k < estacionesIDEAMV.length; k++) {
    estaciones = estaciones + "codigo='" + estacionesIDEAMV[k] + "' or ";
}
estaciones = estaciones.slice(0, estaciones.length - 3);
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
        visible: localStorage.getItem("base") == 3 ? true : false,
        source: new ol.source.Stamen({
            layer: 'watercolor'
        })
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
//#endregion

//#region Definición de parcela seleccionada
var pto = ol.proj.transform(pto_t, "EPSG:4326", "EPSG:900913");
console.log(pto_t);
console.log(pto);
parcela[0] = new ol.Feature({
    geometry: new ol.geom.Point(pto),
    name: cultivoNombre,
    id: '1',
});
var parcelas = new ol.layer.Vector({
    title: "parcelas",
    source: new ol.source.Vector({
        features: parcela
    }),
    style: parcelas_sty
});
//#endregion

//#region Definición de estaciones
var js = caracteresEspeciales(rutaServidor + "ows?service=WFS&version=1.0.0&request=GetFeature&typeName=Corpoica:estaciones_climatologicas&outputFormat=application/json&cql_filter=(" + estaciones + ")");
var estaciones_source = new ol.source.Vector({
    projection: 'EPSG:900913',
    url: ol.ProxyHost + '?url=' + js,
    format: new ol.format.GeoJSON()
});

var estaciones_pto = new ol.layer.Vector({
    title: "estaciones_pto",
    source: estaciones_source,
    style: estaciones_sty
});
//map.addLayer(estaciones_pto);

var estaciones = new ol.layer.Vector({
    title: "estaciones_palmer",
    source: estaciones_source,
    style: estaciones_municipio_alertas_sty
});
//#endregion

//#region Definición del mapa
//map = new ol.Map({
//    target: 'map',
//    view: view,
//    interactions: ol.interaction.defaults({ mouseWheelZoom: false }),
//    controls: ol.control.defaults({ zoom: false, attribution: true }).extend([
//        new ol.control.ScaleLine()
//    ]),
//    layers: [new ol.layer.Group({
//        'title': 'Mapas base',
//        layers: [
//            layer3,
//            layer2,
//            layer1
//        ]
//    })]
//});
//#endregion

//#region Objetos y acciones sobre el mapa
map.addLayer(texto);
map.addLayer(estaciones);
parcelas.setZIndex(100);
map.addLayer(parcelas);
ajustarMapa(extent);
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
//#endregion

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

function ajustarMapa(extent) {
    map.getView().fit(extent, map.getSize());
};

function cargarMapasIniciales() {
    cargando = 0;
    finalizados = 0;
    errores = 0;
    if (!primeraPublicacion) {
        publicarCapa(0);
        //esperarCapa(0);
        primeraPublicacion = true;
    };
    $('#load').hide();
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
//    var listenerKey = arregloCapas[codigo].fuente.on('change', function (e) {
//        if (arregloCapas[codigo].fuente.getState() == 'ready') {
//            capasFinalizadas = true;
//            $('#load').hide();
//            ol.Observable.unByKey(listenerKey);
//        }
//    });
//};
//#endregion