const ch1on = document.getElementById('ch1');
const sl1on = document.getElementById('sl1');
const ch2on = document.getElementById('ch2');
const sl2on = document.getElementById('sl2');
const ch3on = document.getElementById('ch3');
const sl3on = document.getElementById('sl3');
const ch4on = document.getElementById('ch4');
const sl4on = document.getElementById('sl4');
const ch5on = document.getElementById('ch5');
const sl5on = document.getElementById('sl5');
const ch6on = document.getElementById('ch6');
const sl6on = document.getElementById('sl6');
const ch7on = document.getElementById('ch7');
const sl7on = document.getElementById('sl7');
const ch8on = document.getElementById('ch8');
const sl8on = document.getElementById('sl8');
const ch9on = document.getElementById('ch9');
const sl9on = document.getElementById('sl9');
const ch10on = document.getElementById('ch10');
const sl10on = document.getElementById('sl10');
const ch11on = document.getElementById('ch11');
const sl11on = document.getElementById('sl11');
const ch12on = document.getElementById('ch12');
const sl12on = document.getElementById('sl12');
const ch13on = document.getElementById('ch13');
const sl13on = document.getElementById('sl13');
const ch14on = document.getElementById('ch14');
const sl14on = document.getElementById('sl14');
const homebtn = document.getElementById('homebtn');

var legend1;
var legend2;
var legend3;
var legend4;
var legend5;
var legend6;

var osm = L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 15, attribution: '© OpenStreetMap' });

const mbAttr = 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>';
const mbUrl = 'https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw';

var streets = L.tileLayer(mbUrl, { id: 'mapbox/streets-v11', tileSize: 512, zoomOffset: -1, attribution: mbAttr });
const satellite = L.tileLayer(mbUrl, { id: 'mapbox/satellite-v9', tileSize: 512, zoomOffset: -1, attribution: mbAttr });
var map = L.map('mapBox', { center: [8.2, -73.35], zoom: 9.5, layers: [osm],
    scrollWheelZoom: false, 
});


const baseLayers = {
    'OpenStreetMap': osm,
    'Streets': streets,
    'Satellite': satellite
};

var popup = L.popup();
var layers = {};
var countLayers = 0;
var activeLayer = "";

var url_to_geotiff_file = [{ name: "CP01", url: '../Content/imagenes/Cebolla/Erosion/C.tif', index: 1, noData: -3.4028234663852886e+38, units: " "},
                           { name: "CP02", url: '../Content/imagenes/Cebolla/Erosion/E_v5.tif', index: 2, noData: -3.4028234663852886e+38, units: "t (ha año)<sup>-1</sup>" },
                           { name: "CP03", url: '../Content/imagenes/Cebolla/Erosion/K_v2_mg.TIF', index: 3, noData: -3.4028234663852886e+38, units: "t ha h (ha MJ mm)<sup>-1</sup>" },
                           { name: "CP04", url: '../Content/imagenes/Cebolla/Erosion/LS.tif', index: 4, noData: -3.4028234663852886e+38, units: " " },
                           { name: "CP05", url: '../Content/imagenes/Cebolla/Erosion/R_v2_mg.TIF', index: 5, noData: -3.4028234663852886e+38, units: "MJ mm (ha h año)<sup>-1</sup>" },
                           { name: "CP06", url: '../Content/imagenes/Cebolla/TiempoTermico/TT_01_abr_RP_Ex.tif', index: 6, noData: -3.4028234663852886e+38, units: "hrs/ciclo" },
                           { name: "CP07", url: '../Content/imagenes/Cebolla/TiempoTermico/TT_15_abr_RP_Ex.tif', index: 7, noData: -3.4028234663852886e+38, units: "hrs/ciclo" },
                           { name: "CP08", url: '../Content/imagenes/Cebolla/TiempoTermico/TT_01_may_RP_Ex.tif', index: 8, noData: -3.4028234663852886e+38, units: "hrs/ciclo" },
                           { name: "CP09", url: '../Content/imagenes/Cebolla/TiempoTermico/TT_15_may_RP_Ex.tif', index: 9, noData: -3.4028234663852886e+38, units: "hrs/ciclo" },
                           { name: "CP10", url: '../Content/imagenes/Cebolla/TiempoTermico/TT_01_oct_RP_Ex.tif', index: 10, noData: -3.4028234663852886e+38, units: "hrs/ciclo" },
                           { name: "CP11", url: '../Content/imagenes/Cebolla/TiempoTermico/TT_15_oct_RP_Ex.tif', index: 11, noData: -3.4028234663852886e+38, units: "hrs/ciclo" },
                           { name: "CP12", url: '../Content/imagenes/Cebolla/TiempoTermico/TT_01_nov_RP_Ex.tif', index: 12, noData: -3.4028234663852886e+38, units: "hrs/ciclo" },
                           { name: "CP13", url: '../Content/imagenes/Cebolla/TiempoTermico/TT_15_nov_RP_Ex.tif', index: 13, noData: -3.4028234663852886e+38, units: "hrs/ciclo" },
                           { name: "CP1A", url: '../Content/imagenes/Cebolla/AreaEstudio.tif', index: 1, noData: -3.4028234663852886e+38 }
]

function elminaley(op) {
    if (op == 0 && ff1 == 1) {
        if (!ch1on.checked && !ch2on.checked && !ch3on.checked && !ch4on.checked &&
            !ch5on.checked && !ch6on.checked && !ch7on.checked && !ch8on.checked &&
            !ch9on.checked && !ch10on.checked && !ch11on.checked && !ch12on.checked) {
            map.removeControl(legend1); ff1 = 0;
        }
    }
    if (op == 1 && ff2 == 1) {
        if (!ch13on.checked && !ch14on.checked && !ch15on.checked && !ch16on.checked) {
            map.removeControl(legend2); ff2 = 0;
        }
    }
    if (op == 2 && ff3 == 1) {
        if (!ch17on.checked) {
            map.removeControl(legend3); ff3 = 0;
        }
    }
}



function Marcadores(ubicacion) {
    fetch(ubicacion)
        .then(function(response) {
            return response.json();
        })
        .then(function(jsonData) {
            // Recorrer contenido del archivo
            jsonData.features.forEach(function(feature) {
                var latlng = feature.geometry.coordinates;
                var estacion = feature.properties.NOMBRE;
                var latitud = feature.properties.LATITUD;
                var longitud = feature.properties.LONGITUD;
                var et_azul = feature.properties.ET_AZUL;
                var et_verde = feature.properties.ET_VERDE;
                var et_total = feature.properties.ET_TOTAL;
                var adt_mm_m = feature.properties.ADT_mm_m;
                // Crear un marcador y agregarlo al mapa
                var marker = L.marker([latitud, longitud]).addTo(map);
                // Crear el contenido HTML del marcador
                var popupContent = '<div style="font-size: 16px;"><strong>Huella Hídrica ' + estacion + '</strong><br>' +
                    'Estación: ' + feature.properties.ESTACION + '<br>' +
                    'Nombre: ' + estacion + '<br>' +
                    'Latitud: ' + latitud + '<br>' +
                    'Longitud: ' + longitud + '<br>' +
                    'ET Azul: ' + et_azul + '<br>' +
                    'ET Verde: ' + et_verde + '<br>' +
                    'ET Total: ' + et_total + '<br>' +
                    'ADT (mm/m): ' + adt_mm_m + '</div>';
                marker.bindPopup(popupContent);
            });
        })
        .catch(function(error) {
            console.error('Error al cargar el archivo JSON:', error);
        });
}

function crearLeyenda(tipo) {
    // Define los datos de las leyendas en un objeto
    var leyendas = {
        'tiempo_termico': {
            titulo: 'Valor (hrs/ciclo)',
            datos: [
                { valor: '≤ 500', color: 'rgb(190, 232, 255)' },
                { valor: '500 – 700', color: 'rgb(115, 178, 255)' },
                { valor: '700 – 900', color: 'rgb(0, 92, 230)' },
                { valor: '900 – 1000', color: 'rgb(255, 255, 0)' },
                { valor: '1000 – 1200', color: 'rgb(255, 211, 127)' },
                { valor: '1200 – 1400', color: 'rgb(255, 170, 0)' },
                { valor: '1400 – 1600', color: 'rgb(76, 230, 0)' },
                { valor: '≥ 1600', color: 'rgb(56, 168, 0)' }
            ]
        },
        'erosividad': {
            titulo: 'Valor (MJ mm (ha h año)<sup>-1</sup>)',
            datos: [
                { valor: '< 4401', color: 'rgb(0, 97, 0)' },
                { valor: '4401 – 5039', color: 'rgb(38, 115, 0)' },
                { valor: '5039 – 5677', color: 'rgb(103, 158, 0)' },
                { valor: '5677 – 6315', color: 'rgb(176, 207, 0)' },
                { valor: '6315 – 6953', color: 'rgb(240, 228, 0)' },
                { valor: '6953 – 7591', color: 'rgb(255, 187, 0)' },
                { valor: '7591 – 8228', color: 'rgb(255, 123, 0)' },
                { valor: '8228 – 8866', color: 'rgb(255, 55, 0)' },
                { valor: '8866 – 9504', color: 'rgb(255, 34, 0)' }
            ]
        },
        'erodabilidad': {
            titulo: 'Valor (t ha h (ha MJ mm)<sup>-1</sup>)',
            datos: [
                { valor: '0', color: 'rgb(0, 97, 0)' },
                { valor: '0 – 0,005', color: 'rgb(38, 115, 0)' },
                { valor: '0,005 – 0,009', color: 'rgb(103, 158, 0)' },
                { valor: '0,009 – 0,012', color: 'rgb(176, 207, 0)' },
                { valor: '0,012 – 0,016', color: 'rgb(240, 228, 0)' },
                { valor: '0,016 – 0,02', color: 'rgb(255, 187, 0)' },
                { valor: '0,02 – 0,024', color: 'rgb(255, 123, 0)' },
                { valor: '0,024 – 0,027', color: 'rgb(255, 55, 0)' },
                { valor: '0,027 – 0,038', color: 'rgb(255, 34, 0)' }
            ]
        },
        'cobertura': {
            titulo: 'Valor',
            datos: [
                { valor: '< 0,044', color: 'rgb(0, 97, 0)' },
                { valor: '0,044 – 0,095', color: 'rgb(38, 115, 0)' },
                { valor: '0,095 – 0,132', color: 'rgb(103, 158, 0)' },
                { valor: '0,132 – 0,168', color: 'rgb(176, 207, 0)' },
                { valor: '0,168 – 0,204', color: 'rgb(240, 228, 0)' },
                { valor: '0,204 – 0,241', color: 'rgb(255, 187, 0)' },
                { valor: '0,241 – 0,277', color: 'rgb(255, 123, 0)' },
                { valor: '0,277 – 0,313', color: 'rgb(255, 55, 0)' },
                { valor: '0,313 – 0,446', color: 'rgb(255, 34, 0)' }
            ]
        },
        'pendiente': {
            titulo: 'Valor',
            datos: [
                { valor: '< 0,03', color: 'rgb(0, 97, 0)' },
                { valor: '0,03 – 1,77', color: 'rgb(38, 115, 0)' },
                { valor: '1,77 – 3,25', color: 'rgb(103, 158, 0)' },
                { valor: '3,25 – 4,73', color: 'rgb(176, 207, 0)' },
                { valor: '4,73 – 6,22', color: 'rgb(240, 228, 0)' },
                { valor: '6,22 – 7,70', color: 'rgb(255, 187, 0)' },
                { valor: '7,70 – 9,18', color: 'rgb(255, 123, 0)' },
                { valor: '9,18 – 10,66', color: 'rgb(255, 55, 0)' },
                { valor: '10,66 – 20,0', color: 'rgb(255, 34, 0)' }
            ]
        },
        'erosion_hidrica': {
            titulo: 'Valor (t (ha año)<sup>-1</sup>)',
            datos: [
                { valor: '< 10', color: 'rgb(0, 114, 6)' },
                { valor: '10 – 25', color: 'rgb(101, 171, 20)' },
                { valor: '25 – 50', color: 'rgb(196, 227, 29)' },
                { valor: '50 – 100', color: 'rgb(249, 223, 26)' },
                { valor: '100 – 200', color: 'rgb(255, 154, 11)' },
                { valor: '> 200', color: 'rgb(252, 59, 9)' }
            ]
        }
    };

    // Obtén los datos de la leyenda según el tipo
    var datosLeyenda = leyendas[tipo];

    if (!datosLeyenda) {
        return null; // Tipo de leyenda no válido
    }

    var legend = L.control({ position: 'topright' });

    legend.onAdd = function (map) {
        var div = L.DomUtil.create('div', 'info legend');
        div.innerHTML = '<div style="font-size: 12px; background-color: rgb(255, 255, 255); width:160px; font-size: 14px;"><b>' + datosLeyenda.titulo + '</b></div>';

        for (var i = 0; i < datosLeyenda.datos.length; i++) {
            div.innerHTML += '<div style="display: flex;"><div style="background-color: ' + datosLeyenda.datos[i].color + '; width: 20px; height: 20px;"></div>' +
                '<div style="font-size: 12px; background-color: rgb(255, 255, 255); width:140px;">' + datosLeyenda.datos[i].valor + '</div></div>';
        }

        return div;
    };

    return legend;
}

// Función para cargar todas las capas
async function cargarCapas() {
    var promesas = url_to_geotiff_file.map(data => {
        return new Promise((resolve, reject) => {
            fetch(data.url).
              then(response => response.arrayBuffer()).
              then(arrayBuffer => {
                  parseGeoraster(arrayBuffer).then(georaster => {
                      const min = georaster.mins[0];
                      const max = georaster.maxs[0];
                      const range = georaster.ranges[0];
                      const noData = georaster.noDataValue;
                      function convertToRgb(pixelValue) {
                          var red, green, blue, alpha
                          alpha = 1;
                          if (data.name == "CP06" || data.name == "CP07" || data.name == "CP08" || data.name == "CP09" ||
                              data.name == "CP10" || data.name == "CP11" || data.name == "CP12" || data.name == "CP13") {
                              if (pixelValue > 0) {
                                  var normalizedValue = ((pixelValue - min) / range);
                                  if (pixelValue < 500) {
                                      red = 190;
                                      green = 232;
                                      blue = 255;
                                  }
                                  else if (pixelValue >= 500 && pixelValue < 700) {
                                      red = 115;
                                      green = 178;
                                      blue = 255;
                                  }
                                  else if (pixelValue >= 700 && pixelValue < 900) {
                                      red = 0;
                                      green = 92;
                                      blue = 230;
                                  }
                                  else if (pixelValue >= 900 && pixelValue < 1000) {
                                      red = 255;
                                      green = 255;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 1000 && pixelValue < 1200) {
                                      red = 255;
                                      green = 211;
                                      blue = 127;
                                  }
                                  else if (pixelValue >= 1200 && pixelValue < 1400) {
                                      red = 255;
                                      green = 170;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 1400 && pixelValue < 1600) {
                                      red = 76;
                                      green = 230;
                                      blue = 0;
                                  }
                                  else {
                                      red = 56;
                                      green = 168;
                                      blue = 0;
                                      alpha = 0;
                                  }
                              } else {
                                  red = parseInt(255);
                                  green = parseInt(255);
                                  blue = parseInt(255);
                                  alpha = 0
                              }
                          }

                          else if (data.name == "CP01") {
                              if (pixelValue > 0) {
                                  var normalizedValue = ((pixelValue - min) / range);
                                  if (pixelValue < 0.044) {
                                      red = 0;
                                      green = 97;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.044 && pixelValue < 0.095) {
                                      red = 38;
                                      green = 115;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.095 && pixelValue < 0.132) {
                                      red = 103;
                                      green = 158;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.132 && pixelValue < 0.168) {
                                      red = 176;
                                      green = 207;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.168 && pixelValue < 0.204) {
                                      red = 240;
                                      green = 228;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.204 && pixelValue < 0.241) {
                                      red = 255;
                                      green = 187;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.241 && pixelValue < 0.277) {
                                      red = 255;
                                      green = 123;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.277 && pixelValue < 0.313) {
                                      red = 255;
                                      green = 55;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.313 && pixelValue < 0.446) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                      alpha = 0;
                                  }
                              } else {
                                  red = parseInt(255);
                                  green = parseInt(255);
                                  blue = parseInt(255);
                                  alpha = 0;
                              }
                          }

                          else if (data.name == "CP02") {
                              if (pixelValue > 0) {
                                  pixelValue = ((pixelValue - min) / range)*200;
                                  if (pixelValue < 10) {
                                      red = 0;
                                      green = 114;
                                      blue = 6;
                                  }
                                  else if (pixelValue >= 10 && pixelValue < 25) {
                                      red = 101;
                                      green = 171;
                                      blue = 20;
                                  }
                                  else if (pixelValue >= 25 && pixelValue < 50) {
                                      red = 196;
                                      green = 227;
                                      blue = 29;
                                  }
                                  else if (pixelValue >= 50 && pixelValue < 100) {
                                      red = 249;
                                      green = 223;
                                      blue = 26;
                                  }
                                  else if (pixelValue >= 100 && pixelValue < 200) {
                                      red = 255;
                                      green = 154;
                                      blue = 11;
                                  }
                                  else if (pixelValue >= 200 && pixelValue < 300) {
                                      red = 252;
                                      green = 59;
                                      blue = 9;
                                  }
                                  else {
                                      red = 0;
                                      green = 0;
                                      blue = 0;
                                      alpha = 0;
                                  }
                              } else {
                                  red = parseInt(255);
                                  green = parseInt(255);
                                  blue = parseInt(255);
                                  alpha = 0;
                              }
                          }

                          else if (data.name == "CP03") {
                              if (pixelValue > 0) {
                                  var normalizedValue = ((pixelValue - min) / range);
                                  if (pixelValue < 0.005) {
                                      red = 0;
                                      green = 97;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.005 && pixelValue < 0.009) {
                                      red = 38;
                                      green = 115;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.009 && pixelValue < 0.012) {
                                      red = 103;
                                      green = 158;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.012 && pixelValue < 0.016) {
                                      red = 176;
                                      green = 207;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.016 && pixelValue < 0.02) {
                                      red = 255;
                                      green = 187;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.02 && pixelValue < 0.024) {
                                      red = 255;
                                      green = 123;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.024 && pixelValue < 0.027) {
                                      red = 255;
                                      green = 55;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.027 && pixelValue < 0.038) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.038) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                      alpha = 0;
                                  }
                              } else {
                                  red = parseInt(255);
                                  green = parseInt(255);
                                  blue = parseInt(255);
                                  alpha = 0
                              }
                          }

                          else if (data.name == "CP04") {
                              if (pixelValue > 0) {
                                  var normalizedValue = ((pixelValue - min) / range);
                                  alpha = 1;

                                  if (pixelValue < 0.03) {
                                      red = 0;
                                      green = 97;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 0.03 && pixelValue < 1.77) {
                                      red = 38;
                                      green = 115;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 1.77 && pixelValue < 3.25) {
                                      red = 103;
                                      green = 158;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 3.25 && pixelValue < 4.73) {
                                      red = 176;
                                      green = 207;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 4.73 && pixelValue < 6.22) {
                                      red = 255;
                                      green = 187;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 6.22 && pixelValue < 7.70) {
                                      red = 255;
                                      green = 123;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 7.70 && pixelValue < 9.18) {
                                      red = 255;
                                      green = 55;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 9.18 && pixelValue < 10.66) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 10.66 && pixelValue < 20) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 20) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                      alpha = 0;
                                  }
                              } else {
                                  red = parseInt(255);
                                  green = parseInt(255);
                                  blue = parseInt(255);
                                  alpha = 0
                              }
                          }

                          else if (data.name == "CP05") {
                              if (pixelValue > 0) {
                                  var normalizedValue = ((pixelValue - min) / range);
                                  alpha = 1;

                                  if (pixelValue < 4401) {
                                      red = 0;
                                      green = 97;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 4401 && pixelValue < 5039) {
                                      red = 38;
                                      green = 115;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 5039 && pixelValue < 5677) {
                                      red = 103;
                                      green = 158;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 5677 && pixelValue < 6315) {
                                      red = 176;
                                      green = 207;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 6315 && pixelValue < 6953) {
                                      red = 255;
                                      green = 187;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 6953 && pixelValue < 7591) {
                                      red = 255;
                                      green = 123;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 7591 && pixelValue < 8828) {
                                      red = 255;
                                      green = 55;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 8228 && pixelValue < 8866) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 8866 && pixelValue < 9504) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else if (pixelValue >= 9504) {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                  }
                                  else {
                                      red = 255;
                                      green = 34;
                                      blue = 0;
                                      alpha = 0;
                                  }
                              } else {
                                  red = parseInt(255);
                                  green = parseInt(255);
                                  blue = parseInt(255);
                                  alpha = 0
                              }
                          }

                          else{
                              if (pixelValue < 50) {
                                  alpha = 0.3;
                                  red = 0;
                                  green = 100;
                                  blue = 200;
                              } else {
                                  alpha = 0;
                                  red = 0;
                                  green = 0;
                                  blue = 0;
                              }
                          }
                          return 'rgba(' + red + ', ' + green + ', ' + blue + ',' + alpha + ')';
                      }

                      var overlay = new GeoRasterLayer({
                          georaster: georaster,
                          pixelValuesToColorFn: (pixelValues) => {
                              var pixelValue = pixelValues[0];
                              var color = convertToRgb(pixelValue);
                              return color;
                          },
                          resolution: 256
                      })

                      layers[data.name] = overlay

                      map.on('click', function (evt) {
                          var latlng = evt.latlng;
                          latlng.lat = latlng.lat - 0.001578;
                          latlng.lng = latlng.lng + 0.02478;

                          url_to_geotiff_file.forEach(function(data) {
                              if (data.name == activeLayer) {
                                  var value = geoblaze.identify(georaster, [latlng.lng, latlng.lat])[0];
                                  value = value.toFixed(3);

                                  if (value != data.noData) {
                                      var dialogTitle = "Información de la capa";
                                      var units = data.units;
                                      var locationInfo = `Latitud: ${latlng.lat.toFixed(5)}, Longitud: ${latlng.lng.toFixed(5)}`;

                                      var dialogContent = `<h3>${dialogTitle}</h3>` +
                                          `<p><b>Valor:</b> ${value} ${units}</p>` +
                                          `<p><b>Ubicación:</b> ${locationInfo}</p>`;

                                      document.getElementById('modal-body').innerHTML = dialogContent;
                                      window.modalmapa.showModal();
                                  }
                              }
                          });
                      });

                    
                  })
              }).catch(error => reject(error));
        });
    });

    await Promise.all(promesas);
}

var printer = L.easyPrint({
    tileLayer: streets,
    sizeModes: ['Current', 'A4Landscape', 'A4Portrait'],
    filename: 'myMap',
    exportOnly: true,
    hideControlContainer: true
}).addTo(map);

function cerrarModalMapa() {
    var modal = document.getElementById('modalmapa');
    modal.close();
}

function manualPrint() {
    printer.printMap('CurrentSize', 'MyManualPrint')
}

function Casa_Func() {
    map.setView([8.2, -73.35], 9.5);
}

function Deshabilitar() {
    document.getElementById('lis_mapa1').style.display = "none";
    document.getElementById('lis_mapa2').style.display = "none";
}

function habilitar() {
    document.getElementById('lis_mapa1').style.display = "block";
    document.getElementById('lis_mapa2').style.display = "block";
}

function eliminarElementos() {
    $(".leaflet-marker-icon, .leaflet-marker-shadow, .leaflet-popup").remove();
    try {
        map.removeControl(legend1);
    } catch (error) {
        console.error("Se produjo un error al quitar la leyenda:", error);
    }
    try {
        map.removeControl(legend2);
    } catch (error) {
        console.error("Se produjo un error al quitar la leyenda:", error);
    }
    try {
        map.removeControl(legend3);
    } catch (error) {
        console.error("Se produjo un error al quitar la leyenda:", error);
    }
    try {
        map.removeControl(legend4);
    } catch (error) {
        console.error("Se produjo un error al quitar la leyenda:", error);
    }
    try {
        map.removeControl(legend5);
    } catch (error) {
        console.error("Se produjo un error al quitar la leyenda:", error);
    }
    try {
        map.removeControl(legend6);
    } catch (error) {
        console.error("Se produjo un error al quitar la leyenda:", error);
    }
}

function reiniciarMapa() {
    eliminarElementos();
    for (var i = 1; i <= 13; i++) {
        var layerName = "CP" + (i < 10 ? "0" : "") + i;
        map.removeLayer(layers[layerName]);
        var checkbox = document.getElementById("ch" + i);
        checkbox.checked = false;
        var slider = document.getElementById("sl" + i);
        slider.disabled = true;
    }
}

document.addEventListener('DOMContentLoaded', () => {

    ch1on.addEventListener("change", () => {
        if (ch1on.checked) {
            legend1=crearLeyenda('cobertura');
            try {
                 map.removeControl(legend1);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            legend1.addTo(map);

            map.addLayer(layers["CP01"])
            activeLayer = "CP01"
            sl1on.disabled = false;
        } else {
            map.removeControl(legend1);
            map.removeLayer(layers["CP01"]);
            sl1on.disabled = true;
        }
    });
    sl1on.addEventListener("input", (event) => {
        layers["CP01"].setOpacity(event.target.value / 100);
    });

    ch2on.addEventListener("change", () => {
        if (ch2on.checked) {
            legend2=crearLeyenda('erosion_hidrica');
            try {
                map.removeControl(legend2);
            } catch (error) {
                console.error("Se produjo un error al quitar la leyenda:", error);
            }
            legend2.addTo(map);

            map.addLayer(layers["CP02"])
            activeLayer = "CP02"
            sl2on.disabled = false;
        } else {
            map.removeControl(legend2);
            map.removeLayer(layers["CP02"])
            sl2on.disabled = true;
        }
    });
    sl2on.addEventListener("input", (event) => {
        layers["CP02"].setOpacity(event.target.value / 100);
    });

    ch3on.addEventListener("change", () => {
        if (ch3on.checked) {
            legend3=crearLeyenda('erodabilidad');
            try {
                map.removeControl(legend3);
            } catch (error) {
                console.error("Se produjo un error al quitar la leyenda:", error);
            }
            legend3.addTo(map);
            map.addLayer(layers["CP03"])
            activeLayer = "CP03"
            sl3on.disabled = false;
        } else {
            map.removeControl(legend3);
            map.removeLayer(layers["CP03"])
            sl3on.disabled = true;
        }
    });
    sl3on.addEventListener("input", (event) => {
        layers["CP03"].setOpacity(event.target.value / 100);
    });

    ch4on.addEventListener("change", () => {
        if (ch4on.checked) {
            legend4=crearLeyenda('pendiente');
            try {
                map.removeControl(legend4);
            } catch (error) {
                console.error("Se produjo un error al quitar la leyenda:", error);
            }
            legend4.addTo(map);
            map.addLayer(layers["CP04"])
            activeLayer = "CP04"
            sl4on.disabled = false;
        } else {
            map.removeControl(legend4);
            map.removeLayer(layers["CP04"])
            sl4on.disabled = true;
        }
    });
    sl4on.addEventListener("input", (event) => {
        layers["CP04"].setOpacity(event.target.value / 100);
    });

    ch5on.addEventListener("change", () => {
        if (ch5on.checked) {
            legend5=crearLeyenda('erosividad');
            try {
                map.removeControl(legend5);
            } catch (error) {
                console.error("Se produjo un error al quitar la leyenda:", error);
            }
            legend5.addTo(map);
            map.addLayer(layers["CP05"])
            activeLayer = "CP05"
            sl5on.disabled = false;
        } else {
            map.removeControl(legend5);
            map.removeLayer(layers["CP05"])
            sl5on.disabled = true;
        }
    });
    sl5on.addEventListener("input", (event) => {
        layers["CP05"].setOpacity(event.target.value / 100);
    });

    ch6on.addEventListener("change", () => {
        
        if (ch6on.checked) {

            if (legend6) {
                try {
                    map.removeControl(legend6);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            }

            legend6 = crearLeyenda('tiempo_termico');
            legend6.addTo(map);
            map.addLayer(layers["CP06"])
            activeLayer = "CP06"
            sl6on.disabled = false;
        } else {
            map.removeControl(legend6);
            map.removeLayer(layers["CP06"])
            sl6on.disabled = true;
        }
    });
    sl6on.addEventListener("input", (event) => {
        layers["CP06"].setOpacity(event.target.value / 100);
    });

    ch7on.addEventListener("change", () => {
        if (ch7on.checked) {
            
            if (legend6) {
                try {
                    map.removeControl(legend6);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            }

            legend6 = crearLeyenda('tiempo_termico');
            legend6.addTo(map);
            map.addLayer(layers["CP07"])
            activeLayer = "CP07"
            sl7on.disabled = false;
        } else {
            map.removeControl(legend6);
            map.removeLayer(layers["CP07"])
            sl7on.disabled = true;
        }
    });
    sl7on.addEventListener("input", (event) => {
        layers["CP07"].setOpacity(event.target.value / 100);
    });

    ch8on.addEventListener("change", () => {
        if (ch8on.checked) {
            
            if (legend6) {
                try {
                    map.removeControl(legend6);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            }

            legend6 = crearLeyenda('tiempo_termico');
            legend6.addTo(map);
            map.addLayer(layers["CP08"])
            activeLayer = "CP08"
            sl8on.disabled = false;
        } else {
            map.removeControl(legend6);
            map.removeLayer(layers["CP08"])
            sl8on.disabled = true;
        }
    });
    sl8on.addEventListener("input", (event) => {
        layers["CP08"].setOpacity(event.target.value / 100);
    });

    ch9on.addEventListener("change", () => {
        if (ch9on.checked) {
            
            if (legend6) {
                try {
                    map.removeControl(legend6);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            }

            legend6 = crearLeyenda('tiempo_termico');
            legend6.addTo(map);
            map.addLayer(layers["CP09"])
            activeLayer = "CP09"
            sl9on.disabled = false;
        } else {
            map.removeControl(legend6);
            map.removeLayer(layers["CP09"])
            sl9on.disabled = true;
        }
    });
    sl9on.addEventListener("input", (event) => {
        layers["CP09"].setOpacity(event.target.value / 100);
    });

    ch10on.addEventListener("change", () => {
        if (ch10on.checked) {
            if (legend6) {
                try {
                    map.removeControl(legend6);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            }

            legend6 = crearLeyenda('tiempo_termico');
            legend6.addTo(map);
            map.addLayer(layers["CP10"])
            activeLayer = "CP10"
            sl10on.disabled = false;
        } else {
            map.removeControl(legend6);
            map.removeLayer(layers["CP10"])
            sl10on.disabled = true;
        }
    });
    sl10on.addEventListener("input", (event) => {
        layers["CP10"].setOpacity(event.target.value / 100);
    });

    ch11on.addEventListener("change", () => {
        if (ch11on.checked) {
            if (legend6) {
                try {
                    map.removeControl(legend6);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            }

            legend6 = crearLeyenda('tiempo_termico');
            legend6.addTo(map);
            map.addLayer(layers["CP11"])
            activeLayer = "CP11"
            sl11on.disabled = false;
        } else {
            map.removeControl(legend6);
            map.removeLayer(layers["CP11"])
            sl11on.disabled = true;
        }
    });
    sl11on.addEventListener("input", (event) => {
        layers["CP11"].setOpacity(event.target.value / 100);
    });

    ch12on.addEventListener("change", () => {
        if (ch12on.checked) {
            if (legend6) {
                try {
                    map.removeControl(legend6);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            }

            legend6 = crearLeyenda('tiempo_termico');
            legend6.addTo(map);
            map.addLayer(layers["CP12"])
            activeLayer = "CP12"
            sl12on.disabled = false;
        } else {
            map.removeControl(legend6);
            map.removeLayer(layers["CP12"])
            sl12on.disabled = true;
        }
    });
    sl12on.addEventListener("input", (event) => {
        layers["CP12"].setOpacity(event.target.value / 100);
    });

    ch13on.addEventListener("change", () => {
        if (ch13on.checked) {
            if (legend6) {
                try {
                    map.removeControl(legend6);
                } catch (error) {
                    console.error("Se produjo un error al quitar la leyenda:", error);
                }
            }

            legend6 = crearLeyenda('tiempo_termico');
            legend6.addTo(map);
            map.addLayer(layers["CP13"])
            activeLayer = "CP13"
            sl13on.disabled = false;
        } else {
            map.removeControl(legend6);
            map.removeLayer(layers["CP13"])
            sl13on.disabled = true;
        }
    });
    sl13on.addEventListener("input", (event) => {
        layers["CP13"].setOpacity(event.target.value / 100);
    });

    ch14on.addEventListener("change", () => {
        if (ch14on.checked) {
            Marcadores('../Content/imagenes/Cebolla/Huellahidrica/HuellaHidrica.json'); 
        } else {
            eliminarElementos();
        }
    });
    
});

cargarCapas();

function invalidar() {
    map.invalidateSize();
    try {
        map.addLayer(layers["CP1A"]);
        $('#load').hide();
    }
    catch (error){
        
    }
    setTimeout(invalidar, 100);
}

//Poner intervalo de refresco del mapa
setTimeout(invalidar, 100);