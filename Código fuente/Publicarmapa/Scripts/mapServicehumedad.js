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
var map = L.map('mapBox', { 
    center: [4.84, -74.26], 
    zoom: 10.50, 
    layers: [osm],
    scrollWheelZoom: false, 
    /*zoomControl: false, 
    doubleClickZoom: false, 
    touchZoom: false,
    boxZoom: false,
    keyboard: false */
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
var legend1 = L.control({ position: 'topright' });
var legend2 = L.control({ position: 'topright' });
var legend3 = L.control({ position: 'topright' });
var ff1 = 0;
var ff2 = 0;
var ff3 = 0;
var intera = -1392.692308;
var pend = 19.61538462;

var url_to_geotiff_file = [{ name: "CP01", url: '../Content/imagenes/Humedad_relativa/HR_01_ENE_geo.tif', index: 1, noData: -3.4028234663852886e+38 },
                           { name: "CP02", url: '../Content/imagenes/Humedad_relativa/HR_02_FEB_geo.tif', index: 2, noData: -3.4028234663852886e+38 },
                           { name: "CP03", url: '../Content/imagenes/Humedad_relativa/HR_03_MAR_geo.tif', index: 3, noData: -3.4028234663852886e+38 },
                           { name: "CP04", url: '../Content/imagenes/Humedad_relativa/HR_04_ABR_geo.tif', index: 4, noData: -3.4028234663852886e+38 },
                           { name: "CP05", url: '../Content/imagenes/Humedad_relativa/HR_05_MAY_geo.tif', index: 5, noData: -3.4028234663852886e+38 },
                           { name: "CP06", url: '../Content/imagenes/Humedad_relativa/HR_06_JUN_geo.tif', index: 6, noData: -3.4028234663852886e+38 },
                           { name: "CP07", url: '../Content/imagenes/Humedad_relativa/HR_07_JUL_geo.tif', index: 7, noData: -3.4028234663852886e+38 },
                           { name: "CP08", url: '../Content/imagenes/Humedad_relativa/HR_08_AGO_geo.tif', index: 8, noData: -3.4028234663852886e+38 },
                           { name: "CP09", url: '../Content/imagenes/Humedad_relativa/HR_09_SEP_geo.tif', index: 9, noData: -3.4028234663852886e+38 },
                           { name: "CP10", url: '../Content/imagenes/Humedad_relativa/HR_10_OCT_geo.tif', index: 10, noData: -3.4028234663852886e+38 },
                           { name: "CP11", url: '../Content/imagenes/Humedad_relativa/HR_11_NOV_geo.tif', index: 11, noData: -3.4028234663852886e+38 },
                           { name: "CP12", url: '../Content/imagenes/Humedad_relativa/HR_12_DIC_geo.tif', index: 12, noData: -3.4028234663852886e+38 },
                           { name: "CP13", url: '../Content/imagenes/Humedad_relativa/HR_13_DEF_geo.tif', index: 13, noData: -3.4028234663852886e+38 },
                           { name: "CP14", url: '../Content/imagenes/Humedad_relativa/HR_14_MAM_geo.tif', index: 14, noData: -3.4028234663852886e+38 },
                           { name: "CP15", url: '../Content/imagenes/Humedad_relativa/HR_15_JJA_geo.tif', index: 15, noData: -3.4028234663852886e+38 },
                           { name: "CP16", url: '../Content/imagenes/Humedad_relativa/HR_16_SON_geo.tif', index: 16, noData: -3.4028234663852886e+38 },
                           { name: "CP17", url: '../Content/imagenes/Humedad_relativa/HR_17_ANU_geo.tif', index: 17, noData: -3.4028234663852886e+38 },
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
   
    legend1.onAdd = function (map) {
        var div = L.DomUtil.create('div', 'info legend');
        div.innerHTML = '<div style = "font-size: 12px;background-color: rgb(255, 255,255); width:120px; font-size: 14px;"><b>Leyenda <br><i>%</i></b></div>'+
            '<div style="display: flex;"><div><img src="../Content/imagenes/Escala/Humed.png" height="140px" width="40px"/></div> <div style = "font-size: 14px;background-color: rgb(255, 255,255); width:80px; text-align:left;"> 87 <br> <br>  <br>  <br>  <br> <br>70</div></div>';
        return div;
    };
    legend1.addTo(map);
}

async function cargarCapas() {
    for (const data of url_to_geotiff_file) {
        try {
            const response = await fetch(data.url);
            const arrayBuffer = await response.arrayBuffer();
            const georaster = await parseGeoraster(arrayBuffer);

            const min = Math.floor(georaster.mins[0]);
            const max = Math.ceil(georaster.maxs[0]);
            const range = georaster.ranges[0];
            const noData = georaster.noDataValue;

            function convertToRgb(pixelValue) {
                var red, green, blue, alpha;
                var color = [0, 0, 0];
                if (data.name != "CP1A") {
                    if (pixelValue > 0) {
                        pixelValue = (pixelValue - min) / range;
                        pixelValue = pixelValue * 100;
                        let normalizedValue = pixelValue;

                        if (normalizedValue < 5) { color = [240, 38, 28]; normalizedValue = normalizedValue / 5; }
                        else if (normalizedValue >= 5 && normalizedValue < 12.5) { color = [247, 112, 48]; normalizedValue = normalizedValue / 12.55; }
                        else if (normalizedValue >= 12.5 && normalizedValue < 25) { color = [247, 162, 72]; normalizedValue = normalizedValue / 25; }
                        else if (normalizedValue >= 25 && normalizedValue < 37.5) { color = [247, 208, 96]; normalizedValue = normalizedValue / 37.5; }
                        else if (normalizedValue >= 37.5 && normalizedValue < 50) { color = [241, 251, 123]; normalizedValue = normalizedValue / 50; }
                        else if (normalizedValue >= 50 && normalizedValue < 62.5) { color = [207, 228, 148]; normalizedValue = normalizedValue / 62.5; }
                        else if (normalizedValue >= 62.5 && normalizedValue < 75) { color = [170, 206, 172]; normalizedValue = normalizedValue / 75; }
                        else if (normalizedValue >= 75 && normalizedValue < 87.5) { color = [127, 183, 192]; normalizedValue = normalizedValue / 87.5; }
                        else { color = [61, 161, 209]; normalizedValue = normalizedValue / 100; }

                        red = color[0] * (normalizedValue);
                        green = color[1] * (normalizedValue);
                        blue = color[2] * (normalizedValue);
                        alpha = 1;
                    } else {
                        red = green = blue = 255;
                        alpha = 0;
                    }
                } else {
                    if (pixelValue > 0) {
                        const normalizedValue = (pend * pixelValue) + intera;
                        alpha = 0.07;
                        red = green = blue = 0;
                    } else {
                        red = green = blue = 0;
                        alpha = 0;
                    }
                }
                return `rgba(${red}, ${green}, ${blue}, ${alpha})`;
            }

            var overlay = new GeoRasterLayer({
                georaster: georaster,
                pixelValuesToColorFn: pixelValues => convertToRgb(pixelValues[0]),
                resolution: 256
            });

            layers[data.name] = overlay;

            map.on('click', function (evt) {
                var latlng = map.mouseEventToLatLng(evt.originalEvent);
                latlng.lat = latlng.lat - 0.031578;
                latlng.lng = latlng.lng + 0.07878;
                if (data.name == activeLayer) {
                    var value = geoblaze.identify(georaster, [latlng.lng, latlng.lat])[0];
                    if (value != georaster.noDataValue) {
                        var dialogTitle = "Información de la capa";
                        var locationInfo = `Latitud: ${latlng.lat.toFixed(5)}, Longitud: ${latlng.lng.toFixed(5)}`;
                        var dialogContent = `<h3>${dialogTitle}</h3>` +
                            `<p><b>Valor:</b> ${value.toFixed(3).toString()} % </p>` +
                            `<p><b>Ubicación:</b> ${locationInfo}</p>`;
                        document.getElementById('modal-body').innerHTML = dialogContent;
                        window.modalmapa.showModal();

                        /*var content = '<div style="font-size:16px;">' + 
                                      'Value: ' + value.toFixed(3).toString() + ' %<br>' + 
                                      'Lat: ' + latlng.lat.toFixed(5) + '<br>' +
                                      'Lng: ' + latlng.lng.toFixed(5) + '</div>';
                        popup
                            .setLatLng(latlng)
                            .setContent(content)
                            .openOn(map);*/
                    }
                }
            });

        } catch (error) {
            console.error('Error al cargar la capa ' + data.name, error);
        }
    }
}

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
    // Resetear banderas de leyenda
    ff1 = 0;
    ff2 = 0;
    ff3 = 0;

    // Eliminar leyendas
    map.removeControl(legend1);
    map.removeControl(legend2);
    map.removeControl(legend3);

    // Eliminar todas las capas y resetear controles de UI
    url_to_geotiff_file.forEach((data, index) => {
        const capa = layers[data.name];
        if (capa) {
            map.removeLayer(capa);
        }

        const checkbox = document.getElementById(`ch${index + 1}`);
        const slider = document.getElementById(`sl${index + 1}`);

        if (checkbox) {
            checkbox.checked = false;
        }
        if (slider) {
            slider.disabled = true;
        }
    });
    if (layers["CP1A"]) {
        map.addLayer(layers["CP1A"]);
        console.log("CP1A cargada");
    }
}

function Deshabilitar() {
    document.getElementById('lis_mapa1').style.display = "none";
    document.getElementById('lis_mapa2').style.display = "none";
}

function habilitar() {
    document.getElementById('lis_mapa1').style.display = "block";
    document.getElementById('lis_mapa2').style.display = "block";
}

document.addEventListener('DOMContentLoaded', () => {
    ch1on.addEventListener("change", () => {
        if (ch1on.checked) {
            map.addLayer(layers["CP01"])
            leyenda(16)
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
            map.addLayer(layers["CP02"])
            leyenda(15)
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
            map.addLayer(layers["CP03"])
            leyenda(14)
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
            map.addLayer(layers["CP04"])
            leyenda(13)
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
            map.addLayer(layers["CP05"])
            leyenda(12)
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
            map.addLayer(layers["CP06"])
            leyenda(11)
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
            map.addLayer(layers["CP07"])
            leyenda(10)
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
            map.addLayer(layers["CP08"])
            leyenda(9)
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
            map.addLayer(layers["CP09"])
            leyenda(8)
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
            map.addLayer(layers["CP10"])
            leyenda(7)
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
            map.addLayer(layers["CP11"])
            leyenda(6)
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
            map.addLayer(layers["CP12"])
            leyenda(5)
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
            map.addLayer(layers["CP13"])
            leyenda(4)
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
            map.addLayer(layers["CP14"])
            leyenda(3)
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
            map.addLayer(layers["CP15"])
            leyenda(2)
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
            map.addLayer(layers["CP16"])
            leyenda(1)
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
            map.addLayer(layers["CP17"])
            leyenda(0)
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

cargarCapas();

let capasCargadas = new Set();
const totalCapas = url_to_geotiff_file.length;

function invalidar() {
    map.invalidateSize();
    try {
        url_to_geotiff_file.forEach(data => {
            if (layers[data.name] && !capasCargadas.has(data.name)) {
                map.addLayer(layers[data.name]);
                capasCargadas.add(data.name);
                console.log(data.name + " cargada");

                if (capasCargadas.size === totalCapas) {
                    Eliminar_rot();
                    if (layers["CP1A"]) {
                        map.addLayer(layers["CP1A"]);
                        console.log("CP1A cargada");
                    }
                    $('#load').hide(); 
                    return; 
                }
            }
        });
    } catch (error) {
        console.error("Error en la carga de capas: ", error);
    }

    setTimeout(invalidar, 100);
}

setTimeout(invalidar, 100);