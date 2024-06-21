if (raiz.length == 1) {
    raiz = "";
}

function listarConvenciones(est, nommap) {
    //console.log("Revisando: est=" + est + " - nommap=" + nommap);
    if (est.getFill() != null) {
        var color = est.getFill().getColor().replace('0.5', '1');
        for (var i = 0; i < convenciones.length; i++) {
            if (convenciones[i].Categoria == nommap) {
                var nombre = convenciones[i].Convencion;
                break;
            }
        }
        if (nombre != undefined) {
            if (htmlConvenciones.indexOf('>' + nombre + '<') <= -1) {
                htmlConvenciones = htmlConvenciones + '<tr><td class="tabla-convenciones-1">' +
                    '<span class="fa fa-circle convencion" style="color: ' + color +
                    '"></span></td><td class="tabla-convenciones-2">' + nombre + '</td></tr>';
            }
        }
    }
    return htmlConvenciones;
}

function asignarConvenciones(estilo, convencion, capa) {
    if (estilo.getFill() != null) {
        var color = estilo.getFill().getColor().replace('0.5', '1');
        for (var i = 0; i < convenciones.length; i++) {
            if (convenciones[i].CodigoCapa == capa) {
                if (convenciones[i].Categoria == convencion) {
                    var nombre = convenciones[i].Convencion;
                    break;
                }
            }
        }
        if (nombre != undefined) {
            if (htmlConvenciones.indexOf('>' + nombre + '<') <= -1) {
                htmlConvenciones = htmlConvenciones + '<tr><td class="tabla-convenciones-1">' +
                    '<span class="fa fa-circle convencion" style="color: ' + color +
                    '"></span></td><td class="tabla-convenciones-2">' + nombre + '</td></tr>';
            }
        }
    }
    return htmlConvenciones;
}

function listarConvencionesEstaciones(est, nommap) {
    if (est.getImage() != null) {
        var color = est.getImage().getFill().getColor().replace('0.5', '1');
        for (var i = 0; i < convenciones.length; i++) {
            if (convenciones[i].Categoria == nommap) {
                var nombre = convenciones[i].Convencion;
                break;
            }
        }
        if (htmlConvenciones.indexOf(nombre) <= -1) {
            htmlConvenciones = htmlConvenciones + '<tr><td class="tabla-convenciones-1">' +
                '<span class="fa fa-circle convencion" style="color: ' + color +
                '"></span></td><td class="tabla-convenciones-2">' + nombre + '</td></tr>';
        }
    }
    return htmlConvenciones;
}

var departamentos_sty = (function (feature) {
    var style_1 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,201,99,0.25)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(115,115,115)',
            width: 1.5
        }),
    })];
    var style_2 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,255,0.25)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(115,115,115)',
            width: 1.5
        }),
    })];
    if (feature.get('coddane') != 88) {
        for (j = 0; j < dptosV.length; j++) {

            if (feature.get('coddane') == dptosV[j]) {
                return style_1;
            }
        }
        return style_2;
    }
})

var centros_poblados_sty = (function (feature) {
    var style_1 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(105,105,105,0.8)'
        }),
    })];
    return style_1;
})

//Color gris para datos que no se encuentran en BD
var style_0 = new ol.style.Style({
    fill: new ol.style.Fill({
        color: 'rgba(204,204,204,0.5)'
    }),
});
var style_99 = new ol.style.Style({
    fill: new ol.style.Fill({
        color: 'rgba(0,0,0,0)'
    }),
});

var parcelas_sty = (function (feature) {
    cultivoNombre = cultivoNombre.toLowerCase().substring(0,3);
    //console.log('aqui--> ' + cultivoNombre);
    var style_1 = [
        new ol.style.Style({
            image: new ol.style.Icon(({
                anchor: [0, 1],
                anchorXUnits: 'fraction',
                anchorYUnits: 'fraction',
                scale: 0.25,
                src: '../Content/imagenes/cultivos/' + cultivoNombre + '_sn.png'
            }))
        }),
        new ol.style.Style({
            image: new ol.style.Circle({
                radius: 5,
                fill: new ol.style.Fill({
                    color: 'rgba(0,0,0,1)'
                })
            })
        })
    ];
    return style_1;
})

var municipios_sty = (function (feature) {
    var style_1 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,255,0.25)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(115,115,115)',
            width: 2
        }),
    })];
    var style_2 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,255,0.25)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(115,115,115)',
            width: 0.5
        }),
    })];
    for (j = 0; j < munV.length; j++) {
        if (feature.get('coddanemun') == munV[j]) {
            return style_1;
        }
    }
    return style_2;
})

var municipio_sty = (function (feature) {
    var style_1 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,255,0.25)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(115,115,115)',
            width: 1.5
        }),
    })];
    return style_1;
})

var drenaje_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(62,95,138,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(62,95,138)',
            width: 1.5
        })
    });
    var estilo = new ol.style.Style();
    estilo = style_1;
    var nombreMapa = feature.get('nombre').toString();
    //console.log('nombreMapa: ' + nombreMapa);
    convencionesDrenaje = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesDrenaje);
    return [estilo];
})

var superficie_agua_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,112,255,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(0,112,255)',
            width: 1.5
        })
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(230,0,0)',
            width: 1.5
        })
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,0,197,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(255,0,197)',
            width: 1.5
        })
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,169,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(0,230,169)',
            width: 1.5
        })
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,223,255,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(115,223,255)',
            width: 1.5
        })
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,211,127,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(255,211,127)',
            width: 1.5
        })
    });

    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('nombre').toString();
    console.log('nombre: ' + nombreMapa);
    switch (nombreMapa) {
        case 'Drenaje':
            estilo = style_1;
            break;
        case 'Jaguey':
            estilo = style_2;
            break;
        case 'Laguna':
            estilo = style_3;
            break;
        case 'Manglar':
            estilo = style_4;
            break;
        case 'Otros cuerpos de agua':
            estilo = style_5;
            break;
        case 'Pantano':
            estilo = style_6;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesSuperficie = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesSuperficie);
    return [estilo];
})

var cobertura_vegetal_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(170,255,0,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(170,255,0)',
            width: 1.5
        })
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(227,203,170,0.5)'
        }),
        stroke: new ol.style.Stroke({
            color: 'rgb(227,203,170)',
            width: 1.5
        })
    });
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('nombre').toString();
    switch (nombreMapa) {
        case 'Matorral':
            estilo = style_1;
            break;
        case 'Ã\u0081rea cultivada':
            estilo = style_2;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesCobertura = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesCobertura);
    return [estilo];
})

//Estaciones - Departamento - id:2
var estaciones_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 5,
            fill: new ol.style.Fill({
                color: 'rgba(0,255,0,1)'
            }),
        })
    });
    var style_2 = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 5,
            fill: new ol.style.Fill({
                color: 'rgba(255,255,0,1)'
            }),
        })
    });
    var style_3 = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 5,
            fill: new ol.style.Fill({
                color: 'rgba(255,128,0,1)'
            }),
        })
    });
    var style_4 = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 5,
            fill: new ol.style.Fill({
                color: 'rgba(255,0,0,1)'
            }),
        })
    });
    var style_5 = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 5,
            fill: new ol.style.Fill({
                color: 'rgba(96,96,96,1)'
            }),
        })
    });
    var style_6 = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 5,
            fill: new ol.style.Fill({
                color: 'rgba(0,0,255,1)'
            }),
        })
    });
    e = "estaciones_climatologicas_" + feature.get('categoria').replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('categoria').toString();
    switch (nombreMapa) {
        case 'SP':
            estilo = style_1;
            break;
        case 'CP':
            estilo = style_2;
            break;
        case 'CO':
            estilo = style_3;
            break;
        case 'ME':
            estilo = style_4;
            break;
        case 'PG':
            estilo = style_5;
            break;
        case 'PM':
            estilo = style_6;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesEstaciones = listarConvencionesEstaciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesEstaciones);
    return [estilo];
})

//Subzonas - Departamento - id:1
var subzonas_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,201,99,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(189,180,151,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,102,0,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(132,157,186,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(167,224,159,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(179,181,147,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(182,225,227,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(198,247,218,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(52,250,89,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(74,176,96,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(106,166,129,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(212,155,123,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(250,130,55,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(179,124,52,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_15 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,211,127,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_16 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,235,214,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_17 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(196,10,10,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_18 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(184,114,129,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_19 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(237,72,50,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_20 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(194,54,80,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_21 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(141,247,168,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_22 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(49,235,89,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_23 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(126,166,146,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_24 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(153,145,145,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_25 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(79,75,75,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_26 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(252,232,233,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_27 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(120,108,108,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_28 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(186,207,85,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_29 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(207,217,160,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_30 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(179,217,124,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_31 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(176,230,85,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_32 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(214,165,109,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_33 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(161,104,84,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_34 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(224,209,110,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_35 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(158,150,95,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_36 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,143,119,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_37 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(96,161,149,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_38 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(225,227,127,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_39 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(127,212,135,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_40 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(153,153,113,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_41 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(222,202,104,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_42 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,0,255,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_43 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(153,106,89,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_44 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(161,122,76,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_45 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(219,152,101,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_46 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,250,0,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_47 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,111,0,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_48 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(176,207,113,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_49 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(153,142,77,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_50 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(158,209,148,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_51 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(212,104,118,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_52 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,63,48,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_53 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(184,64,90,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_54 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(250,65,102,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_55 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(181,132,123,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_56 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(120,214,214,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_57 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(114,196,126,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_58 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(109,156,130,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_59 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(176,146,97,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_60 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(224,211,121,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_61 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(171,105,84,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_62 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(222,155,129,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_63 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(214,204,148,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_64 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(242,224,58,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_65 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(184,146,57,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_66 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(247,237,126,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_67 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(181,176,105,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_68 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(242,236,51,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_69 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(207,158,45,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_70 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(232,126,100,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_71 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(240,82,50,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_72 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(54,245,92,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_73 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(50,166,71,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_74 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(242,230,191,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_75 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(165,196,217,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_76 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(252,199,206,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_77 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(242,236,53,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_78 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(227,191,182,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_79 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(182,252,185,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_80 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(138,134,186,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_81 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(193,214,176,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_82 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(143,199,143,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_83 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(182,179,252,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_84 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(179,235,252,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_85 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(140,245,180,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_86 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(130,184,177,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_87 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(133,166,140,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_88 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(199,126,84,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    //Magdalena
    var style_89 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,115,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_90 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(240,152,146,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_91 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(219,124,50,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_92 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(130,224,224,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_93 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(129,219,132,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_94 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(247,221,190,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_95 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(237,53,50,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_96 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(145,171,126,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    //Córdoba
    var style_97 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(224,206,103,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_98 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(101,161,159,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_99 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(245,56,56,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_100 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(184,102,99,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_101 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(250,195,202,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_102 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(163,152,86,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    //Antioquia
    var style_103 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(247,240,153,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_104 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(186,68,45,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_105 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(191,180,153,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_106 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(181,47,49,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_107 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(199,84,72,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_108 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(86,153,97,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_109 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(242,183,107,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_110 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(196,140,108,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_111 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(212,102,47,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_112 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(247,173,62,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_113 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(129,181,38,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_114 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(183,207,91,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_115 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(185,194,153,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_116 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(245,87,51,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_117 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(237,153,140,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_118 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(146,219,222,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_119 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(250,234,55,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_120 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(211,214,133,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_121 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(240,110,130,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_122 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(201,166,60,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    //Valle
    var style_123 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(127,179,143,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_124 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(222,214,177,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_125 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(235,229,52,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_126 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(214,180,167,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_127 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(250,132,156,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_128 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(219,190,123,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_129 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(184,155,143,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_130 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(156,133,126,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_131 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(166,158,141,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_132 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(191,80,77,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_133 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(46,171,104,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_134 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(184,165,46,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_135 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(181,177,109,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_136 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(179,121,125,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_137 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(136,130,184,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_138 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(38,115,0,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_139 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,76,0,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_140 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,65,50,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_141 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(194,140,145,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_142 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(245,245,122,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_143 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(250,180,67,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });
    var style_144 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(199,126,84,0.5)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(156,156,156,1)', width: 2 })
    });


    e = "subzonas_hidrograficas_" + feature.get('nomszh').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('nomszh').toString();
    switch (nombreMapa) {
        case 'Arroyos Directos al Caribe':
            estilo = style_1;
            break;
        case 'Bajo Magdalena - Canal del Dique  2903 (md) - 2909 (mi)':
            estilo = style_2;
            break;
        case 'Directos al Bajo Magdalena (mi)':
            estilo = style_3;
            break;
        case 'Alto Río Apure':
            estilo = style_4;
            break;
        case 'Bajo Catatumbo':
            estilo = style_5;
            break;
        case 'Quebrada El Carmen y Otros Directos al Magdalena Medio':
            estilo = style_6;
            break;
        case 'Río Algodonal (Alto Catatumbo)':
            estilo = style_7;
            break;
        case 'Río Chítaga':
            estilo = style_8;
            break;
        case 'Río Cobugón - Río Cobaría':
            estilo = style_9;
            break;
        case 'Río Lebrija y otros directos al Magdalena':
            estilo = style_10;
            break;
        case 'Río Margua':
            estilo = style_11;
            break;
        case 'Río Nuevo Presidente - Tres Bocas (Sardinata, Tibú)':
            estilo = style_12;
            break;
        case 'Río Pamplonita':
            estilo = style_13;
            break;
        case 'Río Socuavo del Norte y Río Socuavo Sur':
            estilo = style_14;
            break;
        case 'Río Tarra':
            estilo = style_15;
            break;
        case 'Río Zulia':
            estilo = style_16;
            break;
        case 'Río del Suroeste y directos Río de Oro':
            estilo = style_17;
            break;
        case 'Arroyos Directos al Caribe':
            estilo = style_18;
            break;
        case 'Bajo Magdalena - Canal del Dique  2903 (md) - 2909 (mi)':
            estilo = style_19;
            break;
        case 'Bajo Nechí':
            estilo = style_20;
            break;
        case 'Bajo San Jorge - La Mojana':
            estilo = style_21;
            break;
        case 'Directos Bajo Cauca - Cga La Raya':
            estilo = style_22;
            break;
        case 'Directos Bajo Magdalena':
            estilo = style_23;
            break;
        case 'Directos Caribe Golfo de Morrosquillo':
            estilo = style_24;
            break;
        case 'Directos al Bajo Magdalena (mi)':
            estilo = style_25;
            break;
        case 'Directos al Magdalena (Brazo Morales)':
            estilo = style_26;
            break;
        case 'Río Cimitarra y otros directos al Magdalena':
            estilo = style_27;
            break;
        case 'Chivor':
            estilo = style_28;
            break;
        case 'Directos al Río Meta':
            estilo = style_29;
            break;
        case 'Embalse del Guavio':
            estilo = style_30;
            break;
        case 'Río Bogotá':
            estilo = style_31;
            break;
        case 'Río Carare (Minero)':
            estilo = style_32;
            break;
        case 'Río Guacavía':
            estilo = style_33;
            break;
        case 'Río Guatiquía':
            estilo = style_34;
            break;
        case 'Río Guayuriba':
            estilo = style_35;
            break;
        case 'Río Humea':
            estilo = style_36;
            break;
        case 'Río Negro':
            estilo = style_37;
            break;
        case 'Río Seco y otros Directos al Magdalena (2123) - otros directos md (2303)':
            estilo = style_38;
            break;
        case 'Río Sumapaz':
            estilo = style_39;
            break;
        case 'Río Suárez':
            estilo = style_40;
            break;
        //Boyacá
        case 'Río Cobugón - Río Cobaría':
            estilo = style_41;
            break;
        case 'Río Bojabá':
            estilo = style_42;
            break;
        case 'Río Chicamocha':
            estilo = style_43;
            break;
        case 'Río Fonce':
            estilo = style_44;
            break;
        case 'Río Cravo Sur':
            estilo = style_45;
            break;
        case 'Río Tunjita':
            estilo = style_46;
            break;
        case 'Río Upía':
            estilo = style_47;
            break;
        case 'Río Pauto':
            estilo = style_48;
            break;
        case 'Río Cusiana':
            estilo = style_49;
            break;
        case 'Directos al Magdalena Medio':
            estilo = style_50;
            break;
            //Nariño
        case 'Alto Río Putumayo':
            estilo = style_51;
            break;
        case 'Río Chingual':
            estilo = style_52;
            break;
        case 'Río Guáitara':
            estilo = style_53;
            break;
        case 'Río Iscuandé':
            estilo = style_54;
            break;
        case 'Río Juananbú':
            estilo = style_55;
            break;
        case 'Río Mayo':
            estilo = style_56;
            break;
        case 'Río Mira':
            estilo = style_57;
            break;
        case 'Río Patia Alto':
            estilo = style_58;
            break;
        case 'Río Patia Bajo':
            estilo = style_59;
            break;
        case 'Río Patia Medio':
            estilo = style_60;
            break;
        case 'Río Rosario':
            estilo = style_61;
            break;
        case 'Río San Juan (Frontera Ecuador)':
            estilo = style_62;
            break;
        case 'Río San_Miguel':
            estilo = style_63;
            break;
        case 'Río Tapaje':
            estilo = style_64;
            break;
        case 'Río Telembí':
            estilo = style_65;
            break;
        case 'Río Tola':
            estilo = style_66;
            break;
            //Santander
        case 'Río Opón':
            estilo = style_67;
            break;
        case 'Río Sogamoso':
            estilo = style_68;
            break;
            //Cauca
        case 'Río Purace':
            estilo = style_69;
            break;
        case 'Río Ovejas':
            estilo = style_70;
            break;
        case 'Río Palo':
            estilo = style_71;
            break;
        case 'Alto Río Cauca':
            estilo = style_72;
            break;
        case 'Rio Salado y otros directos Cauca':
            estilo = style_73;
            break;
        case 'Río Quinamayo y otros directos al Cauca':
            estilo = style_74;
            break;
        case 'Río Timba':
            estilo = style_75;
            break;
        case 'Río Claro, río Jamundí y otros directos al Cauca':
            estilo = style_76;
            break;
        case 'Río Piendamo':
            estilo = style_77;
            break;
        case 'Río Naya':
            estilo = style_78;
            break;
        case 'Río Desbaratado':
            estilo = style_79;
            break;
        case 'Río San Juan del Micay':
            estilo = style_80;
            break;
        case 'Río Saija':
            estilo = style_81;
            break;
        case 'Río Timbiquí':
            estilo = style_82;
            break;
        case 'Río Guapi':
            estilo = style_83;
            break;
        case 'Río Guachicono':
            estilo = style_84;
            break;
        case 'Alto Caqueta':
            estilo = style_85;
            break;
        case 'Ríos Cali, río Lilí, río Melendez y río Canaveralejo':
            estilo = style_86;
            break;
        case 'Río Caqueta Medio':
            estilo = style_87;
            break;
        case 'Río Páez':
            estilo = style_88;
            break;
            //Magdalena
        case 'Cga Grande de Santa Marta':
            estilo = style_89;
            break;
        case 'Arroyo Corozal':
            estilo = style_90;
            break;
        case 'Directos al Bajo Magdalena (md)':
            estilo = style_91;
            break;
        case 'Río Ariguaní':
            estilo = style_92;
            break;
        case 'Río Don Diego':
            estilo = style_93;
            break;
        case 'Rio Guachaca -Río  Piedras - Río Manzanares':
            estilo = style_94;
            break;
        case 'Bajo Cesar':
            estilo = style_95;
            break;
        case 'Río Ancho y Otros Directos al caribe':
            estilo = style_96;
            break;
            //Córdoba
        case 'Alto San Jorge':
            estilo = style_97;
            break;
        case 'Bajo Sinú':
            estilo = style_98;
            break;
        case 'Rio Canalete y otros Arroyos Directos al Caribe':
            estilo = style_99;
            break;
        case 'Medio Sinú':
            estilo = style_100;
            break;
        case 'Río San Juan':
            estilo = style_101;
            break;
        case 'Alto Sinú - Urrá':
            estilo = style_102;
            break;
            //Antioquia
        case 'Alto Nechí':
            estilo = style_103;
            break;
        case 'Directos al Bajo Nechí':
            estilo = style_104;
            break;
        case 'Directos al Cauca (md)':
            estilo = style_105;
            break;
        case 'Directos Atrato (md)':
            estilo = style_106;
            break;
        case 'Directos Bajo Atrato':
            estilo = style_107;
            break;
        case 'Directos Magdalena Medio (mi)':
            estilo = style_108;
            break;
        case 'Directos Río Cauca (md)':
            estilo = style_109;
            break;
        case 'Directos Río Cauca (mi)':
            estilo = style_110;
            break;
        case 'Río Arma':
            estilo = style_111;
            break;
        case 'Río Frío y Otros Directos al Cauca':
            estilo = style_112;
            break;
        case 'Río La Miel (Samaná)':
            estilo = style_113;
            break;
        case 'Río León':
            estilo = style_114;
            break;
        case 'Río Mulatos y otros directos al Caribe':
            estilo = style_115;
            break;
        case 'Río Murindó - Directos al Atrato':
            estilo = style_116;
            break;
        case 'Río Murrí':
            estilo = style_117;
            break;
        case 'Río Nare':
            estilo = style_118;
            break;
        case 'Río Porce':
            estilo = style_119;
            break;
        case 'Rió San Bartolo y otros directos al Magdalena Medio':
            estilo = style_120;
            break;
        case 'Río Sucio':
            estilo = style_121;
            break;
        case 'Río Taraza - Río Man':
            estilo = style_122;
            break;
            //Valle
        case 'Río Fraile y otros directos al Cauca':
            estilo = style_123;
            break;
        case 'Río Guabas, Río Sabaletas y río Sonso':
            estilo = style_124;
            break;
        case 'Río Amaime y río Cerrito':
            estilo = style_125;
            break;
        case 'Río Guadalajara y otros directos al Cauca':
            estilo = style_126;
            break;
        case 'Ríos Tulua, río Morales y otros directos al Cauca':
            estilo = style_127;
            break;
        case 'Río Bugalagrande':
            estilo = style_128;
            break;
        case 'Río Paila':
            estilo = style_129;
            break;
        case 'Río La Vieja':
            estilo = style_130;
            break;
        case 'Río Frío':
            estilo = style_131;
            break;
        case 'Río Sipí':
            estilo = style_132;
            break;
        case 'Directos San Juan y Pacifico':
            estilo = style_133;
            break;
        case 'Río Calima':
            estilo = style_134;
            break;
        case 'Río Anchicayá':
            estilo = style_135;
            break;
        case 'Río Timba y otros directos al Pacifico':
            estilo = style_136;
            break;
        case 'Río Dagua y otros directos al Pacífico':
            estilo = style_137;
            break;
         //Tolima
        case 'Río Atá':
            estilo = style_121;
            break;
        case 'Alto Saldaña':
            estilo = style_122;
            break;
        case 'Río Cabrera':
            estilo = style_123;
            break;
        case 'Medio Saldaña':
            estilo = style_124;
            break;
        case 'Bajo Saldaña':
            estilo = style_125;
            break;
        case 'Río Aipe, Río Chenche y otros directos al Magdalena':
            estilo = style_138;
            break;
        case 'Río Amoyá':
            estilo = style_127;
            break;
        case 'Río Tetuán, Río Ortega':
            estilo = style_128;
            break;
        case 'Río Prado':
            estilo = style_129;
            break;
        case 'Rïo Cucuana':
            estilo = style_130;
            break;
        case 'Río Luisa y otros directos al Magdalena':
            estilo = style_131;
            break;
        case 'Río Coello':
            estilo = style_132;
            break;
        case 'Río Opía':
            estilo = style_133;
            break;
        case 'Río Totaré':
            estilo = style_134;
            break;
        case 'Río Lagunilla y Otros Directos al Magdalena':
            estilo = style_135;
            break;
        case 'Río Guarinó':
            estilo = style_136;
            break;
        case 'Directos Magdalena':
            estilo = style_137;
            break;
        case 'Río Gualí':
            estilo = style_111;
            break;
        //Guajira
        case 'Alto Cesar':
            estilo = style_80;
            break;
        case 'Río Carraipia - Paraguachon, Directos al Golfo Maracaibo':
            estilo = style_81;
            break;
        case 'Río Camarones y otros directos Caribe':
            estilo = style_82;
            break;
        case 'Directos Caribe - Ay.Sharimahana Alta Guajira':
            estilo = style_83;
            break;
        case 'Río Ranchería':
            estilo = style_84;
            break;
        case 'Río Tapias':
            estilo = style_85;
            break;
        case 'Medio Cesar':
            estilo = style_86;
            break;
        //Chocó
        case 'Alto Atrato':
            estilo = style_11;
            break;
        case 'Directos Atrato (mi)':
            estilo = style_12;
            break;
        case 'Directos Pacifico Frontera Panamá':
            estilo = style_13;
            break;
        case 'Río Andágueda':
            estilo = style_14;
            break;
        case 'Río Baudó':
            estilo = style_15;
            break;
        case 'Río Bebaramá y otros Directos Atrato':
            estilo = style_16;
            break;
        case 'Río Bojayá':
            estilo = style_17;
            break;
        case 'Río Cacarica':
            estilo = style_18;
            break;
        case 'Río Cajón':
            estilo = style_19;
            break;
        case 'Río Capoma y otros directos al San Juan':
            estilo = style_20;
            break;
        case 'Río Docampadó y Directos Pacífico':
            estilo = style_21;
            break;
        case 'Río Munguidó':
            estilo = style_22;
            break;
        case 'Río Napipí - Río Opogadó':
            estilo = style_23;
            break;
        case 'Río Quito':
            estilo = style_24;
            break;
        case 'Río Salaquí  y otros directos Bajo Atrato':
            estilo = style_25;
            break;
        case 'Río Tamaná y otros Directos San Juan':
            estilo = style_26;
            break;
        case 'Río Tanela y otros Directos al Caribe':
            estilo = style_27;
            break;
        case 'Río Tolo y otros Directos al Caribe':
            estilo = style_28;
            break;
        //Huila
        case 'Río Yaguará y Río Iquira':
            estilo = style_140;
            break;
        case 'Ríos directos Magdalena (md)':
            estilo = style_51;
            break;
        case 'Rio Neiva':
            estilo = style_142;
            break;
        case 'Ríos Directos al Magdalena (mi)':
            estilo = style_53;
            break;
        case 'Rio Fortalecillas y otros':
            estilo = style_143;
            break;
        case 'Río Baché':
            estilo = style_139;
            break;
        case 'Río Timaná y otros directos al Magdalena':
            estilo = style_141;
            break;
        case 'Río Suaza':
            estilo = style_57;
            break;
        case 'Alto Magdalena':
            estilo = style_144;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesSubzonas = asignarConvenciones(estilo, nombreMapa, 1);
    $('.caja-convenciones').html(convencionesSubzonas);
    return [estilo];
})

//Precipitación - Departamento - id:3
var precipitacion_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,0,0,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(137,68,68,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(245,122,122,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,190,190,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,76,0,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,152,0,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,211,127,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,115,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,255,115,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(163,255,115,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(152,230,0,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(56,168,0,0.5)'
        }),
    });
    var style_15 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,132,0.5)'
        }),
    });
    var style_16 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,178,255,0.5)'
        }),
    });
    var style_17 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,92,230,0.5)'
        }),
    });
    var style_18 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,38,115,0.5)'
        }),
    });
    var style_19 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(169,0,230,0.5)'
        }),
    });
    var style_20 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(112,68,137,0.5)'
        }),
    });
    var style_21 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(76,0,115,0.5)'
        }),
    });
    e = "pm_multianual_" + feature.get('rango_mm').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('rango_mm').toString();
    switch (nombreMapa) {
        case '< 300':
            estilo = style_1;
            break;
        case '300 - 500':
            estilo = style_2;
            break;
        case '500 - 700':
            estilo = style_3;
            break;
        case '< 700':
            estilo = style_1;
            break;
        case '700 - 900':
            estilo = style_4;
            break;
        case '900 - 1100':
            estilo = style_5;
            break;
        case '1100 - 1300':
            estilo = style_6;
            break;
        case '1300 - 1500':
            estilo = style_7;
            break;
        case '1500 - 1750':
            estilo = style_8;
            break;
        case '1750 - 2000':
            estilo = style_9;
            break;
        case '2000 - 2250':
            estilo = style_10;
            break;
        case '2250 - 2500':
            estilo = style_11;
            break;
        case '2500 - 2750':
            estilo = style_12;
            break;
        case '2750 - 3000':
            estilo = style_13;
            break;
        case '3000 - 3500':
            estilo = style_14;
            break;
        case '3500 - 4000':
            estilo = style_15;
            break;
        case '4000 - 5000':
            estilo = style_16;
            break;
        case '5000 - 6000':
            estilo = style_17;
            break;
        case '6000 - 7000':
            estilo = style_18;
            break;
        case '7000 - 8000':
            estilo = style_19;
            break;
        case '8000 - 9000':
            estilo = style_20;
            break;
        case '7000 - 9000':
            estilo = style_19;
            break;
        case '9000 - 11000':
            estilo = style_21;
            break;
        case '> 11000':
            estilo = style_21;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesPrecipitacion = asignarConvenciones(estilo, nombreMapa, 3);
    $('.caja-convenciones').html(convencionesPrecipitacion);
    return [estilo];
})

//Conglomerados - Departamento - id:4
var conglomerados_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(79,129,189,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(76,230,0,0.5)'
        }),
    });
    e = "conglomerados_precipitacion_" + feature.get('conglomera').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('conglomera').toString();
    //console.log('conglomerados: ' + nombreMapa);
    switch (nombreMapa) {
        case '1':
            estilo = style_1;
            break;
        case '2':
            estilo = style_2;
            break;
        case '3':
            estilo = style_3;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesConglomerados = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesConglomerados);
    //console.log(convencionesConglomerados);
    return [estilo];
});

//Precipitación El Niño - Departamento - id:11
var anomalia_p_nino_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,0,0,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,76,0,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,211,127,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,235,175,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(204,204,204,0.5)'
        }),
    });
    e = "anomalia_p_nino_" + feature.get('anomalia').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('anomalia').toString();
    switch (nombreMapa) {
        case '< -100%':
            estilo = style_1;
            break;
        case '-100% - -80%':
            estilo = style_2;
            break;
        case '-80% - -60%':
            estilo = style_3;
            break;
        case '-60% - -40%':
            estilo = style_4;
            break;
        case '-40% - -20%':
            estilo = style_5;
            break;
        case '-20% - 0%':
            estilo = style_6;
            break;
        case '>0%':
            estilo = style_7;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesPptNino = asignarConvenciones(estilo, nombreMapa,11);
    $('.caja-convenciones').html(convencionesPptNino);
    return [estilo];
})

//Precipitación La Niña - Departamento - id:12
var anomalia_p_nina_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(204,204,204,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(190,255,232,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,255,223,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,197,255,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,132,168,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,76,168,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,38,115,0.5)'
        }),
    });
    e = "anomalia_p_nina_" + feature.get('anomalia').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('anomalia').toString();
    switch (nombreMapa) {
        case '<0%':
            estilo = style_1;
            break;
        case '0% - 20%':
            estilo = style_2;
            break;
        case '20% - 40%':
            estilo = style_3;
            break;
        case '40% - 60%':
            estilo = style_4;
            break;
        case '60% - 80%':
            estilo = style_5;
            break;
        case '80% - 100%':
            estilo = style_6;
            break;
        case '>100%':
            estilo = style_7;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesPptNina = asignarConvenciones(estilo, nombreMapa, 12);
    $('.caja-convenciones').html(convencionesPptNina);
    return [estilo];
})

//Temperatura multianual máxima - Departamento - id:7
var tmax_media_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,38,115,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,132,168,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,197,255,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,132,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(38,115,0,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(56,168,0,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(85,255,0,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(170,255,0,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,115,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,85,0,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,127,127,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    var style_15 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,0,0,0.5)'
        }),
    });
    e = "tmax_media_multianual_" + feature.get('rango_c').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('rango_c').toString();
    switch (nombreMapa) {
        case '0 - 8':
            estilo = style_1;
            break;
        case '< 8':
            estilo = style_1;
            break;
        case '8 - 10':
            estilo = style_2;
            break;
        case '10 - 12':
            estilo = style_3;
            break;
        case '12 - 14':
            estilo = style_4;
            break;
        case '14 - 16':
            estilo = style_5;
            break;
        case '16 - 18':
            estilo = style_6;
            break;
        case '18 - 20':
            estilo = style_7;
            break;
        case '20 - 22':
            estilo = style_8;
            break;
        case '22 - 24':
            estilo = style_9;
            break;
        case '24 - 26':
            estilo = style_10;
            break;
        case '26 - 28':
            estilo = style_11;
            break;
        case '28 - 30':
            estilo = style_12;
            break;
        case '30 - 32':
            estilo = style_13;
            break;
        case '32 - 34':
            estilo = style_14;
            break;
        case '> 34':
            estilo = style_15;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesTempMax = asignarConvenciones(estilo, nombreMapa, 7);
    $('.caja-convenciones').html(convencionesTempMax);
    return [estilo];
})

//Temperatura multianual media - Departamento - id:6
var tmedia_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(104,104,104,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,77,168,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,169,230,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,223,255,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,169,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(56,168,0,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(76,230,0,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(170,255,0,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,115,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(205,102,102,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,0,0,0.5)'
        }),
    });
    e = "tmedia_multianual_" + feature.get('rango_c').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('rango_c').toString();
    switch (nombreMapa) {
        case '< 6':
            estilo = style_1;
            break;
        case '6 - 8':
            estilo = style_2;
            break;
        case '8 - 10':
            estilo = style_3;
            break;
        case '10 - 12':
            estilo = style_4;
            break;
        case '12 - 14':
            estilo = style_5;
            break;
        case '14 - 16':
            estilo = style_6;
            break;
        case '16 - 18':
            estilo = style_7;
            break;
        case '18 - 20':
            estilo = style_8;
            break;
        case '20 - 22':
            estilo = style_9;
            break;
        case '22 - 24':
            estilo = style_10;
            break;
        case '24 - 26':
            estilo = style_11;
            break;
        case '26 - 28':
            estilo = style_12;
            break;
        case '28 - 30':
            estilo = style_13;
            break;
        case '> 30':
            estilo = style_14;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesTempMed = asignarConvenciones(estilo, nombreMapa, 6);
    $('.caja-convenciones').html(convencionesTempMed);
    return [estilo];
})

//Temperatura multianual mínima - Departamento - id:5
var tmin_media_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(104,104,104,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(132,0,168,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(170,102,205,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,77,168,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,112,255,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,169,230,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,223,255,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,169,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(122,245,202,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(85,255,0,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,255,115,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,0,0,0.5)'
        }),
    });
    e = "tmin_media_multianual_" + feature.get('rango_c').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('rango_c').toString();
    switch (nombreMapa) {
        case '< 0':
            estilo = style_1;
            break;
        case '0 - 2':
            estilo = style_2;
            break;
        case '2 - 4':
            estilo = style_3;
            break;
        case '4 - 6':
            estilo = style_4;
            break;
        case '6 - 8':
            estilo = style_5;
            break;
        case '8 - 10':
            estilo = style_6;
            break;
        case '10 - 12':
            estilo = style_7;
            break;
        case '12 - 14':
            estilo = style_8;
            break;
        case '14 - 16':
            estilo = style_9;
            break;
        case '16 - 18':
            estilo = style_10;
            break;
        case '18 - 20':
            estilo = style_11;
            break;
        case '20 - 22':
            estilo = style_12;
            break;
        case '22 - 24':
            estilo = style_13;
            break;
        case '> 24':
            estilo = style_14;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesTempMin = asignarConvenciones(estilo, nombreMapa, 5);
    $('.caja-convenciones').html(convencionesTempMin);
    return [estilo];
})

//Brillo solar - Departamento - id:8
var brillo_solar_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(217,255,102,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,128,0,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,76,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(60,73,77,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(107,153,145,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(35,142,104,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(85,255,0,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(172,230,115,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,0,0,0.5)'
        }),
    });
    e = "brillo_solar_multianual_" + feature.get('rango_h').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('rango_h').toString();
    switch (nombreMapa) {
        case '<1100':
            estilo = style_5;
            break;
        case '1100 - 1300':
            estilo = style_6;
            break;
        case '1300 - 1500':
            estilo = style_7;
            break;
        case '1500 - 1700':
            estilo = style_8;
            break;
        case '1700 - 1900':
            estilo = style_9;
            break;
        case '1900 - 2100':
            estilo = style_1;
            break;
        case '2100 - 2300':
            estilo = style_2;
            break;
        case '2300 - 2500':
            estilo = style_3;
            break;
        case '2500 - 2700':
            estilo = style_4;
            break;
        case '2700 - 2900':
            estilo = style_10;
            break;
        case '>2900':
            estilo = style_11;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesBrillo = asignarConvenciones(estilo, nombreMapa, 8);
    $('.caja-convenciones').html(convencionesBrillo);
    return [estilo];
})

//Evapotranspiración - Departamento - id:9
var evotranspiracion_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,132,168,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,230,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(56,168,0,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(179,214,156,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,85,0,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,0,0,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,0,77,0.5)'
        }),
    });
    if (feature.get('rango_mm') != null) {
        e = "evotranspiracion_" + feature.get('rango_mm').toString().replace(/ /g, "_");
    }
    else {
        e = "evotranspiracion_" + feature.get('rango_h').toString().replace(/ /g, "_");
    }
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa;
    if (feature.get('rango_mm') != null) {
        nombreMapa = feature.get('rango_mm').toString();
    }
    else {
        nombreMapa = feature.get('rango_h').toString();
    }
    switch (nombreMapa) {
        case '600 - 800':
            estilo = style_1;
            break;
        case '800 - 1000':
            estilo = style_2;
            break;
        case '1000 - 1200':
            estilo = style_3;
            break;
        case '1100 - 1300':
            estilo = style_3;
            break;
        case '1200 - 1400':
            estilo = style_4;
            break;
        case '1300 - 1500':
            estilo = style_4;
            break;
        case '1400 - 1600':
            estilo = style_5;
            break;
        case '1500 - 1700':
            estilo = style_5;
            break;
        case '1600 - 1800':
            estilo = style_6;
            break;
        case '1700 - 1900':
            estilo = style_6;
            break;
        case '1800 - 2000':
            estilo = style_7;
            break;
        case '1900 - 2100':
            estilo = style_7;
            break;
        case '2000 - 2200':
            estilo = style_8;
            break;
        case '> 2200':
            estilo = style_9;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesETo = asignarConvenciones(estilo, nombreMapa, 9);
    $('.caja-convenciones').html(convencionesETo);
    //console.log('conv_ eto:' +convencionesETo);
    return [estilo];
})

//Humedad - Departamento - id:10
var humedad_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,85,0,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(208,255,115,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(85,255,0,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(191,234,255,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(102,204,255,0.5)'
        }),
    });
    e = "hum_relativa_multianual_" + feature.get('rango').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('rango').toString();
    switch (nombreMapa) {
        case '< 65%':
            estilo = style_1;
            break;
        case '65% - 70%':
            estilo = style_2;
            break;
        case '70% - 75%':
            estilo = style_3;
            break;
        case '75% - 80%':
            estilo = style_4;
            break;
        case '80% - 85%':
            estilo = style_5;
            break;
        case '85% - 90%':
            estilo = style_6;
            break;
        case '90% - 95%':
            estilo = style_7;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesHumedad = asignarConvenciones(estilo, nombreMapa, 10);
    $('.caja-convenciones').html(convencionesHumedad);
    return [estilo];
})

//Anomalía temperatura - Departamento - id:13 a 16
var anomalia_t_sty = (function (feature) {
    f = feature.T.slice(0, feature.T.length - 5);
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,34,51,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,85,128,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,106,128,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,132,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,168,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,255,222,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(191,255,233,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(234,255,191,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,235,176,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,210,128,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,168,128,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,140,102,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,128,64,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,80,64,0.5)'
        }),
    });
    e = f + "_" + feature.get('anom_c').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('anom_c').toString();
    //console.log('--> ' + nombreMapa);
    switch (nombreMapa) {
        case '< -3,0':
            estilo = style_1;
            break;
        case '-3,0 - -2,0':
            estilo = style_2;
            break;
        case '-2,0 - -1,5':
            estilo = style_3;
            break;
        case '-1,5 - -1,0':
            estilo = style_4;
            break;
        case '-1,0 - -0,5':
            estilo = style_5;
            break;
        case '-0,5 - -0,25':
            estilo = style_6;
            break;
        case '-0,25 - 0':
            estilo = style_7;
            break;
        case '0 - 0,25':
            estilo = style_8;
            break;
        case '0,25 - 0,5':
            estilo = style_9;
            break;
        case '0,5 - 1,0':
            estilo = style_10;
            break;
        case '1,0 - 1,5':
            estilo = style_11;
            break;
        case '1,5 - 2,0':
            estilo = style_12;
            break;
        case '2,0 - 3,0':
            estilo = style_13;
            break;
        case '> 3,0':
            estilo = style_14;
            break;
        case '0 - 0,5':
            estilo = style_8;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesTemp = asignarConvenciones(estilo, nombreMapa, 13);
    $('.caja-convenciones').html(convencionesTemp);
    return [estilo];
})

//Frecuencia exceso - Departamento - id:17
var deficit_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,97,0,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(122,171,0,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,153,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,34,0,0.5)'
        }),
    });
    e = "exceso_deficit_" + feature.get('frecuencia').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('frecuencia').toString();
    switch (nombreMapa) {
        case 'Muy baja':
            estilo = style_1;
            break;
        case 'Baja':
            estilo = style_2;
            break;
        case 'Media':
            estilo = style_3;
            break;
        case 'Alta':
            estilo = style_4;
            break;
        case 'Muy alta':
            estilo = style_5;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesDeficit = asignarConvenciones(estilo, nombreMapa, 17);
    $('.caja-convenciones').html(convencionesDeficit);
    return [estilo];
})

//Frecuencia déficit - Departamento - id:18
var exceso_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,97,0,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(122,171,0,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,153,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,34,0,0.5)'
        }),
    });
    e = "exceso_deficit_" + feature.get('frecuencia').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('frecuencia').toString();
    switch (nombreMapa) {
        case 'Muy baja':
            estilo = style_1;
            break;
        case 'Baja':
            estilo = style_2;
            break;
        case 'Media':
            estilo = style_3;
            break;
        case 'Alta':
            estilo = style_4;
            break;
        case 'Muy alta':
            estilo = style_5;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesExceso = asignarConvenciones(estilo, nombreMapa, 18);
    $('.caja-convenciones').html(convencionesExceso);
    return [estilo];
})

//Susceptibilidad inundación - Departamento - id:19
var inundacion_susceptibilidad_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,190,190,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(112,168,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,169,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,92,230,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(240,240,240,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(104,104,104,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(168,112,0,0.5)'
        }),
    });
    e = "inundacion_susceptibilidad_" + feature.get('suscinunda').toString().replace(/ /g, "_");
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('suscinunda').toString();
    switch (nombreMapa) {
        case 'Sin información':
            estilo = style_1;
            break;
        case 'Alta':
            estilo = style_2;
            break;
        case 'Media':
            estilo = style_3;
            break;
        case 'Baja':
            estilo = style_4;
            break;
        case 'Marina':
            estilo = style_5;
            break;
        case 'Cuerpo de Agua':
            estilo = style_6;
            break;
        case 'Cuerpo de agua':
            estilo = style_6;
            break;
        case 'No':
            estilo = style_7;
            break;
        case 'No susceptible':
            estilo = style_7;
            break;
        case 'Urbano':
            estilo = style_8;
            break;
        case 'Isla':
            estilo = style_9;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesSusceptibilidad = asignarConvenciones(estilo, nombreMapa, 19);
    $('.caja-convenciones').html(convencionesSusceptibilidad);
    return [estilo];
})

//Susceptibilidad 2010-2010 - Departamento - id:20
var inundacion_2010_2011_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,92,230,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(190,232,255,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,0,0,0.5)'
        }),
    });
    var nombreMapa;
    if (feature.get('inundatota') != null) {
        e = "inundacion_2010_2011_igac_" + feature.get('inundatota').toString().replace(/ /g, "_");
        //console.log(e);
        var x = document.getElementById(e);
        nombreMapa = feature.get('inundatota').toString();
        if (x !== null) {
            x.style.display = 'inherit';
        }
    }
    var estilo = new ol.style.Style();
    switch (nombreMapa) {
        case 'Cuerpos de agua':
            estilo = style_1;
            break;
        case 'Zonas inundables periódicamente':
            estilo = style_2;
            break;
        case 'Inundación 2010 - 2011':
            estilo = style_3;
            break;
        case 'Inundación':
            estilo = style_3;
            break;
        case 'Inundaciondic':
            estilo = style_3;
            break;
        default:
            estilo = style_99;
            break;
    }
    convencionesInundacion = asignarConvenciones(estilo, nombreMapa, 20);
    //console.log(convencionesInundacion);
    $('.caja-convenciones').html(convencionesInundacion);
    return [estilo];
})

/*Amenazas - NDVI */
var anomalia_ndvi_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(114,176,68,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(205,245,122,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,152,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,0,0,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,190,190,0.5)'
        }),
    });
    e = "ndvi_" + feature.get('anomalia');
    //console.log(e);
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa;
    if (feature.get('anomalia') != null) {
        nombreMapa = feature.get('anomalia').toString();
    }
    else {
        nombreMapa = feature.get('anomalía').toString();
    }
    switch (nombreMapa) {
        case 'Estable':
            estilo = style_1;
            break;
        case 'Muy leve':
            estilo = style_2;
            break;
        case 'Leve':
            estilo = style_3;
            break;
        case 'Moderado':
            estilo = style_4;
            break;
        case 'Severo':
            estilo = style_5;
            break;
        case 'Sin dato':
            estilo = style_6;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesNDVI = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesNDVI);
    return [estilo];
})

//var aptitud_sty = (function (feature) {
//    //f = feature.T.slice(22, feature.T.length - 8);
//    //console.log(f);
//    var style_1 = new ol.style.Style({
//        fill: new ol.style.Fill({
//            color: 'rgba(0,97,0,0.5)'
//        }),
//    });
//    var style_2 = new ol.style.Style({
//        fill: new ol.style.Fill({
//            color: 'rgba(209,255,115,0.5)'
//        }),
//    });
//    var style_3 = new ol.style.Style({
//        fill: new ol.style.Fill({
//            color: 'rgba(255,255,115,0.5)'
//        }),
//    });
//    var style_4 = new ol.style.Style({
//        fill: new ol.style.Fill({
//            color: 'rgba(255,170,0,0.5)'
//        }),
//    });
//    var style_5 = new ol.style.Style({
//        fill: new ol.style.Fill({
//            color: 'rgba(230,76,0,0.5)'
//        }),
//    });
//    var style_6 = new ol.style.Style({
//        fill: new ol.style.Fill({
//            color: 'rgba(230,0,0,0.5)'
//        }),
//    });
//    //e = "aptitud_" + f + "_" + feature.get('categoria');
//    e = "aptitud_" + "_" + feature.get('categoria');
//    console.log(e);
//    var x = document.getElementById(e);
//    //console.log(x);
//    if (x !== null) {
//        x.style.display = 'inherit';
//    }
//    var estilo = new ol.style.Style();
//    var nombreMapa
//    if (feature.get('categoria') != null) {
//        nombreMapa = feature.get('categoria').toString();
//    }
//    else {
//        nombreMapa = feature.get('categoría').toString();
//    }
//    switch (nombreMapa) {
//        case '1':
//            return style_1;
//            break;
//        case '4':
//            return style_2;
//            break;
//        case '2':
//            return style_3;
//            break;
//        case '3':
//            return style_3;
//            break;
//        case '5':
//            return style_4;
//            break;
//        case '6':
//            return style_4;
//            break;
//        case '7':
//            return style_5;
//            break;
//        case '8':
//            return style_6;
//            break;
//        case '9':
//            return style_6;
//            break;
//    }
//    convencionesAptitudExceso = listarConvenciones(estilo, nombreMapa);
//    $('.caja-convenciones').html(convencionesAptitudExceso);
//    return [estilo];
//})

var escenarios_tom_sty1 = (function (feature) {
    var style_1 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(56,168,0,0.5)'
        }),
    })];
    var style_2 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(63,171,0,0.5)'
        }),
    })];
    var style_3 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(69,173,0,0.5)'
        }),
    })];
    var style_4 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(74,179,0,0.5)'
        }),
    })];
    var style_5 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(81,181,0,0.5)'
        }),
    })];
    var style_6 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(89,184,0,0.5)'
        }),
    })];
    var style_7 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,127,127,0.5)'
        }),
    })];
    var style_8 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,234,190,0.5)'
        }),
    })];
    var style_9 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(151,219,242,0.5)'
        }),
    })];
    var style_10 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(130,130,130,0.5)'
        }),
    })];
    var style_11 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(124,201,0,0.5)'
        }),
    })];
    var style_12 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(131,207,0,0.5)'
        }),
    })];
    var style_13 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(139,209,0,0.5)'
        }),
    })];
    var style_14 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(148,212,0,0.5)'
        }),
    })];
    var style_15 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(155,217,0,0.5)'
        }),
    })];
    var style_16 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(164,219,0,0.5)'
        }),
    })];
    var style_17 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,237,0,0.5)'
        }),
    })];
    var style_18 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(222,242,0,0.5)'
        }),
    })];
    var style_19 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(228,245,0,0.5)'
        }),
    })];
    var style_20 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(239,247,0,0.5)'
        }),
    })];
    var style_21 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(252,252,0,0.5)'
        }),
    })];
    var style_22 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,251,0,0.5)'
        }),
    })];
    var style_23 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,200,0,0.5)'
        }),
    })];
    var style_24 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,187,0,0.5)'
        }),
    })];
    var style_25 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,179,0,0.5)'
        }),
    })];
    var style_26 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,166,0,0.5)'
        }),
    })];
    var style_27 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,153,0,0.5)'
        }),
    })];
    var style_28 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,145,0,0.5)'
        }),
    })];
    var style_29 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,94,0,0.5)'
        }),
    })];
    var style_30 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,81,0,0.5)'
        }),
    })];
    var style_31 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,72,0,0.5)'
        }),
    })];
    var style_32 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,64,0,0.5)'
        }),
    })];
    var style_33 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,51,0,0.5)'
        }),
    })];
    var style_34 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,42,0,0.5)'
        }),
    })];
    if (feature.get('categoría') == "AL") {
        return style_1;
    }
    if (feature.get('categoría') == "AM") {
        return style_2;
    }
    if (feature.get('categoría') == "AN") {
        return style_3;
    }
    if (feature.get('categoría') == "AO") {
        return style_4;
    }
    if (feature.get('categoría') == "AP") {
        return style_5;
    }
    if (feature.get('categoría') == "AQ") {
        return style_6;
    }
    if (feature.get('categoría') == "AW") {
        return style_7;
    }
    if (feature.get('categoría') == "AX") {
        return style_8;
    }
    if (feature.get('categoría') == "AY") {
        return style_9;
    }
    if (feature.get('categoría') == "AZ") {
        return style_10;
    }
    if (feature.get('categoría') == "BL") {
        return style_11;
    }
    if (feature.get('categoría') == "BM") {
        return style_12;
    }
    if (feature.get('categoría') == "BN") {
        return style_13;
    }
    if (feature.get('categoría') == "BO") {
        return style_14;
    }
    if (feature.get('categoría') == "BP") {
        return style_15;
    }
    if (feature.get('categoría') == "BQ") {
        return style_16;
    }
    if (feature.get('categoría') == "BW") {
        return style_7;
    }
    if (feature.get('categoría') == "BX") {
        return style_8;
    }
    if (feature.get('categoría') == "BY") {
        return style_9;
    }
    if (feature.get('categoría') == "BZ") {
        return style_10;
    }
    if (feature.get('categoría') == "CL") {
        return style_17;
    }
    if (feature.get('categoría') == "CM") {
        return style_18;
    }
    if (feature.get('categoría') == "CN") {
        return style_19;
    }
    if (feature.get('categoría') == "CO") {
        return style_20;
    }
    if (feature.get('categoría') == "CP") {
        return style_21;
    }
    if (feature.get('categoría') == "CQ") {
        return style_22;
    }
    if (feature.get('categoría') == "CW") {
        return style_7;
    }
    if (feature.get('categoría') == "CX") {
        return style_8;
    }
    if (feature.get('categoría') == "CY") {
        return style_9;
    }
    if (feature.get('categoría') == "CZ") {
        return style_10;
    }
    if (feature.get('categoría') == "DL") {
        return style_23;
    }
    if (feature.get('categoría') == "DM") {
        return style_24;
    }
    if (feature.get('categoría') == "DN") {
        return style_25;
    }
    if (feature.get('categoría') == "DO") {
        return style_26;
    }
    if (feature.get('categoría') == "DP") {
        return style_27;
    }
    if (feature.get('categoría') == "DQ") {
        return style_28;
    }
    if (feature.get('categoría') == "DW") {
        return style_7;
    }
    if (feature.get('categoría') == "DX") {
        return style_8;
    }
    if (feature.get('categoría') == "DY") {
        return style_9;
    }
    if (feature.get('categoría') == "DZ") {
        return style_10;
    }
    if (feature.get('categoría') == "EL") {
        return style_29;
    }
    if (feature.get('categoría') == "EM") {
        return style_30;
    }
    if (feature.get('categoría') == "EN") {
        return style_31;
    }
    if (feature.get('categoría') == "EO") {
        return style_32;
    }
    if (feature.get('categoría') == "EP") {
        return style_33;
    }
    if (feature.get('categoría') == "EQ") {
        return style_34;
    }
    if (feature.get('categoría') == "EW") {
        return style_7;
    }
    if (feature.get('categoría') == "EX") {
        return style_8;
    }
    if (feature.get('categoría') == "EY") {
        return style_9;
    }
    if (feature.get('categoría') == "EZ") {
        return style_10;
    }
})

var aptitud_sty_exceso = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,97,0,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,255,115,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,115,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,76,0,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    e = "aptitud_" + "_" + feature.get('categoria');
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa
    if (feature.get('categoria') != null) {
        nombreMapa = feature.get('categoria').toString();
    }
    else {
        nombreMapa = feature.get('categoría').toString();
    }
    switch (nombreMapa) {
        case '1':
            estilo = style_1;
            break;
        case '2':
            estilo = style_3;
            break;
        case '3':
            estilo = style_3;
            break;
        case '4':
            estilo = style_2;
            break;
        case '5':
            estilo = style_4;
            break;
        case '6':
            estilo = style_4;
            break;
        case '7':
            estilo = style_5;
            break;
        case '8':
            estilo = style_6;
            break;
        case '9':
            estilo = style_6;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesAptitudExceso = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesAptitudExceso);
    console.log(convencionesAptitudExceso);
    return [estilo];
})

var aptitud_sty_normal = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,97,0,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,255,115,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,115,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,76,0,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    e = "aptitud_" + "_" + feature.get('categoria');
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa
    if (feature.get('categoria') != null) {
        nombreMapa = feature.get('categoria').toString();
    }
    else {
        nombreMapa = feature.get('categoría').toString();
    }
    //console.log('nombreMapa: ' + nombreMapa);
    switch (nombreMapa) {
        case '1':
            estilo = style_1;
            break;
        case '2':
            estilo = style_3;
            break;
        case '3':
            estilo = style_3;
            break;
        case '4':
            estilo = style_2;
            break;
        case '5':
            estilo = style_4;
            break;
        case '6':
            estilo = style_4;
            break;
        case '7':
            estilo = style_5;
            break;
        case '8':
            estilo = style_6;
            break;
        case '9':
            estilo = style_6;
            break;
        case '10':
            estilo = style_1;
            break;
        case '11':
            estilo = style_2;
            break;
        case '12':
            estilo = style_3;
            break;
        case '13':
            estilo = style_4;
            break;
        case '14':
            estilo = style_5;
            break;
        case '15':
            estilo = style_0;
            break;
        case '16':
            estilo = style_6;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesAptitudNormal = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesAptitudNormal);
    return [estilo];
})

var aptitud_sty_deficit = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,97,0,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,255,115,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,115,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,170,0,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,76,0,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(230,0,0,0.5)'
        }),
    });
    e = "aptitud_" + "_" + feature.get('categoria');
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa
    if (feature.get('categoria') != null) {
        nombreMapa = feature.get('categoria').toString();
    }
    else {
        nombreMapa = feature.get('categoría').toString();
    }
    //console.log('nombreMapa: ' + nombreMapa);
    switch (nombreMapa) {
        case '1':
            estilo = style_1;
            break;
        case '2':
            estilo = style_3;
            break;
        case '3':
            estilo = style_3;
            break;
        case '4':
            estilo = style_2;
            break;
        case '5':
            estilo = style_4;
            break;
        case '6':
            estilo = style_4;
            break;
        case '7':
            estilo = style_5;
            break;
        case '8':
            estilo = style_6;
            break;
        case '9':
            estilo = style_6;
            break;
        case '10':
            estilo = style_1;
            break;
        case '11':
            estilo = style_2;
            break;
        case '12':
            estilo = style_3;
            break;
        case '13':
            estilo = style_4;
            break;
        case '14':
            estilo = style_5;
            break;
        case '15':
            estilo = style_0;
            break;
        case '16':
            estilo = style_6;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesAptitudDeficit = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesAptitudDeficit);
    return [estilo];
})

var escenarios_aji_sty = (function (feature) {
    var style_1 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(56,168,0,0.5)'
        }),
    })];
    var style_2 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(65,171,0,0.5)'
        }),
    })];
    var style_3 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(73,176,0,0.5)'
        }),
    })];
    var style_4 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(81,181,0,0.5)'
        }),
    })];
    var style_5 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(93,186,0,0.5)'
        }),
    })];
    var style_6 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(151,219,242,0.5)'
        }),
    })];
    var style_7 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(130,130,130,0.5)'
        }),
    })];
    var style_8 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(124,201,0,0.5)'
        }),
    })];
    var style_9 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(134,207,0,0.5)'
        }),
    })];
    var style_10 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(148,212,0,0.5)'
        }),
    })];
    var style_11 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(159,217,0,0.5)'
        }),
    })];
    var style_12 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(170,222,0,0.5)'
        }),
    })];
    var style_13 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,237,0,0.5)'
        }),
    })];
    var style_14 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(226,242,0,0.5)'
        }),
    })];
    var style_15 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(239,247,0,0.5)'
        }),
    })];
    var style_16 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,255,0,0.5)'
        }),
    })];
    var style_17 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,238,0,0.5)'
        }),
    })];
    var style_18 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,195,0,0.5)'
        }),
    })];
    var style_19 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,183,0,0.5)'
        }),
    })];
    var style_20 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,166,0,0.5)'
        }),
    })];
    var style_21 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,149,0,0.5)'
        }),
    })];
    var style_22 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,136,0,0.5)'
        }),
    })];
    var style_23 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,89,0,0.5)'
        }),
    })];
    var style_24 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,77,0,0.5)'
        }),
    })];
    var style_25 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,60,0,0.5)'
        }),
    })];
    var style_26 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,42,0,0.5)'
        }),
    })];
    var style_27 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,30,0,0.5)'
        }),
    })];
    if (feature.get('categoria') == "AL") {
        return style_1;
    }
    if (feature.get('categoria') == "AM") {
        return style_2;
    }
    if (feature.get('categoria') == "AN") {
        return style_3;
    }
    if (feature.get('categoria') == "AO") {
        return style_4;
    }
    if (feature.get('categoria') == "AP") {
        return style_5;
    }
    if (feature.get('categoria') == "AY") {
        return style_6;
    }
    if (feature.get('categoria') == "AZ") {
        return style_7;
    }
    if (feature.get('categoria') == "BL") {
        return style_8;
    }
    if (feature.get('categoria') == "BM") {
        return style_9;
    }
    if (feature.get('categoria') == "BN") {
        return style_10;
    }
    if (feature.get('categoria') == "BO") {
        return style_11;
    }
    if (feature.get('categoria') == "BP") {
        return style_12;
    }
    if (feature.get('categoria') == "BY") {
        return style_6;
    }
    if (feature.get('categoria') == "BZ") {
        return style_7;
    }
    if (feature.get('categoria') == "CL") {
        return style_13;
    }
    if (feature.get('categoria') == "CM") {
        return style_14;
    }
    if (feature.get('categoria') == "CN") {
        return style_15;
    }
    if (feature.get('categoria') == "CO") {
        return style_16;
    }
    if (feature.get('categoria') == "CP") {
        return style_17;
    }
    if (feature.get('categoria') == "CY") {
        return style_6;
    }
    if (feature.get('categoria') == "CZ") {
        return style_7;
    }
    if (feature.get('categoria') == "DL") {
        return style_18;
    }
    if (feature.get('categoria') == "DM") {
        return style_19;
    }
    if (feature.get('categoria') == "DN") {
        return style_20;
    }
    if (feature.get('categoria') == "DO") {
        return style_21;
    }
    if (feature.get('categoria') == "DP") {
        return style_22;
    }
    if (feature.get('categoria') == "DY") {
        return style_6;
    }
    if (feature.get('categoria') == "DZ") {
        return style_7;
    }
    if (feature.get('categoria') == "EL") {
        return style_23;
    }
    if (feature.get('categoria') == "EM") {
        return style_24;
    }
    if (feature.get('categoria') == "EN") {
        return style_25;
    }
    if (feature.get('categoria') == "EO") {
        return style_26;
    }
    if (feature.get('categoria') == "EP") {
        return style_27;
    }
    if (feature.get('categoria') == "EY") {
        return style_6;
    }
    if (feature.get('categoria') == "EZ") {
        return style_7;
    }
})

var escenarios_tom_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(56,168,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(63,171,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(69,173,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(74,179,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(81,181,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(89,184,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,127,127,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,234,190,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(151,219,242,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(130,130,130,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(124,201,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(131,207,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(139,209,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(148,212,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_15 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(155,217,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_16 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(164,219,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_17 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(209,237,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_18 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(222,242,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_19 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(228,245,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_20 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(239,247,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_21 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(252,252,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_22 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,251,0,1)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_23 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,200,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_24 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,187,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_25 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,179,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_26 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,166,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_27 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,153,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_28 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,145,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_29 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,94,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_30 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,81,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_31 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,72,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_32 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,64,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_33 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,51,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_34 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,42,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_35 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,225,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_36 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,238,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_37 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(245,122,122,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_38 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(187,230,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_39 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,247,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_40 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,123,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_41 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,140,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_42 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(176,224,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_43 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,132,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_44 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(245,122,122,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_45 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(245,122,122,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_46 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(170,222,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_47 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,17,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_48 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,38,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_49 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,30,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_50 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(245,122,122,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_51 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(90,186,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_52 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,225,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_53 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,119,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_54 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(187,230,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_55 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(90,186,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_56 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(94,189,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_57 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(99,191,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var style_58 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(107,194,0,0.6)'
        }), stroke: new ol.style.Stroke({ color: 'rgba(128,128,128,0.6)', width: 1 })
    });
    var estilo = new ol.style.Style();
    var nombreMapa
    if (feature.get('categoria') != null) {
        nombreMapa = feature.get('categoria').toString();
    }
    else {
        nombreMapa = feature.get('categoría').toString();
    }
    switch (nombreMapa) {
        case 'AL':
            estilo = style_1;
            break;
        case 'AM':
            estilo = style_2;
            break;
        case 'AN':
            estilo = style_3;
            break;
        case 'AO':
            estilo = style_4;
            break;
        case 'AP':
            estilo = style_5;
            break;
        case 'AQ':
            estilo = style_6;
            break;
        case 'AR':
            estilo = style_51;
            break;
        case 'AS':
            estilo = style_55;
            break;
        case 'AT':
            estilo = style_56;
            break;
        case 'AU':
            estilo = style_57;
            break;
        case 'AV':
            estilo = style_58;
            break;
        case 'AW':
            estilo = style_7;
            break;
        case 'AX':
            estilo = style_8;
            break;
        case 'AY':
            estilo = style_9;
            break;
        case 'AZ':
            estilo = style_10;
            break;
        case 'BL':
            estilo = style_11;
            break;
        case 'BM':
            estilo = style_12;
            break;
        case 'BN':
            estilo = style_13;
            break;
        case 'BO':
            estilo = style_14;
            break;
        case 'BP':
            estilo = style_15;
            break;
        case 'BQ':
            estilo = style_16;
            break;
        case 'BR':
            estilo = style_46;
            break;
        case 'BS':
            estilo = style_42;
            break;
        case 'BT':
            estilo = style_38;
            break;
        case 'BU':
            estilo = style_45;
            break;
        case 'BV':
            estilo = style_54;
            break;
        case 'BW':
            estilo = style_7;
            break;
        case 'BX':
            estilo = style_8;
            break;
        case 'BY':
            estilo = style_9;
            break;
        case 'BZ':
            estilo = style_10;
            break;
        case 'CL':
            estilo = style_17;
            break;
        case 'CM':
            estilo = style_18;
            break;
        case 'CN':
            estilo = style_19;
            break;
        case 'CO':
            estilo = style_20;
            break;
        case 'CP':
            estilo = style_21;
            break;
        case 'CQ':
            estilo = style_22;
            break;
        case 'CR':
            estilo = style_39;
            break;
        case 'CS':
            estilo = style_36;
            break;
        case 'CT':
            estilo = style_35;
            break;
        case 'CU':
            estilo = style_37;
            break;
        case 'CV':
            estilo = style_52;
            break;
        case 'CW':
            estilo = style_7;
            break;
        case 'CX':
            estilo = style_8;
            break;
        case 'CY':
            estilo = style_9;
            break;
        case 'CZ':
            estilo = style_10;
            break;
        case 'DL':
            estilo = style_23;
            break;
        case 'DM':
            estilo = style_24;
            break;
        case 'DN':
            estilo = style_25;
            break;
        case 'DO':
            estilo = style_26;
            break;
        case 'DP':
            estilo = style_27;
            break;
        case 'DQ':
            estilo = style_28;
            break;
        case 'DR':
            estilo = style_41;
            break;
        case 'DS':
            estilo = style_43;
            break;
        case 'DT':
            estilo = style_40;
            break;
        case 'DU':
            estilo = style_44;
            break;
        case 'DV':
            estilo = style_53;
            break;
        case 'DW':
            estilo = style_7;
            break;
        case 'DX':
            estilo = style_8;
            break;
        case 'DY':
            estilo = style_9;
            break;
        case 'DZ':
            estilo = style_10;
            break;
        case 'EL':
            estilo = style_29;
            break;
        case 'EM':
            estilo = style_30;
            break;
        case 'EN':
            estilo = style_31;
            break;
        case 'EO':
            estilo = style_32;
            break;
        case 'EP':
            estilo = style_33;
            break;
        case 'EQ':
            estilo = style_34;
            break;
        case 'ER':
            estilo = style_48;
            break;
        case 'ES':
            estilo = style_49;
            break;
        case 'ET':
            estilo = style_47;
            break;
        case 'EU':
            estilo = style_50;
            break;
        case 'EW':
            estilo = style_7;
            break;
        case 'EX':
            estilo = style_8;
            break;
        case 'EY':
            estilo = style_9;
            break;
        case 'EZ':
            estilo = style_10;
            break;
        case 'CNT':
            estilo = style_10;
            break;
        //Categorías de 3 letras (Caso Uribia)
        case 'ALR': estilo = style_1; break;
        case 'ALT': estilo = style_2; break;
        case 'AMR': estilo = style_3; break;
        case 'AMS': estilo = style_4; break;
        case 'AMT': estilo = style_5; break;
        case 'ANR': estilo = style_6; break;
        case 'ANS': estilo = style_7; break;
        case 'ANT': estilo = style_8; break;
        case 'AXR': estilo = style_9; break;
        case 'BLR': estilo = style_10; break;
        case 'BLS': estilo = style_11; break;
        case 'BLT': estilo = style_12; break;
        case 'BLU': estilo = style_13; break;
        case 'BMR': estilo = style_14; break;
        case 'BMS': estilo = style_15; break;
        case 'BMT': estilo = style_16; break;
        case 'BMU': estilo = style_17; break;
        case 'BNR': estilo = style_18; break;
        case 'BNS': estilo = style_19; break;
        case 'BNT': estilo = style_20; break;
        case 'BNU': estilo = style_21; break;
        case 'BXR': estilo = style_22; break;
        case 'BXS': estilo = style_23; break;
        case 'BXT': estilo = style_24; break;
        case 'BXU': estilo = style_25; break;
        case 'CLR': estilo = style_26; break;
        case 'CLS': estilo = style_27; break;
        case 'CLT': estilo = style_28; break;
        case 'CLU': estilo = style_29; break;
        case 'CMR': estilo = style_30; break;
        case 'CMS': estilo = style_31; break;
        case 'CMT': estilo = style_32; break;
        case 'CMU': estilo = style_33; break;
        case 'CNR': estilo = style_34; break;
        case 'CNS': estilo = style_35; break;
        case 'CNT': estilo = style_36; break;
        case 'CNU': estilo = style_37; break;
        case 'CXR': estilo = style_38; break;
        case 'CXS': estilo = style_39; break;
        case 'CXT': estilo = style_40; break;
        case 'CXU': estilo = style_41; break;
        case 'DLR': estilo = style_42; break;
        case 'DLS': estilo = style_43; break;
        case 'DLT': estilo = style_44; break;
        case 'DLU': estilo = style_45; break;
        case 'DMR': estilo = style_46; break;
        case 'DMS': estilo = style_47; break;
        case 'DMT': estilo = style_48; break;
        case 'DMU': estilo = style_49; break;
        case 'DNR': estilo = style_50; break;
        case 'DNS': estilo = style_51; break;
        case 'DNT': estilo = style_52; break;
        case 'DNU': estilo = style_53; break;
        case 'DXR': estilo = style_54; break;
        case 'DXS': estilo = style_55; break;
        case 'DXT': estilo = style_56; break;
        case 'DXU': estilo = style_57; break;
    }
    return [estilo];
})

var expansion_contraccion_sty = (function (feature) {
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,0,255,0.5)'
        }),
    });
    nombreMapa = 'cuerpoagua1';
    convencionesExpansionContraccion = listarConvenciones(style_1, nombreMapa);
    $('.caja-convenciones').html(convencionesExpansionContraccion);
    return [style_1];
})

var estaciones_municipio_sty = (function (feature) {
    var style_1 = [new ol.style.Style({
        image: new ol.style.Circle({
            radius: 5,
            fill: new ol.style.Fill({
                color: 'rgba(187,122,85,1)'
            }),
        })
    })];
    var style_2 = [new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,230,0.5)'
        }),
    })];
    for (j = 0; j < estacionesIDEAMV.length; j++) {
        if (feature.get('codigo') == estacionesIDEAMV[j]) {
            return style_1;
        }
    }
})

var estaciones_municipio_alertas_sty = (function (feature) {
    //console.log(feature.get('codigo'));
    for (j = 0; j < estacionesIDEAMV.length; j++) {
        var radio = estacionesRadioV[j] * 1000 / view.getResolution();
        //console.log("Palmer" + estacionesPalmerV[j]);
        if (estacionesPalmerV[j] > 'sin dato') {
            var color = 'rgba(130,130,130,0.5)';
        } else {
            if (parseFloat(estacionesPalmerV[j]) < -1) {
                var color = 'rgba(255,0,0,0.5)';
            }
            if (parseFloat(estacionesPalmerV[j]) >= -1 && parseFloat(estacionesPalmerV[j]) <= 1) {
                var color = 'rgba(0,255,0,0.5)';
            }
            if (parseFloat(estacionesPalmerV[j]) > 1) {
                var color = 'rgba(0,0,255,0.5)';
            }
        }
        //estacionesCoordenadas[j] = feature.get('');
        //console.log(radio);
        var style_1 = [new ol.style.Style({
            image: new ol.style.Circle({
                radius: radio,
                fill: new ol.style.Fill({
                    color: color
                }),
            })
        })];
        if (feature.get('codigo') == estacionesIDEAMV[j]) {
            return style_1;
        }
    }
})

var escenarios_sty = (function (feature) {
    //console.log("ESTILO:" + cultivoNombre)
    if (cultivoNombre == "Tomate") {
        var style_1 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(56,168,0,0.5)'
            }),
        })];
        var style_2 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(63,171,0,0.5)'
            }),
        })];
        var style_3 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(69,173,0,0.5)'
            }),
        })];
        var style_4 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(74,179,0,0.5)'
            }),
        })];
        var style_5 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(81,181,0,0.5)'
            }),
        })];
        var style_6 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(89,184,0,0.5)'
            }),
        })];
        var style_7 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,127,127,0.5)'
            }),
        })];
        var style_8 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,234,190,0.5)'
            }),
        })];
        var style_9 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(151,219,242,0.5)'
            }),
        })];
        var style_10 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(130,130,130,0.5)'
            }),
        })];
        var style_11 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(124,201,0,0.5)'
            }),
        })];
        var style_12 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(131,207,0,0.5)'
            }),
        })];
        var style_13 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(139,209,0,0.5)'
            }),
        })];
        var style_14 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(148,212,0,0.5)'
            }),
        })];
        var style_15 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(155,217,0,0.5)'
            }),
        })];
        var style_16 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(164,219,0,0.5)'
            }),
        })];
        var style_17 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(209,237,0,0.5)'
            }),
        })];
        var style_18 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(222,242,0,0.5)'
            }),
        })];
        var style_19 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(228,245,0,0.5)'
            }),
        })];
        var style_20 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(239,247,0,0.5)'
            }),
        })];
        var style_21 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(252,252,0,0.5)'
            }),
        })];
        var style_22 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,251,0,0.5)'
            }),
        })];
        var style_23 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,200,0,0.5)'
            }),
        })];
        var style_24 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,187,0,0.5)'
            }),
        })];
        var style_25 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,179,0,0.5)'
            }),
        })];
        var style_26 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,166,0,0.5)'
            }),
        })];
        var style_27 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,153,0,0.5)'
            }),
        })];
        var style_28 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,145,0,0.5)'
            }),
        })];
        var style_29 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,94,0,0.5)'
            }),
        })];
        var style_30 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,81,0,0.5)'
            }),
        })];
        var style_31 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,72,0,0.5)'
            }),
        })];
        var style_32 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,64,0,0.5)'
            }),
        })];
        var style_33 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,51,0,0.5)'
            }),
        })];
        var style_34 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,42,0,0.5)'
            }),
        })];
        if (feature.get('categoría') == "AL") {
            return style_1;
        }
        if (feature.get('categoría') == "AM") {
            return style_2;
        }
        if (feature.get('categoría') == "AN") {
            return style_3;
        }
        if (feature.get('categoría') == "AO") {
            return style_4;
        }
        if (feature.get('categoría') == "AP") {
            return style_5;
        }
        if (feature.get('categoría') == "AQ") {
            return style_6;
        }
        if (feature.get('categoría') == "AW") {
            return style_7;
        }
        if (feature.get('categoría') == "AX") {
            return style_8;
        }
        if (feature.get('categoría') == "AY") {
            return style_9;
        }
        if (feature.get('categoría') == "AZ") {
            return style_10;
        }
        if (feature.get('categoría') == "BL") {
            return style_11;
        }
        if (feature.get('categoría') == "BM") {
            return style_12;
        }
        if (feature.get('categoría') == "BN") {
            return style_13;
        }
        if (feature.get('categoría') == "BO") {
            return style_14;
        }
        if (feature.get('categoría') == "BP") {
            return style_15;
        }
        if (feature.get('categoría') == "BQ") {
            return style_16;
        }
        if (feature.get('categoría') == "BW") {
            return style_7;
        }
        if (feature.get('categoría') == "BX") {
            return style_8;
        }
        if (feature.get('categoría') == "BY") {
            return style_9;
        }
        if (feature.get('categoría') == "BZ") {
            return style_10;
        }
        if (feature.get('categoría') == "CL") {
            return style_17;
        }
        if (feature.get('categoría') == "CM") {
            return style_18;
        }
        if (feature.get('categoría') == "CN") {
            return style_19;
        }
        if (feature.get('categoría') == "CO") {
            return style_20;
        }
        if (feature.get('categoría') == "CP") {
            return style_21;
        }
        if (feature.get('categoría') == "CQ") {
            return style_22;
        }
        if (feature.get('categoría') == "CW") {
            return style_7;
        }
        if (feature.get('categoría') == "CX") {
            return style_8;
        }
        if (feature.get('categoría') == "CY") {
            return style_9;
        }
        if (feature.get('categoría') == "CZ") {
            return style_10;
        }
        if (feature.get('categoría') == "DL") {
            return style_23;
        }
        if (feature.get('categoría') == "DM") {
            return style_24;
        }
        if (feature.get('categoría') == "DN") {
            return style_25;
        }
        if (feature.get('categoría') == "DO") {
            return style_26;
        }
        if (feature.get('categoría') == "DP") {
            return style_27;
        }
        if (feature.get('categoría') == "DQ") {
            return style_28;
        }
        if (feature.get('categoría') == "DW") {
            return style_7;
        }
        if (feature.get('categoría') == "DX") {
            return style_8;
        }
        if (feature.get('categoría') == "DY") {
            return style_9;
        }
        if (feature.get('categoría') == "DZ") {
            return style_10;
        }
        if (feature.get('categoría') == "EL") {
            return style_29;
        }
        if (feature.get('categoría') == "EM") {
            return style_30;
        }
        if (feature.get('categoría') == "EN") {
            return style_31;
        }
        if (feature.get('categoría') == "EO") {
            return style_32;
        }
        if (feature.get('categoría') == "EP") {
            return style_33;
        }
        if (feature.get('categoría') == "EQ") {
            return style_34;
        }
        if (feature.get('categoría') == "EW") {
            return style_7;
        }
        if (feature.get('categoría') == "EX") {
            return style_8;
        }
        if (feature.get('categoría') == "EY") {
            return style_9;
        }
        if (feature.get('categoría') == "EZ") {
            return style_10;
        }
    }
    if (cultivoNombre == "Aji") {
        var style_1 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(56,168,0,0.5)'
            }),
        })];
        var style_2 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(65,171,0,0.5)'
            }),
        })];
        var style_3 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(73,176,0,0.5)'
            }),
        })];
        var style_4 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(81,181,0,0.5)'
            }),
        })];
        var style_5 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(93,186,0,0.5)'
            }),
        })];
        var style_6 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(151,219,242,0.5)'
            }),
        })];
        var style_7 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(130,130,130,0.5)'
            }),
        })];
        var style_8 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(124,201,0,0.5)'
            }),
        })];
        var style_9 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(134,207,0,0.5)'
            }),
        })];
        var style_10 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(148,212,0,0.5)'
            }),
        })];
        var style_11 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(159,217,0,0.5)'
            }),
        })];
        var style_12 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(170,222,0,0.5)'
            }),
        })];
        var style_13 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(209,237,0,0.5)'
            }),
        })];
        var style_14 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(226,242,0,0.5)'
            }),
        })];
        var style_15 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(239,247,0,0.5)'
            }),
        })];
        var style_16 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,255,0,0.5)'
            }),
        })];
        var style_17 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,238,0,0.5)'
            }),
        })];
        var style_18 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,195,0,0.5)'
            }),
        })];
        var style_19 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,183,0,0.5)'
            }),
        })];
        var style_20 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,166,0,0.5)'
            }),
        })];
        var style_21 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,149,0,0.5)'
            }),
        })];
        var style_22 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,136,0,0.5)'
            }),
        })];
        var style_23 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,89,0,0.5)'
            }),
        })];
        var style_24 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,77,0,0.5)'
            }),
        })];
        var style_25 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,60,0,0.5)'
            }),
        })];
        var style_26 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,42,0,0.5)'
            }),
        })];
        var style_27 = [new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(255,30,0,0.5)'
            }),
        })];
        if (feature.get('categoría') == "AL") {
            return style_1;
        }
        if (feature.get('categoría') == "AM") {
            return style_2;
        }
        if (feature.get('categoría') == "AN") {
            return style_3;
        }
        if (feature.get('categoría') == "AO") {
            return style_4;
        }
        if (feature.get('categoría') == "AP") {
            return style_5;
        }
        if (feature.get('categoría') == "AY") {
            return style_6;
        }
        if (feature.get('categoría') == "AZ") {
            return style_7;
        }
        if (feature.get('categoría') == "BL") {
            return style_8;
        }
        if (feature.get('categoría') == "BM") {
            return style_9;
        }
        if (feature.get('categoría') == "BN") {
            return style_10;
        }
        if (feature.get('categoría') == "BO") {
            return style_11;
        }
        if (feature.get('categoría') == "BP") {
            return style_12;
        }
        if (feature.get('categoría') == "BY") {
            return style_6;
        }
        if (feature.get('categoría') == "BZ") {
            return style_7;
        }
        if (feature.get('categoría') == "CL") {
            return style_13;
        }
        if (feature.get('categoría') == "CM") {
            return style_14;
        }
        if (feature.get('categoría') == "CN") {
            return style_15;
        }
        if (feature.get('categoría') == "CO") {
            return style_16;
        }
        if (feature.get('categoría') == "CP") {
            return style_17;
        }
        if (feature.get('categoría') == "CY") {
            return style_6;
        }
        if (feature.get('categoría') == "CZ") {
            return style_7;
        }
        if (feature.get('categoría') == "DL") {
            return style_18;
        }
        if (feature.get('categoría') == "DM") {
            return style_19;
        }
        if (feature.get('categoría') == "DN") {
            return style_20;
        }
        if (feature.get('categoría') == "DO") {
            return style_21;
        }
        if (feature.get('categoría') == "DP") {
            return style_22;
        }
        if (feature.get('categoría') == "DY") {
            return style_6;
        }
        if (feature.get('categoría') == "DZ") {
            return style_7;
        }
        if (feature.get('categoría') == "EL") {
            return style_23;
        }
        if (feature.get('categoría') == "EM") {
            return style_24;
        }
        if (feature.get('categoría') == "EN") {
            return style_25;
        }
        if (feature.get('categoría') == "EO") {
            return style_26;
        }
        if (feature.get('categoría') == "EP") {
            return style_27;
        }
        if (feature.get('categoría') == "EY") {
            return style_6;
        }
        if (feature.get('categoría') == "EZ") {
            return style_7;
        }
    }
})

var anomalia_t_sty_min_nina = (function (feature) {
    //f = feature.T.slice(0, feature.T.length - 5);
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,34,51,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,85,128,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,106,128,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,132,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,168,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,255,222,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(191,255,233,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(234,255,191,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,235,176,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,210,128,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,168,128,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,140,102,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,128,64,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,80,64,0.5)'
        }),
    });
    //e = f + "_" + feature.get('anom_c').toString().replace(/ /g, "_");
    e = feature.get('anom_c').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('anom_c').toString();
    //console.log('--> ' + nombreMapa);
    switch (nombreMapa) {
        case '< -3,0':
            estilo = style_1;
            break;
        case '-3,0 - -2,0':
            estilo = style_2;
            break;
        case '-2,0 - -1,5':
            estilo = style_3;
            break;
        case '-1,5 - -1,0':
            estilo = style_4;
            break;
        case '-1,0 - -0,5':
            estilo = style_5;
            break;
        case '-0,5 - -0,25':
            estilo = style_6;
            break;
        case '-0,25 - 0':
            estilo = style_7;
            break;
        case '0 - 0,25':
            estilo = style_8;
            break;
        case '0,25 - 0,5':
            estilo = style_9;
            break;
        case '0,5 - 1,0':
            estilo = style_10;
            break;
        case '1,0 - 1,5':
            estilo = style_11;
            break;
        case '1,5 - 2,0':
            estilo = style_12;
            break;
        case '2,0 - 3,0':
            estilo = style_13;
            break;
        case '> 3,0':
            estilo = style_14;
            break;
        case '0 - 0,5':
            estilo = style_8;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesTempMinNina = listarConvenciones(estilo, nombreMapa);
    //console.log('html1: ' + convencionesTempMinNina);
    $('.caja-convenciones').html(convencionesTempMinNina);
    return [estilo];
})

var anomalia_t_sty_min_nino = (function (feature) {
    //f = feature.T.slice(0, feature.T.length - 5);
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,34,51,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,85,128,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,106,128,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,132,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,168,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,255,222,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(191,255,233,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(234,255,191,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,235,176,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,210,128,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,168,128,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,140,102,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,128,64,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,80,64,0.5)'
        }),
    });
    //e = f + "_" + feature.get('anom_c').toString().replace(/ /g, "_");
    e = feature.get('anom_c').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('anom_c').toString();
    //console.log('--> ' + nombreMapa);
    switch (nombreMapa) {
        case '< -3,0':
            estilo = style_1;
            break;
        case '-3,0 - -2,0':
            estilo = style_2;
            break;
        case '-2,0 - -1,5':
            estilo = style_3;
            break;
        case '-1,5 - -1,0':
            estilo = style_4;
            break;
        case '-1,0 - -0,5':
            estilo = style_5;
            break;
        case '-0,5 - -0,25':
            estilo = style_6;
            break;
        case '-0,25 - 0':
            estilo = style_7;
            break;
        case '0 - 0,25':
            estilo = style_8;
            break;
        case '0,25 - 0,5':
            estilo = style_9;
            break;
        case '0,5 - 1,0':
            estilo = style_10;
            break;
        case '1,0 - 1,5':
            estilo = style_11;
            break;
        case '1,5 - 2,0':
            estilo = style_12;
            break;
        case '2,0 - 3,0':
            estilo = style_13;
            break;
        case '> 3,0':
            estilo = style_14;
            break;
        case '0 - 0,5':
            estilo = style_8;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesTempMinNino = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesTempMinNino);
    return [estilo];
})

var anomalia_t_sty_max_nina = (function (feature) {
    //f = feature.T.slice(0, feature.T.length - 5);
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,34,51,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,85,128,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,106,128,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,132,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,168,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,255,222,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(191,255,233,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(234,255,191,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,235,176,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,210,128,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,168,128,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,140,102,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,128,64,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,80,64,0.5)'
        }),
    });
    //e = f + "_" + feature.get('anom_c').toString().replace(/ /g, "_");
    e = feature.get('anom_c').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('anom_c').toString();
    switch (nombreMapa) {
        case '< -3,0':
            estilo = style_1;
            break;
        case '-3,0 - -2,0':
            estilo = style_2;
            break;
        case '-2,0 - -1,5':
            estilo = style_3;
            break;
        case '-1,5 - -1,0':
            estilo = style_4;
            break;
        case '-1,0 - -0,5':
            estilo = style_5;
            break;
        case '-0,5 - -0,25':
            estilo = style_6;
            break;
        case '-0,25 - 0':
            estilo = style_7;
            break;
        case '0 - 0,25':
            estilo = style_8;
            break;
        case '0,25 - 0,5':
            estilo = style_9;
            break;
        case '0,5 - 1,0':
            estilo = style_10;
            break;
        case '1,0 - 1,5':
            estilo = style_11;
            break;
        case '1,5 - 2,0':
            estilo = style_12;
            break;
        case '2,0 - 3,0':
            estilo = style_13;
            break;
        case '> 3,0':
            estilo = style_14;
            break;
        case '0 - 0,5':
            estilo = style_8;
            break;
        default:
            estilo = style_0;
            break;
    }
    //console.log('ultimas: ' + convencionesTempMaxNina);
    convencionesTempMaxNina = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesTempMaxNina);
    return [estilo];
})

var anomalia_t_sty_max_nino = (function (feature) {
    //f = feature.T.slice(0, feature.T.length - 5);
    var style_1 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,34,51,0.5)'
        }),
    });
    var style_2 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,85,128,0.5)'
        }),
    });
    var style_3 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,106,128,0.5)'
        }),
    });
    var style_4 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,168,132,0.5)'
        }),
    });
    var style_5 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(0,230,168,0.5)'
        }),
    });
    var style_6 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(115,255,222,0.5)'
        }),
    });
    var style_7 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(191,255,233,0.5)'
        }),
    });
    var style_8 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(234,255,191,0.5)'
        }),
    });
    var style_9 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,235,176,0.5)'
        }),
    });
    var style_10 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,210,128,0.5)'
        }),
    });
    var style_11 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,168,128,0.5)'
        }),
    });
    var style_12 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,140,102,0.5)'
        }),
    });
    var style_13 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,128,64,0.5)'
        }),
    });
    var style_14 = new ol.style.Style({
        fill: new ol.style.Fill({
            color: 'rgba(255,80,64,0.5)'
        }),
    });
    //e = f + "_" + feature.get('anom_c').toString().replace(/ /g, "_");
    e = feature.get('anom_c').toString().replace(/ /g, "_");
    var x = document.getElementById(e);
    if (x !== null) {
        x.style.display = 'inherit';
    }
    var estilo = new ol.style.Style();
    var nombreMapa = feature.get('anom_c').toString();
    switch (nombreMapa) {
        case '< -3,0':
            estilo = style_1;
            break;
        case '-3,0 - -2,0':
            estilo = style_2;
            break;
        case '-2,0 - -1,5':
            estilo = style_3;
            break;
        case '-1,5 - -1,0':
            estilo = style_4;
            break;
        case '-1,0 - -0,5':
            estilo = style_5;
            break;
        case '-0,5 - -0,25':
            estilo = style_6;
            break;
        case '-0,25 - 0':
            estilo = style_7;
            break;
        case '0 - 0,25':
            estilo = style_8;
            break;
        case '0,25 - 0,5':
            estilo = style_9;
            break;
        case '0,5 - 1,0':
            estilo = style_10;
            break;
        case '1,0 - 1,5':
            estilo = style_11;
            break;
        case '1,5 - 2,0':
            estilo = style_12;
            break;
        case '2,0 - 3,0':
            estilo = style_13;
            break;
        case '> 3,0':
            estilo = style_14;
            break;
        case '0 - 0,5':
            estilo = style_8;
            break;
        default:
            estilo = style_0;
            break;
    }
    convencionesTempMaxNino = listarConvenciones(estilo, nombreMapa);
    $('.caja-convenciones').html(convencionesTempMaxNino);
    return [estilo];
})