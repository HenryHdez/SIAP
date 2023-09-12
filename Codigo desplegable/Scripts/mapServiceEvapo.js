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
var intera = -382.5;
var pend = 6.375;
var coef = 0.3;

var url_to_geotiff_file = [{ name: "CP01", url: '../Content/imagenes/Evapotranspiracion/Eto_01_ENE_geo.tif', index: 1, noData: -3.4028234663852886e+38 },
                           { name: "CP02", url: '../Content/imagenes/Evapotranspiracion/Eto_02_FEB_geo.tif', index: 2, noData: -3.4028234663852886e+38 },
                           { name: "CP03", url: '../Content/imagenes/Evapotranspiracion/Eto_03_MAR_geo.tif', index: 3, noData: -3.4028234663852886e+38 },
                           { name: "CP04", url: '../Content/imagenes/Evapotranspiracion/Eto_04_ABR_geo.tif', index: 4, noData: -3.4028234663852886e+38 },
                           { name: "CP05", url: '../Content/imagenes/Evapotranspiracion/Eto_05_MAY_geo.tif', index: 5, noData: -3.4028234663852886e+38 },
                           { name: "CP06", url: '../Content/imagenes/Evapotranspiracion/Eto_06_JUN_geo.tif', index: 6, noData: -3.4028234663852886e+38 },
                           { name: "CP07", url: '../Content/imagenes/Evapotranspiracion/Eto_07_JUL_geo.tif', index: 7, noData: -3.4028234663852886e+38 },
                           { name: "CP08", url: '../Content/imagenes/Evapotranspiracion/Eto_08_AGO_geo.tif', index: 8, noData: -3.4028234663852886e+38 },
                           { name: "CP09", url: '../Content/imagenes/Evapotranspiracion/Eto_09_SEP_geo.tif', index: 9, noData: -3.4028234663852886e+38 },
                           { name: "CP10", url: '../Content/imagenes/Evapotranspiracion/Eto_10_OCT_geo.tif', index: 10, noData: -3.4028234663852886e+38 },
                           { name: "CP11", url: '../Content/imagenes/Evapotranspiracion/Eto_11_NOV_geo.tif', index: 11, noData: -3.4028234663852886e+38 },
                           { name: "CP12", url: '../Content/imagenes/Evapotranspiracion/Eto_12_DIC_geo.tif', index: 12, noData: -3.4028234663852886e+38 },
                           { name: "CP13", url: '../Content/imagenes/Evapotranspiracion/Eto_13_DEF_geo.tif', index: 13, noData: -3.4028234663852886e+38 },
                           { name: "CP14", url: '../Content/imagenes/Evapotranspiracion/Eto_14_MAM_geo.tif', index: 14, noData: -3.4028234663852886e+38 },
                           { name: "CP15", url: '../Content/imagenes/Evapotranspiracion/Eto_15_JJA_geo.tif', index: 15, noData: -3.4028234663852886e+38 },
                           { name: "CP16", url: '../Content/imagenes/Evapotranspiracion/Eto_16_SON_geo.tif', index: 16, noData: -3.4028234663852886e+38 },
                           { name: "CP17", url: '../Content/imagenes/Evapotranspiracion/Eto_17_ANU_geo.tif', index: 17, noData: -3.4028234663852886e+38 },
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
function leyenda(op) {

    if (op == 0) {
        intera = -382.5;
        pend = 6.375;
        legend1.onAdd = function (map) {
            var div = L.DomUtil.create('div', 'info legend');
            div.innerHTML = '<div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px; font-size: 14px;"><b>Leyenda <br><i>mm</i></b></div>'+
                '<div style="display: flex;"><div><img src="../Content/imagenes/Escala/Evapo.png" height="140px" width="40px"/></div> <div style = "font-size: 14px;background-color: rgb(255, 255,255); width:80px; text-align:left;"> 100 <br> <br>  <br>  <br>  <br> <br>60</div></div>';
            return div;
        };
        legend1.addTo(map);
        ff1 = 1;
    }
    else if (op == 1) {
        intera = -696.7605634;
        pend = 3.591549296;
        legend2.onAdd = function (map) {
            var div = L.DomUtil.create('div', 'info legend');
            div.innerHTML = '<div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px; font-size: 14px;"><b>Leyenda <br><i>mm</i></b></div>'+
                '<div style="display: flex;"><div><img src="../Content/imagenes/Escala/Evapo.png" height="140px" width="40px"/></div> <div style = "font-size: 14px;background-color: rgb(255, 255,255); width:80px; text-align:left;"> 287 <br> <br>  <br>  <br>  <br> <br>188</div></div>';
            return div;
        };
        legend2.addTo(map);
        ff2 = 1;
    }
    else {
        intera = -760.3636364;
        pend = 0.927272727;
        legend3.onAdd = function (map) {
            var div = L.DomUtil.create('div', 'info legend');
            div.innerHTML = '<div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px; font-size: 14px;"><b>Leyenda <br><i>mm</i></b></div>'+
                '<div style="display: flex;"><div><img src="../Content/imagenes/Escala/Evapo.png" height="120px" width="40px"/></div> <div style = "font-size: 14px;background-color: rgb(255, 255,255); width:80px; text-align:left;"> 1095 <br> <br>  <br>  <br>  <br>820</div></div>';
            return div;
        };
        legend3.addTo(map);
        ff3 = 1;
    }
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
              var color = [0, 0, 0];
              function convertToRgb(pixelValue) {
                  var red, green, blue, alpha;
                  if (data.name != "CP1A") {
                      if (pixelValue > 0) {
                          pixelValue = (pixelValue - min) / range;
                          pixelValue = pixelValue * 100;
                          let normalizedValue = pixelValue;
                          
                          if (normalizedValue < 5) { color = [11, 44, 122]; normalizedValue = normalizedValue/5; }
                          else if (normalizedValue >= 5 && normalizedValue < 12.5) { color = [23, 117, 142]; normalizedValue = normalizedValue / 12.55; }
                          else if (normalizedValue >= 12.5 && normalizedValue < 25) { color = [27, 170, 125]; normalizedValue = normalizedValue / 25; }
                          else if (normalizedValue >= 25 && normalizedValue < 37.5) { color = [6, 211, 29]; normalizedValue = normalizedValue / 37.5; }
                          else if (normalizedValue >= 37.5 && normalizedValue < 50) { color = [119, 237, 0]; normalizedValue = normalizedValue / 50; }
                          else if (normalizedValue >= 50 && normalizedValue < 62.5) { color = [253, 242, 3]; normalizedValue = normalizedValue / 62.5; }
                          else if (normalizedValue >= 62.5 && normalizedValue < 75) { color = [242, 182, 15]; normalizedValue = normalizedValue / 75; }
                          else if (normalizedValue >= 75 && normalizedValue < 87.5) { color = [221, 123, 37]; normalizedValue = normalizedValue / 87.5; }
                          else { color = [194, 82, 60]; normalizedValue = normalizedValue / 100;}
                          red = color[0] * (normalizedValue);
                          green = color[1] * (normalizedValue);
                          blue = color[2] * (normalizedValue);
                          alpha = 1;
                      }
                      else {
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

function Eliminar_rot() {
    ff1 = 0;
    ff2 = 0;
    ff3 = 0;
    map.removeControl(legend1);
    map.removeControl(legend2);
    map.removeControl(legend3);
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
    map.removeLayer(layers["CP13"]);
    map.removeLayer(layers["CP14"]);
    map.removeLayer(layers["CP15"]);
    map.removeLayer(layers["CP16"]);
    map.removeLayer(layers["CP17"]);
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
    ch13on.checked = false;
    ch14on.checked = false;
    ch15on.checked = false;
    ch16on.checked = false;
    ch17on.checked = false;
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
    sl13on.disabled = true;
    sl14on.disabled = true;
    sl15on.disabled = true;
    sl16on.disabled = true;
    sl17on.disabled = true;
}

function Deshabilitar() {
    document.getElementById('lis_mapa1').style.display = "none";
    document.getElementById('lis_mapa2').style.display = "none";
}

function habilitar() {
    document.getElementById('lis_mapa1').style.display = "block";
    document.getElementById('lis_mapa2').style.display = "block";
}

//Función para agregar los oyentes
document.addEventListener('DOMContentLoaded', () => {


    ch1on.addEventListener("change", () => {
        if (ch1on.checked) {
            coef = 0.3;
            leyenda(0)
            map.addLayer(layers["CP01"])
            activeLayer = "CP01"
            sl1on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP01"]);
            sl1on.disabled = true;
        }
    });
    sl1on.addEventListener("input", (event) => {
        layers["CP01"].setOpacity(event.target.value / 100);
    });

    ch2on.addEventListener("change", () => {
        if (ch2on.checked) {
            coef = 0.3;
            leyenda(0)
            map.addLayer(layers["CP02"])
            activeLayer = "CP02"
            sl2on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP02"])
            sl2on.disabled = true;
        }
    });
    sl2on.addEventListener("input", (event) => {
        layers["CP02"].setOpacity(event.target.value / 100);
    });

    ch3on.addEventListener("change", () => {
        if (ch3on.checked) {
            leyenda(0)
            map.addLayer(layers["CP03"])
            activeLayer = "CP03"
            sl3on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP03"])
            sl3on.disabled = true;
        }
    });
    sl3on.addEventListener("input", (event) => {
        layers["CP03"].setOpacity(event.target.value / 100);
    });

    ch4on.addEventListener("change", () => {
        if (ch4on.checked) {
            leyenda(0)
            map.addLayer(layers["CP04"])
            activeLayer = "CP04"
            sl4on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP04"])
            sl4on.disabled = true;
        }
    });
    sl4on.addEventListener("input", (event) => {
        layers["CP04"].setOpacity(event.target.value / 100);
    });

    ch5on.addEventListener("change", () => {
        if (ch5on.checked) {
            leyenda(0)
            map.addLayer(layers["CP05"])
            activeLayer = "CP05"
            sl5on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP05"])
            sl5on.disabled = true;
        }
    });
    sl5on.addEventListener("input", (event) => {
        layers["CP05"].setOpacity(event.target.value / 100);
    });

    ch6on.addEventListener("change", () => {
        if (ch6on.checked) {
            leyenda(0)
            map.addLayer(layers["CP06"])
            activeLayer = "CP06"
            sl6on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP06"])
            sl6on.disabled = true;
        }
    });
    sl6on.addEventListener("input", (event) => {
        layers["CP06"].setOpacity(event.target.value / 100);
    });

    ch7on.addEventListener("change", () => {
        if (ch7on.checked) {
            leyenda(0)
            map.addLayer(layers["CP07"])
            activeLayer = "CP07"
            sl7on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP07"])
            sl7on.disabled = true;
        }
    });
    sl7on.addEventListener("input", (event) => {
        layers["CP07"].setOpacity(event.target.value / 100);
    });

    ch8on.addEventListener("change", () => {
        if (ch8on.checked) {
            leyenda(0)
            map.addLayer(layers["CP08"])
            activeLayer = "CP08"
            sl8on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP08"])
            sl8on.disabled = true;
        }
    });
    sl8on.addEventListener("input", (event) => {
        layers["CP08"].setOpacity(event.target.value / 100);
    });

    ch9on.addEventListener("change", () => {
        if (ch9on.checked) {
            leyenda(0)
            map.addLayer(layers["CP09"])
            activeLayer = "CP09"
            sl9on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP09"])
            sl9on.disabled = true;
        }
    });
    sl9on.addEventListener("input", (event) => {
        layers["CP09"].setOpacity(event.target.value / 100);
    });

    ch10on.addEventListener("change", () => {
        if (ch10on.checked) {
            leyenda(0)
            map.addLayer(layers["CP10"])
            activeLayer = "CP10"
            sl10on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP10"])
            sl10on.disabled = true;
        }
    });
    sl10on.addEventListener("input", (event) => {
        layers["CP10"].setOpacity(event.target.value / 100);
    });

    ch11on.addEventListener("change", () => {
        if (ch11on.checked) {
            leyenda(0)
            map.addLayer(layers["CP11"])
            activeLayer = "CP11"
            sl11on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP11"])
            sl11on.disabled = true;
        }
    });
    sl11on.addEventListener("input", (event) => {
        layers["CP11"].setOpacity(event.target.value / 100);
    });

    ch12on.addEventListener("change", () => {
        if (ch12on.checked) {
            leyenda(0)
            map.addLayer(layers["CP12"])
            activeLayer = "CP12"
            sl12on.disabled = false;
        } else {
            elminaley(0)
            map.removeLayer(layers["CP12"])
            sl12on.disabled = true;
        }
    });
    sl12on.addEventListener("input", (event) => {
        layers["CP12"].setOpacity(event.target.value / 100);
    });

    ch13on.addEventListener("change", () => {
        if (ch13on.checked) {
            leyenda(1)
            map.addLayer(layers["CP13"])
            activeLayer = "CP13"
            sl13on.disabled = false;
        } else {
            elminaley(1)
            map.removeLayer(layers["CP13"])
            sl13on.disabled = true;
        }
    });
    sl13on.addEventListener("input", (event) => {
        layers["CP13"].setOpacity(event.target.value / 100);
    });

    ch14on.addEventListener("change", () => {
        if (ch14on.checked) {
            leyenda(1)
            map.addLayer(layers["CP14"])
            activeLayer = "CP14"
            sl14on.disabled = false;
        } else {
            elminaley(1)
            map.removeLayer(layers["CP14"])
            sl14on.disabled = true;
        }
    });
    sl14on.addEventListener("input", (event) => {
        layers["CP14"].setOpacity(event.target.value / 100);
    });

    ch15on.addEventListener("change", () => {
        if (ch15on.checked) {
            leyenda(1)
            map.addLayer(layers["CP15"])
            activeLayer = "CP15"
            sl15on.disabled = false;
        } else {
            elminaley(1)
            map.removeLayer(layers["CP15"])
            sl15on.disabled = true;
        }
    });
    sl15on.addEventListener("input", (event) => {
        layers["CP15"].setOpacity(event.target.value / 100);
    });

    ch16on.addEventListener("change", () => {
        if (ch16on.checked) {
            leyenda(1)
            map.addLayer(layers["CP16"])
            activeLayer = "CP16"
            sl16on.disabled = false;
        } else {
            elminaley(1)
            map.removeLayer(layers["CP16"])
            sl16on.disabled = true;
        }
    });
    sl16on.addEventListener("input", (event) => {
        layers["CP16"].setOpacity(event.target.value / 100);
    });

    ch17on.addEventListener("change", () => {
        if (ch17on.checked) {
            leyenda(2)
            map.addLayer(layers["CP17"])
            activeLayer = "CP17"
            sl17on.disabled = false;
        } else {
            elminaley(2)
            map.removeLayer(layers["CP17"])
            sl17on.disabled = true;
        }
    });
    sl17on.addEventListener("input", (event) => {
        layers["CP17"].setOpacity(event.target.value / 100);
    });

});

function invalidar() {
    map.invalidateSize();
    setTimeout(invalidar, 100);
}

//Poner intervalo de refresco del mapa
setTimeout(invalidar, 100);

var contayy = 0;
function habilitar_mapa(capa, rotulo, barrasld) {
    var conta_espera = 0;

    try {
        leyenda(rotulo);
        //console.log('1');
        map.addLayer(layers[capa]);
        //console.log(contayy);
        activeLayer = capa;
        barrasld.disabled = false;
        contayy += 1;
    } catch (error) {
        contayy = 0;
        contaww = 0;
        //console.log('0');
        ch1on.checked = false;
        //elminaley(rotulo);
        //map.removeLayer(layers[capa]);
        barrasld.disabled = true;
    }
    conta_espera += 1;
    console.log('Espere');


}

var contaww = 1;

function invalidar2() {
    if (contaww == 1) { habilitar_mapa("CP01", 0, sl1on); };
    if (contaww == 2) { habilitar_mapa("CP02", 0, sl2on); };
    if (contaww == 3) { habilitar_mapa("CP03", 0, sl3on); };
    if (contaww == 4) { habilitar_mapa("CP04", 0, sl4on); };
    if (contaww == 5) { habilitar_mapa("CP05", 0, sl5on); };
    if (contaww == 6) { habilitar_mapa("CP06", 0, sl6on); };
    if (contaww == 7) { habilitar_mapa("CP07", 0, sl7on); };
    if (contaww == 8) { habilitar_mapa("CP08", 0, sl8on); };
    if (contaww == 9) { habilitar_mapa("CP09", 0, sl9on); };
    if (contaww == 10) { habilitar_mapa("CP10", 0, sl10on); };
    if (contaww == 11) { habilitar_mapa("CP11", 0, sl11on); };
    if (contaww == 12) { habilitar_mapa("CP12", 0, sl12on); };
    if (contaww == 13) { habilitar_mapa("CP13", 1, sl13on); };
    if (contaww == 14) { habilitar_mapa("CP14", 1, sl14on); };
    if (contaww == 15) { habilitar_mapa("CP15", 1, sl15on); };
    if (contaww == 16) { habilitar_mapa("CP16", 1, sl16on); };
    if (contaww == 17) { habilitar_mapa("CP17", 2, sl17on); };
    if (contaww == 18) {
        try {
            map.addLayer(layers["CP1A"]);
        } catch (error) {
        }
        contaww = 0;
    };

    if (contayy != 20) {
        setTimeout(invalidar2, 150);
    } else {
        Eliminar_rot();
        $('#load').hide();
    }
    contaww += 1

}

//Poner intervalo de refresco del mapa
setTimeout(invalidar2, 150);