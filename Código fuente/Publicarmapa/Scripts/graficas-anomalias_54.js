var datosTemperaturaMinima = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label:"La Niña",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [-0.2, -0.3, -0.3, -0.5, -0.3, -0.2, -0.1, -0.1, 0.0, 0.0, 0.0, -0.1]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.3, 0.6, 0.7, 0.7, 0.2, 0.2, 0.2, 0.1, 0.1, 0.1, 0.1, 0.1]
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
            data: [-0.6, -0.6, -0.9, -0.2, -0.1, -0.3, -0.2, -0.5, -0.2, -0.1, -0.1, -0.4]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [0.9, 1.1, 1.0, 0.7, 0.1, 0.2, 0.4, 0.5, 0.4, 0.1, 0.2, 0.6]
        }
    ]

}

var datosPrecipitacionMensual = {
    labels: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
    datasets: [
        {
            label: "Cordillera Oriental, Catatumbo y Zulia",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [71, 72, 103, 200, 198, 115, 115, 149, 212, 264, 221, 135]
        },
        {
            label: "Valle del Magdalena medio",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [48, 78, 130, 219, 251, 180, 162, 189, 223, 272, 208, 97]
        },
        {
            label: "Orinoquia Norsantandereana",
            fillColor: "rgba(76,230,0,0.6)",
            strokeColor: "rgba(76,230,0,0.8)",
            highlightFill: "rgba(76,230,0,0.75)",
            highlightStroke: "rgba(76,230,0,1)",
            data: [108, 168, 201, 312, 418, 528, 483, 425, 364, 279, 211, 142]
        }
    ]
}

var datosPrecipitacionPeriodica = {
    labels: ["DEF", "MAM", "JJA", "SON"],
    datasets: [
        {
            label: "Cordillera Oriental, Catatumbo y Zulia ",
            fillColor: "rgba(85,135,193,0.6)",
            strokeColor: "rgba(85,135,193,0.8)",
            highlightFill: "rgba(85,135,193,0.75)",
            highlightStroke: "rgba(85,135,193,1)",
            data: [278, 502, 379, 697]
        },
        {
            label: "Valle del Magdalena medio",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [223, 600, 531, 703]
        },
        {
            label: "Orinoquia Norsantandereana",
            fillColor: "rgba(76,230,0,0.6)",
            strokeColor: "rgba(76,230,0,0.8)",
            highlightFill: "rgba(76,230,0,0.75)",
            highlightStroke: "rgba(76,230,0,1)",
            data: [417, 931, 1437, 853]
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
            data: [107.2, 103.5, 114.3, 105.3, 109.9, 108.7, 117.9, 122.0, 113.9, 106.8, 95.4, 97.7]
        },
        {
            label: "PPT",
            fillColor: "rgba(255,0,0,0.6)",
            strokeColor: "rgba(255,0,0,0.8)",
            highlightFill: "rgba(255,0,0,0.75)",
            highlightStroke: "rgba(255,0,0,1)",
            data: [65.0, 77.4, 115.2, 210.2, 223.2, 150.2, 142.7, 171.5, 220.8, 267.1, 216.5, 122.6]
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
            data: [38, 18, 36, -7, -10, 8, 23, 33, 13, 3, 17, 26]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-34, -34, -3, 4, -3, -11, -17, -33, -9, 1, -20, -42]
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
            data: [22, 12, 21, -10, -3, 5, 11, 21, 11, 7, 10, 23]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [-32, -13, 2, 10, -11, -15, -11, -26, -6, -2, -8, -36]
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
            data: [8, 13, 7, 5, -11, -10, -2, -17, -2, 2, 5, 94]
        },
        {
            label: "El Niño",
            fillColor: "rgba(196,86,83,0.6)",
            strokeColor: "rgba(196,86,83,0.8)",
            highlightFill: "rgba(196,86,83,0.75)",
            highlightStroke: "rgba(196,86,83,1)",
            data: [1, -26, -17, 3, 9, 4, 6, 7, -1, -7, -9, -4]
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
    //barShowStroke: false,
    scaleBeginAtZero: false,
    responsive: true,
    //barBeginAtOrigin: false,
    //animation: false,
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