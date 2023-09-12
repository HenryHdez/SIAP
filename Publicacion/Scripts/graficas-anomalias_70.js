var datosTemperaturaMinima = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label:"La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [-0.2, -0.1, -0.4, -0.2, -0.2, -0.2, -0.2, -0.2, -0.1, -0.1, -0.1, -0.3]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.4, 0.4, 0.4, 0.4, 0.2, 0.2, 0.3, 0.4, 0.2, 0.1, 0.2, 0.4]
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
            data: [-0.3, -0.2, -0.6, -0.3, 0.0, -0.3, -0.3, -0.4, -0.1, -0.1, -0.2, -0.5]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.5, 0.4, 0.5, 0.6, 0.3, 0.3, 0.5, 0.7, 0.3, 0.1, 0.3, 0.7]
        }
    ]
}

var datosPrecipitacionMensual = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "Sabanas de Sucre y Montes de María",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [21.7, 26.1, 47.0, 137.9, 236.3, 233.8, 249.7, 270.8, 257.3, 260.8, 195.3, 77.9]
        },
        {
            label: "Sector nororiental de Sucre",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [27.5, 31.9, 54.0, 136.0, 205.9, 196.2, 180.4, 208.2, 214.6, 255.1, 200.8, 97.7]
        }
    ]
}

var datosPrecipitacionPeriodica = {
    labels: ["DEFM", "AMJJ", "ASON"],
    datasets: [
        {
            label: "Sabanas de Sucre y Montes de María",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [172.7, 857.7, 984.2]
        },
        {
            label: "Sector nororiental de Sucre",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [211.1, 718.4, 878.8]
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
            data: [120.7, 118.5, 133.8, 124.6, 118.9, 114.5, 123.0, 123.3, 113.7, 110.7, 102.7, 108.8]
        },
        {
            label: "PPT",
            fillColor: "rgba(255,0,0,0.6)",
            strokeColor: "rgba(255,0,0,0.8)",
            highlightFill: "rgba(255,0,0,0.75)",
            highlightStroke: "rgba(255,0,0,1)",
            data: [21.2, 25.6, 45.8, 132.1, 222.9, 212.7, 223.9, 244.4, 239.4, 240.8, 180.2, 75.1]
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
            data: [45, 38, 47, -5, -9, 9, 13, 19, 12, 6, 12, 37]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-50, -34, -29, 2, -3, -15, -13, -20, -10, -7, -13, -48]
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

var datosAnomaliaPptC3 = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [29, 44, 51, -9, -7, -1, 15, 29, 10, 10, 12, 23]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-46, -41, -37, 10, -5, -11, -18, -29, -8, -7, -19, -47]
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