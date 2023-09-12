var datosTemperaturaMinima = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label:"La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [-0.4, -0.4, -0.4, -0.1, 0.0, 0.0, -0.1, -0.4, -0.4, -0.3, -0.3, -0.4]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.4, 0.5, 0.5, 0.5, 0.1, 0.1, 0.3, 0.4, 0.4, 0.2, 0.3, 0.5]
        }
    ]
}

var datosTemperaturaMedia = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: []
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: []
        }
    ]

}

var datosTemperaturaMaxima = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [-0.7, -0.6, -0.7, -0.3, 0.0, -0.1, -0.3, -1.1, -0.9, -0.4, -0.4, -0.8]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.6, 0.6, 0.6, 0.3, 0.1, 0.2, 0.4, 0.8, 0.7, 0.3, 0.4, 0.7]
        }
    ]
}

var datosPrecipitacionMensual = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "Valle del río Cesar y baja Guajira",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [9.5, 9.5, 13.9, 80.3, 136.9, 77.6, 51.6, 101.2, 156.2, 181.2, 138.8, 50.5]
        },
        {
            label: "Baja Guajira",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [8.7, 13.0, 37.3, 106.8, 177.5, 102.3, 92.0, 126.2, 163.3, 203.9, 133.7, 41.7]
        },
        {
            label: "Alta y media Guajira",
            fillColor: "rgba(76,230,0,0.6)",
            strokeColor: "rgba(76,230,0,0.8)",
            highlightFill: "rgba(76,230,0,0.75)",
            highlightStroke: "rgba(76,230,0,1)",
            data: [8.1, 6.6, 7.3, 23.1, 54.1, 20.7, 13.7, 38.7, 71.9, 127.8, 87.7, 36.3]
        }
    ]
}

var datosPrecipitacionPeriodica = {
    labels: ["DEF", "MAM", "JJA", "SON"],
    datasets: [
        {
            label: "Valle del río Cesar y baja Guajira",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [68.3, 231.1, 230.5, 476.2]
        },
        {
            label: "Baja Guajira",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [62.0, 321.7, 320.4, 501.0]
        },
        {
            label: "Alta y media Guajira",
            fillColor: "rgba(76,230,0,0.6)",
            strokeColor: "rgba(76,230,0,0.8)",
            highlightFill: "rgba(76,230,0,0.75)",
            highlightStroke: "rgba(76,230,0,1)",
            data: [49.1, 84.4, 73.1, 287.4]
        }
    ]
}

var datosEvapotranspiracion = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "ETo",
            fillColor: "rgba(255,164,32,0.6)",
            strokeColor: "rgba(255,164,32,0.8)",
            highlightFill: "rgba(255,164,32,0.75)",
            highlightStroke: "rgba(255,164,32,1)",
            data: [154.6, 150.8, 173.3, 162.0, 161.2, 164.6, 180.2, 178.0, 155.4, 143.8, 132.5, 140.2]
        },
        {
            label: "PPT",
            fillColor: "rgba(255,0,0,0.6)",
            strokeColor: "rgba(255,0,0,0.8)",
            highlightFill: "rgba(255,0,0,0.75)",
            highlightStroke: "rgba(255,0,0,1)",
            data: [8.8, 9.0, 15.6, 61.2, 109.7, 58.3, 43.3, 79.6, 121.9, 163.0, 116.2, 42.8]
        }
    ]
}

var datosAnomaliaPptC1 = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [38, -50, -8, -1, -32, 35, 53, 55, 16, 10, 14, 88]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-12, -17, 94, 9, 8, -12, -57, -41, -14, -4, -21, -46]
        }
    ]
}

var datosAnomaliaPptC2 = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [-26, 10, -1, -32, -24, 0, 27, 35, 20, 18, 29, 55]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [18, -14, 43, 11, 4, -11, -31, -22, -14, -17, -28, -40]
        }
    ]
}

var datosAnomaliaPptC3 = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [17, -8, 7, 2, -50, 24, 72, 98, 50, 37, 44, 75]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-10, -17, 16, 1, -23, -26, -59, -70, -26, -22, -23, -54]
        }
    ]
}

var opcionesAnomaliasTemperatura = {
    barShowStroke: false,
    scaleBeginAtZero: false,
    scaleOverride: true,
    scaleSteps: 2,
    scaleStepWidth: 1,
    scaleStartValue: -1,
    responsive: true,
    barBeginAtOrigin: true,
    scaleFontFamily: "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
    scaleShowValues: true,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend list-inline\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].strokeColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    scaleShowLabels: true,
    scaleLabel: "<%=value%> °C",
}

var opcionesAnomaliasPpt = {
    barShowStroke: false,
    scaleBeginAtZero: false,
    scaleOverride: true,
    scaleSteps: 6,
    scaleStepWidth: 20,
    scaleStartValue: -60,
    responsive: true,
    barBeginAtOrigin: true,
    scaleFontFamily: "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
    scaleShowValues: true,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend list-inline\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].strokeColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    scaleShowLabels: true,
    scaleLabel: "<%=value%> %",
}

var opcionesConglomerados = {
    barShowStroke: false,
    responsive: true,
    barBeginAtOrigin: true,
    scaleFontFamily: "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend list-inline\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].strokeColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    scaleShowLabels: true,
    scaleLabel: "<%=value%> mm",
}

var opcionesEvapotranspiracion = {
    //scaleOverride: true,
    //scaleSteps: 5,
    //scaleStepWidth: 10,
    //scaleStartValue: 100,
    datasetFill: false,
    responsive: true,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend list-inline\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].strokeColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    scaleShowLabels: true,
    scaleLabel: "<%=value%> mm",
}