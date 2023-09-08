var datosTemperaturaMinima = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label:"La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [-0.1, -0.3, -0.2, -0.3, -0.1, -0.3, 0.0, -0.1, -0.1, 0.0, 0.0, 0.0]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.3, 0.6, 0.7, 0.6, 0.2, 0.4, 0.3, 0.4, 0.2, 0.1, 0.2, 0.1]
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
            data: [-0.2, -0.3, -0.3, -0.2, -0.2, -0.2, -0.2, -0.3, -0.1, -0.1, -0.1, -0.2]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.3, 0.5, 0.5, 0.4, 0.1, 0.1, 0.2, 0.4, 0.2, 0.2, 0.2, 0.3]
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
            data: [-0.4, -0.5, -0.6, -0.4, -0.2, -0.4, -0.4, -0.6, -0.3, -0.2, -0.3, -0.4]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.4, 0.6, 0.7, 0.4, 0.1, 0.3, 0.3, 0.6, 0.5, 0.2, 0.3, 0.5]
        }
    ]

}

var datosPrecipitacionMensual = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "Centro y sur del Atlántico",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [10, 11, 24, 80, 146, 127, 117, 141, 153, 187, 122, 41]
        },
        {
            label: "Litoral Caribe",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [3, 3, 10, 44, 116, 108, 99, 125, 143, 187, 122, 38]
        }
    ]
}

var datosPrecipitacionPeriodica = {
    labels: ["DEFM","AMJJ","ASON"],
    datasets: [
        {
            label: "Centro y sur del Atlántico",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [86, 260, 400]
        },
        {
            label: "Litoral Caribe",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [55, 176, 334]
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
            data: [131.1, 129.0, 145.3, 135.8, 130.0, 126.5, 135.2, 134.7, 122.1, 116.3, 108.7, 118.6]
        },
        {
            label: "PPT",
            fillColor: "rgba(255,0,0,0.6)",
            strokeColor: "rgba(255,0,0,0.8)",
            highlightFill: "rgba(255,0,0,0.75)",
            highlightStroke: "rgba(255,0,0,1)",
            data: [14.7, 17.4, 32.2, 93.5, 161.2, 146.7, 135.8, 162.0, 171.8, 209.5, 149.5, 60.2]
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
            data: [18, 23, 17, -9, -12, -1, 18, 26, 6, 13, 17, 15]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-55, -53, 8, -1, -11, -1, -32, -25, -9, -16, -19, -53]
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
            data: [19, 28, 3, -23, -19, 8, 37, 35, 13, 16, 26, 14]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-54, -1, 55, 25, -5, 1, -21, -26, -12, -17, -16, -55]
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
    //scaleSteps: 10,
    //scaleStepWidth: 50,
    //scaleStartValue: 0,
    datasetFill: false,
    responsive: true,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend list-inline\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].strokeColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
    scaleShowLabels: true,
    scaleLabel: "<%=value%> mm",
}