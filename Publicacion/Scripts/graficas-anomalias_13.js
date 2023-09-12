var datosTemperaturaMinima = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label:"La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [-0.2, -0.3, -0.3, -0.3, -0.2, -0.2, -0.1, -0.1, -0.1, 0.0, 0.0, -0.1]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.4, 0.6, 0.8, 0.7, 0.2, 0.2, 0.2, 0.3, 0.2, 0.1, 0.1, 0.2]
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
            data: [-0.5, -0.4, -0.7, -0.3, -0.2, -0.3, -0.4, -0.6, -0.2, -0.2, -0.3, -0.5]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.7, 0.6, 0.6, 0.4, 0.2, 0.3, 0.5, 0.7, 0.4, 0.2, 0.3, 0.7]
        }
    ]

}

var datosPrecipitacionMensual = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "Sur y centro de Bolívar",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [26, 37, 67, 166, 249, 227, 228, 257, 253, 271, 200, 83]
        },
        {
            label: "Centro oriente de Bolívar",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [21, 25, 56, 143, 247, 226, 222, 254, 284, 306, 224, 87]
        },
        {
            label: "Norte de Bolívar",
            fillColor: "rgba(76,230,0,0.6)",
            strokeColor: "rgba(76,230,0,0.8)",
            highlightFill: "rgba(76,230,0,0.75)",
            highlightStroke: "rgba(76,230,0,1)",
            data: [21, 24, 43, 114, 182, 165, 153, 180, 186, 224, 166, 73]
        }
    ]
}

var datosPrecipitacionPeriodica = {
    labels: ["DEFM","AMJJ","ASON"],
    datasets: [
        {
            label: "Sur y centro de Bolívar",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [212, 415, 590]
        },
        {
            label: "Centro oriente de Bolívar",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [189, 839, 1069]
        },
        {
            label: "Norte de Bolívar",
            fillColor: "rgba(76,230,0,0.6)",
            strokeColor: "rgba(76,230,0,0.8)",
            highlightFill: "rgba(76,230,0,0.75)",
            highlightStroke: "rgba(76,230,0,1)",
            data: [161, 614, 757]
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
            data: [131.9, 129.2, 142.9, 130.8, 125.5, 122.6, 132.9, 132.6, 120.4, 115.1, 107.6, 117.5]
        },
        {
            label: "PPT",
            fillColor: "rgba(255,0,0,0.6)",
            strokeColor: "rgba(255,0,0,0.8)",
            highlightFill: "rgba(255,0,0,0.75)",
            highlightStroke: "rgba(255,0,0,1)",
            data: [23.7, 32.1, 59.5, 150.8, 236.3, 215.1, 212.4, 241.7, 247.9, 270.3, 199.2, 81.8]
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
            data: [34, 27, 32, -9, -3, 9, 13, 18, 11, 5, 11, 26]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-46, -30, -11, 6, -6, -16, -13, -19, -8, -4, -10, -40]
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
            data: [62, 37, 56, 2, -16, 8, 22, 35, 18, 15, 21, 43]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-51, -32, -26, -6, -1, -18, -26, -39, -19, -14, -22, -62]
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
            data: [27, 43, 43, -8, -7, -1, 16, 27, 9, 11, 14, 24]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-48, -48, -27, 7, -8, -10, -24, -26, -8, -11, -17, -49]
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