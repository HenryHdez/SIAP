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
const ch15on = document.getElementById('ch15');
const sl15on = document.getElementById('sl15');
const ch16on = document.getElementById('ch16');
const sl16on = document.getElementById('sl16');
const ch17on = document.getElementById('ch17');
const sl17on = document.getElementById('sl17');
const homebtn = document.getElementById('homebtn');

var osm = L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 15, attribution: '© OpenStreetMap' });

const mbAttr = 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>';
const mbUrl = 'https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw';

var streets = L.tileLayer(mbUrl, { id: 'mapbox/streets-v11', tileSize: 512, zoomOffset: -1, attribution: mbAttr });
const satellite = L.tileLayer(mbUrl, { id: 'mapbox/satellite-v9', tileSize: 512, zoomOffset: -1, attribution: mbAttr });
var map = L.map('mapBox', { center: [4.84, -74.26], zoom: 10.50, layers: [osm] });

const baseLayers = {
    'OpenStreetMap': osm,
    'Streets': streets,
    'Satellite': satellite
};

var popup = L.popup();
var layers = {};
var countLayers = 0;
var activeLayer = "";
var legend1 = L.control({ position: 'topright' });
var legend2 = L.control({ position: 'topright' });
var legend3 = L.control({ position: 'topright' });
var ff1 = 0;
var ff2 = 0;
var ff3 = 0;
var intera = -754.8;
var pend = 10.2;

var url_to_geotiff_file = [{ name: "CP01", url: '../Content/imagenes/Neutro/PPT_NEUTRO_DJF_geo.tif', index: 1, noData: -3.4028234663852886e+38 },
                           { name: "CP02", url: '../Content/imagenes/Neutro/PPT_NEUTRO_JJA_geo.tif', index: 2, noData: -3.4028234663852886e+38 },
                           { name: "CP03", url: '../Content/imagenes/Neutro/PPT_NEUTRO_MAM_geo.tif', index: 3, noData: -3.4028234663852886e+38 },
                           { name: "CP04", url: '../Content/imagenes/Neutro/PPT_NEUTRO_SON_geo.tif', index: 4, noData: -3.4028234663852886e+38 },
                           { name: "CP05", url: '../Content/imagenes/Nina/PPT_NINA_DJF_geo.tif', index: 5, noData: -3.4028234663852886e+38 },
                           { name: "CP06", url: '../Content/imagenes/Nina/PPT_NINA_JJA_geo.tif', index: 6, noData: -3.4028234663852886e+38 },
                           { name: "CP07", url: '../Content/imagenes/Nina/PPT_NINA_MAM_geo.tif', index: 7, noData: -3.4028234663852886e+38 },
                           { name: "CP08", url: '../Content/imagenes/Nina/PPT_NINA_SON_geo.tif', index: 8, noData: -3.4028234663852886e+38 },
                           { name: "CP09", url: '../Content/imagenes/Nino/PPT_NINO_DJF_geo.tif', index: 9, noData: -3.4028234663852886e+38 },
                           { name: "CP10", url: '../Content/imagenes/Nino/PPT_NINO_JJA_geo.tif', index: 10, noData: -3.4028234663852886e+38 },
                           { name: "CP11", url: '../Content/imagenes/Nino/PPT_NINO_MAM_geo.tif', index: 11, noData: -3.4028234663852886e+38 },
                           { name: "CP12", url: '../Content/imagenes/Nino/PPT_NINO_SON_geo.tif', index: 12, noData: -3.4028234663852886e+38 },
                           { name: "CP1A", url: '../Content/imagenes/Area_estudio_SIAP.TIF', index: 18, noData: -3.4028234663852886e+38 }
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

function Maradores(ubicacion) {

    // Icon options
    var iconOptions1 = {
        iconUrl: '../Content/imagenes/equis.png',
        iconSize: [15, 15]
    }
    var customIcon1 = L.icon(iconOptions1);

    // Icon options
    var iconOptions2 = {
        iconUrl: '../Content/imagenes/cruz.png',
        iconSize: [20, 20]
    }
    var customIcon2 = L.icon(iconOptions2);

    // Icon options
    var iconOptions3 = {
        iconUrl: '../Content/imagenes/star.png',
        iconSize: [20, 20]
    }
    var customIcon3 = L.icon(iconOptions3);

    var redMarker = {
        clickable: true,
        draggable: true,
        icon: customIcon3
    };

    var greenMarker = {
        clickable: true,
        draggable: true,
        icon: customIcon2
    };

    var yellMarker = {
        clickable: true,
        draggable: true,
        icon: customIcon1
    };

    var geojsonLayer = new L.GeoJSON.AJAX(ubicacion, {
                style: function (feature) {
                    var CHI = feature.properties.Chi_Cuadra;
                    var lat1 = feature.properties.NORTE;
                    var lon1 = feature.properties.ESTE;
                    var pos1 = [lat1, lon1];
                    var nome = feature.properties.Nombre_Est + "<br> Coor.= " + pos1.toString() + "<br> Chi= " + CHI.toString();
                    if (CHI < 0.05) {
                        L.marker(pos1, redMarker).addTo(map).bindPopup(nome);
                    }
                    else if (CHI > 0.05 && CHI < 0.1) {
                        L.marker(pos1, greenMarker).addTo(map).bindPopup(nome);
                    }
                    else {
                        L.marker(pos1, yellMarker).addTo(map).bindPopup(nome);
                    }
                }
            }
        );
}

function leyenda() {
    legend1.onAdd = function (map) {
        var div = L.DomUtil.create('div', 'info legend');
        div.innerHTML = '<div style = "font-size: 12px;background-color: rgb(255, 255,255); width:140px; font-size: 14px;"><b>Leyenda</b></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(255,0,0); width: 20px; height: 20px;"></div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;">Debajo [Muy alta]</div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(255,132,0); width: 20px; height: 20px;"></div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;">Debajo [Alta]</div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(255,225,0); width: 20px; height: 20px;"></div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;">Debajo [Moderada]</div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(218,255,97); width: 20px; height: 20px;"></div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;">Debajo [Baja]</div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(138,255,190); width: 20px; height: 20px;"></div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;">Encima [Baja]</div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(41,219,255); width: 20px; height: 20px;"></div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;">Encima [Moderada]</div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(56,116,255); width: 20px; height: 20px;"></div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;">Encima [Alta]</div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(0,0,255); width: 20px; height: 20px;"></div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;">Encima [Muy alta]</div></div>' +
                        '<div style = "font-size: 12px;background-color: rgb(255, 255,255); width:140px; font-size: 14px;"><b>Chi square test (p-value)</b></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(255,255,255); width: 20px; height: 20px; font-size: 20px; color:RGB(0,143,57)"> &#9733; </div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;"> &#60; 0.05 </div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(255,255,255); width: 20px; height: 20px; font-size: 20px; color:RGB(0,143,57)"> + </div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;"> &#60; 0.1 </div></div>' +
                        '<div style="display: flex;"><div style="background-color: rgb(255,225,255); width: 20px; height: 20px; font-size: 18px; "> x </div> <div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px;"> &#62; 0.1 </div></div>';
        return div;
    };
    legend1.addTo(map);
}

url_to_geotiff_file.forEach(data=> {
    fetch(data.url).
      then(response => response.arrayBuffer()).
      then(arrayBuffer => {
          parseGeoraster(arrayBuffer).then(georaster => {
              const min = georaster.mins[0];
              const max = georaster.maxs[0];
              const range = georaster.ranges[0];
              const noData = georaster.noDataValue;
              function convertToRgb(pixelValue) {
                  var red, green, blue, alpha;
                  if (data.name != "CP1A") {
                      if (pixelValue > -1000) {
                          var normalizedValue = ((pixelValue - min) / range);
                          alpha = 1;

                          if (pixelValue < -80) {
                              red = 255;
                              green = 0;
                              blue = 0;
                          }
                          else if (pixelValue >= -80 && pixelValue < -40) {
                              red = 255;
                              green = 132;
                              blue = 0;
                          }
                          else if (pixelValue >= -40 && pixelValue < -20) {
                              red = 255;
                              green = 225;
                              blue = 0;
                          }
                          else if (pixelValue >= -20 && pixelValue < 0) {
                              red = 218;
                              green = 255;
                              blue = 97;
                          }
                          else if (pixelValue >= 0 && pixelValue < 20) {
                              red = 138;
                              green = 255;
                              blue = 190;
                          }
                          else if (pixelValue >= 20 && pixelValue < 40) {
                              red = 41;
                              green = 219;
                              blue = 255;
                          }
                          else if (pixelValue >= 40 && pixelValue < 80) {
                              red = 56;
                              green = 116;
                              blue = 255;
                          }
                          else {
                              red = 0;
                              green = 0;
                              blue = 255;
                          }
                      } else {
                          red = parseInt(255);
                          green = parseInt(255);
                          blue = parseInt(255);
                          alpha = 0
                      }
                  }
                  else {
                      if (pixelValue > 0) {
                          // const normalizedValue = 255*((pixelValue-min) / range);
                          const normalizedValue = (pend * pixelValue) + intera;
                          alpha = 0.07;
                          red = parseInt(0);
                          green = parseInt(0);
                          blue = parseInt(0);
                      } else {
                          red = parseInt(0);
                          green = parseInt(0);
                          blue = parseInt(0);
                          alpha = 0
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
                  var latlng = map.mouseEventToLatLng(evt.originalEvent);
                  if (data.name == activeLayer) {
                      var value = geoblaze.identify(georaster, [latlng.lng, latlng.lat])[0]
                      value = value.toFixed(3)

                      if (value != noData) {
                          popup
                          .setLatLng(evt.latlng)
                          .setContent(value.toString())
                          .openOn(map);
                      }
                  }
              })
          })
      })
})

var printer = L.easyPrint({
    tileLayer: streets,
    sizeModes: ['Current', 'A4Landscape', 'A4Portrait'],
    filename: 'myMap',
    exportOnly: true,
    hideControlContainer: true
}).addTo(map);


function manualPrint() {
    printer.printMap('CurrentSize', 'MyManualPrint')
}

function Casa_Func() {
    map.setView([4.84, -74.26], 10.50);
}

function Deshabilitar() {
    document.getElementById('lis_mapa1').style.display = "none";
    document.getElementById('lis_mapa2').style.display = "none";
}

function habilitar() {
    document.getElementById('lis_mapa1').style.display = "block";
    document.getElementById('lis_mapa2').style.display = "block";
}

function Controlar_rot() {
    if (!(ch1on.checked) && !(ch2on.checked) && !(ch3on.checked) && !(ch4on.checked) && !(ch5on.checked) &&
        !(ch6on.checked) && !(ch7on.checked) && !(ch8on.checked) && !(ch9on.checked) && !(ch10on.checked) &&
        !(ch11on.checked) && !(ch12on.checked)) {
        Eliminar_rot();
    }
}

function Eliminar_rot2() {
    $(".leaflet-marker-icon").remove();
    $(".leaflet-marker-shadow").remove();
    $(".leaflet-popup").remove();
}

function Eliminar_rot() {
    $(".leaflet-marker-icon").remove();
    $(".leaflet-marker-shadow").remove();
    $(".leaflet-popup").remove();
    map.removeLayer(layers["CP01"]);
    map.removeLayer(layers["CP02"]);
    map.removeLayer(layers["CP03"]);
    map.removeLayer(layers["CP04"]);
    map.removeLayer(layers["CP05"]);
    map.removeLayer(layers["CP06"]);
    map.removeLayer(layers["CP07"]);
    map.removeLayer(layers["CP08"]);
    map.removeLayer(layers["CP09"]);
    map.removeLayer(layers["CP10"]);
    map.removeLayer(layers["CP11"]);
    map.removeLayer(layers["CP12"]);
    ch1on.checked = false;
    ch2on.checked = false;
    ch3on.checked = false;
    ch4on.checked = false;
    ch5on.checked = false;
    ch6on.checked = false;
    ch7on.checked = false;
    ch8on.checked = false;
    ch9on.checked = false;
    ch10on.checked = false;
    ch11on.checked = false;
    ch12on.checked = false;
    sl1on.disabled = true;
    sl2on.disabled = true;
    sl3on.disabled = true;
    sl4on.disabled = true;
    sl5on.disabled = true;
    sl6on.disabled = true;
    sl7on.disabled = true;
    sl8on.disabled = true;
    sl9on.disabled = true;
    sl10on.disabled = true;
    sl11on.disabled = true;
    sl12on.disabled = true;
}
//Función para agregar los oyentes
document.addEventListener('DOMContentLoaded', () => {

    ch1on.addEventListener("change", () => {
        if (ch1on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP01"])
            activeLayer = "CP01"
            Maradores('../Content/imagenes/Neutro/PPT_NEUTRO_DJF_geo.json');
            sl1on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP01"]);
            sl1on.disabled = true;
        }
    });
    sl1on.addEventListener("input", (event) => {
        layers["CP01"].setOpacity(event.target.value / 100);
    });

    ch2on.addEventListener("change", () => {
        if (ch2on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP02"])
            activeLayer = "CP02"
            Maradores('../Content/imagenes/Neutro/PPT_NEUTRO_MAM_geo.json');
            sl2on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP02"])
            sl2on.disabled = true;
        }
    });
    sl2on.addEventListener("input", (event) => {
        layers["CP02"].setOpacity(event.target.value / 100);
    });

    ch3on.addEventListener("change", () => {
        if (ch3on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP03"])
            activeLayer = "CP03"
            Maradores('../Content/imagenes/Neutro/PPT_NEUTRO_JJA_geo.json');
            sl3on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP03"])
            sl3on.disabled = true;
        }
    });
    sl3on.addEventListener("input", (event) => {
        layers["CP03"].setOpacity(event.target.value / 100);
    });

    ch4on.addEventListener("change", () => {
        if (ch4on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP04"])
            activeLayer = "CP04"
            Maradores('../Content/imagenes/Neutro/PPT_NEUTRO_SON_geo.json');
            sl4on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP04"])
            sl4on.disabled = true;
        }
    });
    sl4on.addEventListener("input", (event) => {
        layers["CP04"].setOpacity(event.target.value / 100);
    });

    ch5on.addEventListener("change", () => {
        if (ch5on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP05"])
            activeLayer = "CP05"
            Maradores('../Content/imagenes/Nina/PPT_NINA_DJF_geo.json');
            sl5on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP05"])
            sl5on.disabled = true;
        }
    });
    sl5on.addEventListener("input", (event) => {
        layers["CP05"].setOpacity(event.target.value / 100);
    });

    ch6on.addEventListener("change", () => {
        if (ch6on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP06"])
            activeLayer = "CP06"
            Maradores('../Content/imagenes/Nina/PPT_NINA_MAM_geo.json');
            sl6on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP06"])
            sl6on.disabled = true;
        }
    });
    sl6on.addEventListener("input", (event) => {
        layers["CP06"].setOpacity(event.target.value / 100);
    });

    ch7on.addEventListener("change", () => {
        if (ch7on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP07"])
            activeLayer = "CP07"
            Maradores('../Content/imagenes/Nina/PPT_NINA_JJA_geo.json');
            sl7on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP07"])
            sl7on.disabled = true;
        }
    });
    sl7on.addEventListener("input", (event) => {
        layers["CP07"].setOpacity(event.target.value / 100);
    });

    ch8on.addEventListener("change", () => {
        if (ch8on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP08"])
            activeLayer = "CP08"
            Maradores('../Content/imagenes/Nina/PPT_NINA_SON_geo.json');
            sl8on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP08"])
            sl8on.disabled = true;
        }
    });
    sl8on.addEventListener("input", (event) => {
        layers["CP08"].setOpacity(event.target.value / 100);
    });

    ch9on.addEventListener("change", () => {
        if (ch9on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP09"])
            activeLayer = "CP09"
            Maradores('../Content/imagenes/Nino/PPT_NINO_DJF_geo.json');
            sl9on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP09"])
            sl9on.disabled = true;
        }
    });
    sl9on.addEventListener("input", (event) => {
        layers["CP09"].setOpacity(event.target.value / 100);
    });

    ch10on.addEventListener("change", () => {
        if (ch10on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP10"])
            activeLayer = "CP10"
            Maradores('../Content/imagenes/Nino/PPT_NINO_MAM_geo.json');
            sl10on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP10"])
            sl10on.disabled = true;
        }
    });
    sl10on.addEventListener("input", (event) => {
        layers["CP10"].setOpacity(event.target.value / 100);
    });

    ch11on.addEventListener("change", () => {
        if (ch11on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP11"])
            activeLayer = "CP11"
            Maradores('../Content/imagenes/Nino/PPT_NINO_JJA_geo.json');
            sl11on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP11"])
            sl11on.disabled = true;
        }
    });
    sl11on.addEventListener("input", (event) => {
        layers["CP11"].setOpacity(event.target.value / 100);
    });

    ch12on.addEventListener("change", () => {
        if (ch12on.checked) {
            Eliminar_rot2();
            leyenda(0)
            map.addLayer(layers["CP12"])
            activeLayer = "CP12"
            Maradores('../Content/imagenes/Nino/PPT_NINO_SON_geo.json');
            sl12on.disabled = false;
        } else {
            Controlar_rot();
            elminaley(0);
            map.removeLayer(layers["CP12"])
            sl12on.disabled = true;
        }
    });
    sl12on.addEventListener("input", (event) => {
        layers["CP12"].setOpacity(event.target.value / 100);
    });
});

function invalidar() {
    map.invalidateSize();
    setTimeout(invalidar, 200);
}

//Poner intervalo de refresco del mapa
setTimeout(invalidar, 200);


function listo() {
    map.addLayer(layers["CP1A"]);
    $('#load').hide()
}

setTimeout(listo, 30000);

/*$(document).ready(function () { });*/