//#region Definición de variables para país
var dptosV = dptos.slice(0, dptos.length - 1).split(",");
console.log("y aqui?");
featureOverlay = new ol.layer.Vector({
    map: map,
    style: function (feature, resolution) {
        console.log("por aquiiii");
        if (feature) {
            var text = resolution < 5000 ? feature.get('name') : '';
            console.log("text: " + text);
            if (!highlightStyleCache[text]) {
                highlightStyleCache[text] =
                    [
                    new ol.style.Style({
                        stroke: new ol.style.Stroke({
                            color: '#f00',
                            width: 1
                        }),
                        fill: new ol.style.Fill({
                            color: 'rgba(255,0,0,1)'
                        }),
                    })
                    ];
            }
        }
        return highlightStyleCache[text];
    }
});
//#endregion

//#region Definición de capas que se pueden cargar desde GeoServer
//Creación de objeto de capa para departamento
arregloCapas.push({
    "nombre": "departamentos",
    "url": "departamentos_low",
    "filtro": null,
    "estilo": departamentos_sty,
    "visible": true,
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
//#endregion

//#region Funciones
function cargarMapasIniciales() {
    cargando = 0;
    finalizados = 0;
    errores = 0;
    if (!primeraPublicacion) {
        publicarCapa(0);
        //esperarCapa(0);
        primeraPublicacion = true;
    }
    else {
        $('#load').hide();
    }
};

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
}

function consultarCodigoCapa(nombreCapa) {
    for (var i = 0; i < arregloCapas.length; i++) {
        if (arregloCapas[i].nombre === nombreCapa) {
            return i;
        }
    }
};

//function publicarCapa(codigo) {
//    //Presentación de ícono de carga
//    $('#load').show();

//    //Definición de ruta de servidor de mapas
//    url = rutaServidor + "ows?";
//    if (arregloCapas[codigo].filtro != null) {
//        url = url + "&cql_filter=(" + arregloCapas[codigo].filtro + ")";
//    };

//    //Definición de fuente de capa
//     arregloCapas[codigo].fuente = new ol.source.Vector({
//         loader: function (extent) {
//            format: new ol.format.GeoJSON(),
//            $.ajax(url, {
//                type: 'GET',
//                data: {
//                    service: 'WFS',
//                    version: '1.0.0',
//                    request: 'GetFeature',
//                    typename: 'Corpoica:'+ arregloCapas[codigo].url,
//                    outputFormat: 'application/json',
//                    srsname: 'EPSG:900913',
//                    bbox: extent.join(',') + ',EPSG:900913'
//                }
//            }).done(loadFeatures)
//                .fail(function () {
//                    //Ocultar ícono de carga
//                    $('#load').hide();
//                    $('#modal-error-carga').modal('show');
//                });
//        },
//        strategy: ol.loadingstrategy.bbox
//    });

//    //Función de carga de 'features' de capa, que se llama luego de recibir respuesta del servidor
//    function loadFeatures(response) {
//        console.log("response: " + response);
//        geoJSONFormat = new ol.format.GeoJSON();
//        var features = geoJSONFormat.readFeatures(response);
//        arregloCapas[codigo].fuente.addFeatures(features);
//        console.log("features: "+arregloCapas[codigo].fuente);
//        //Ocultar ícono de carga
//        $('#load').hide();
//    }

//    //Definición de objeto de capa con fuente, estilo y nombres definidos
//    arregloCapas[codigo].capa = new ol.layer.Vector({
//        source: arregloCapas[codigo].fuente,
//        style: arregloCapas[codigo].estilo,
//        title: arregloCapas[codigo].nombre,
//        visible: true
//    });

//    //Se agrega capa al mapa
//    arregloCapas[codigo].publicada = true;
//    map.addLayer(arregloCapas[codigo].capa);
//};

function toggleGlobo() {
    $("#globo-seleccion-departamento").toggleClass('none');
};

//Si el espacio del mapa es menor a 600px la caja de créditos se contrae
function checkSize() {
    var dimension = map.getSize()[0] < 600;
    creditos.setCollapsible(dimension);
    creditos.setCollapsed(dimension);
}
//#endregion