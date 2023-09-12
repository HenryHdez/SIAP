if (raiz.length == 1) {
    raiz = "";
}
var arregloListas = new Array();
//0
arregloListas.push({
    "lista": "seleccionCultivo",
    "categoria": "cultivo"
});
//1
arregloListas.push({
    "lista": "seleccionDepartamento",
    "categoria": "departamento"
});
//2
arregloListas.push({
    "lista": "seleccionOrigenDatos",
    "categoria": "origen"
});
//3
arregloListas.push({
    "lista": "seleccionEstacion",
    "categoria": "estacion"
});
//4
arregloListas.push({
    "lista": "siembra-anho",
    "categoria": "año"
});
//5
arregloListas.push({
    "lista": "seleccionAnhoUsuario",
    "categoria": "añoUsuario"
});
//6
arregloListas.push({
    "lista": "seleccionSuelo",
    "categoria": "suelo"
});


$(function () {
    $("#seleccionFechaSiembra").datepicker({
        maxDate: 0,
        altField: '#FechaSiembra',
        changeMonth: true,
        changeYear: false,
        dateFormat: "dd/mm/yy",
        numberOfMonths: 1,
        defaultDate: '01/01/1997'
    });
});

function EditarSuelo() {
    document.getElementById('DatoCC').disabled = false;
    document.getElementById('DatoPMP').disabled = false;
    document.getElementById('DatoDa').disabled = false;
}

function consultaLista(nombreConsulta, listaActual, listaSiguiente, categoria, seleccionActual, seleccionSiguiente) {
    var id = 0;
    listaActual = "#" + listaActual;
    listaSiguiente = "#" + listaSiguiente;
    if (seleccionSiguiente === null) {
        id = $(listaActual).val();
    }
    else {
        id = seleccionSiguiente
    };
    if (nombreConsulta != null) {
        $.ajax
        ({
            url: raiz + '/Productividad/' + nombreConsulta,
            type: 'POST',
            datatype: 'application/json',
            contentType: 'application/json',
            data: JSON.stringify({
                id: id
            }),
            beforeSend: function () {
                $("#load").show();
            },
            success: function (respuesta) {
                $(listaSiguiente).html("");
                var textoSeleccion = "";
                $(listaSiguiente).append($('<option selected disabled></option>').val(0).html(textoSeleccion + categoria));
                $.each(respuesta, function (i, elemento) {
                    if (listaSiguiente == '#seleccionDepartamento')
                    {
                        marcarDepartamento(elemento.dato1);
                    }
                    $(listaSiguiente).append($('<option></option>').val(elemento.codigo).html(elemento.nombre));
                });
                if (respuesta.length > 0) {
                    $(listaSiguiente).removeAttr('disabled');
                }
                else {
                    $(listaSiguiente).append($('<option></option>').val(0).html("No hay " + categoria + "s"));
                    $(listaSiguiente).prop("disabled", true);
                }
                $(listaSiguiente).val(seleccionActual);
                comprobarRequisitosCalculo();
                $("#load").hide();
            },
            error: function (error) {
                alert("Error: " + error);
            }
        });
    }
    else {
        $(listaSiguiente).prop("disabled", false);
        $(listaSiguiente).val(seleccionActual);
    }
}

$("#seleccionCultivo").change(function () {
    consultaLista("ConsultaDepartamentos", "seleccionCultivo", "seleccionDepartamento", "Departamento", "0", null);
    iniciarLista(1, 6);
    var valor = $("#seleccionCultivo").val();
    reiniciarMarcaDepartamentos();
    quitarEstaciones();
    apagarCajasFecha();
    apagarCajasSuelo();
    $("#btn-Calcular").prop("disabled", true);
    $("#mapa").removeClass("oculto");
    $("#resultados").addClass("oculto");
    $("#btn-Limpiar").prop("disabled", false);
});
$("#seleccionDepartamento").change(function () {
    consultaLista(null, "seleccionDepartamento", "seleccionOrigenDatos", "Origen de datos", "0", null);
    iniciarLista(2, 6);
    var val = $("#seleccionDepartamento").val();
    var nombre = $("#seleccionDepartamento :selected").text();
    var valC = $("#seleccionCultivo").val();
    reiniciarMarcaDepartamentos();
    quitarEstaciones();
    acercarDepartamento(val);
    apagarCajasFecha();
    apagarCajasSuelo();
    iniciarDatosFecha();
    $("#btn-Calcular").prop("disabled", true);
    $("#mapa").removeClass("oculto");
    $("#resultados").addClass("oculto");
});
$("#seleccionOrigenDatos").change(function () {
    var val = $("#seleccionOrigenDatos :selected").text();
    if (val == "Sistema") {
        consultaLista("ConsultaEstaciones", "seleccionDepartamento", "seleccionEstacion", "Estación", "0", null);
        iniciarLista(3,6)
    }
    else {
        iniciarLista(5, 6)
    }
    apagarCajasFecha();
    comprobarRequisitosCalculo();
});
$("#seleccionEstacion").change(function () {
    consultaLista("ConsultaAnho", "seleccionEstacion", "siembra-anho", "Año", "0", null);
    var nombre = $("#seleccionEstacion :selected").text();
    var codigoEstacion = nombre.substr(nombre.length - 7);
    agregarEstacion(codigoEstacion);
    iniciarDatosFecha();
    iniciarLista(4, 6);
    $("#btn-Calcular").prop("disabled", true);
    $("#mapa").removeClass("oculto");
    $("#resultados").addClass("oculto");
});
$("#siembra-anho").change(function () {
    $('#seleccionFechaSiembra').prop("disabled", false);
    $('#seleccionFechaSiembra').datepicker("option", "disabled", false);
    $('#siembra-mes').prop("disabled", false);
    if (anhoBisiesto($("#siembra-anho").val()))
    {
        if ($("siembra-mes").val()===2)
        {
            $('#siembra-dia').append($('<option value="29">29</option>'));
        }
    }
    console.log(comprobarRequisitosCalculo());
});
$("#siembra-mes").change(function () {
    $('#siembra-dia').prop("disabled", false);
    $('#siembra-dia').html("");
    $('#siembra-dia').append($('<option value="0" selected disabled>Día</option>'));
    var mesSeleccionado = $("#siembra-mes").val();
    var anho = $("#siembra-anho").val();
    for (var i = 1; i <= 28; i++)
    {
        $('#siembra-dia').append($('<option value='+i+'>'+i+'</option>'));
    }
    if(mesSeleccionado != 2)
    {
        $('#siembra-dia').append($('<option value="29">29</option>'));
        $('#siembra-dia').append($('<option value="30">30</option>'));
    }
    else if(anhoBisiesto(anho))
    {
        $('#siembra-dia').append($('<option value="29">29</option>'));
    }
    var meses31 = [1, 3, 5, 7, 8, 10, 12];
    if (enVector(mesSeleccionado,meses31))
    {
        $('#siembra-dia').append($('<option value="31">31</option>'));
    }
});
$("#siembra-dia").change(function () {
    $('#seleccionSuelo').prop("disabled", false);
    comprobarRequisitosCalculo();
});

$("#seleccionSuelo").change(function () {
    apagarCajasSuelo();
    sueloid = $(this).val();
    if (sueloid !== "" && sueloid !== "Seleccione un tipo de suelo") {
        $.ajax({
            url: raiz + '/Productividad/AutoFiltroSuelo',
            dataType: "json",
            data: { term: sueloid },
            success: function (data) {
                var name, select, option;
                $('#DatoCC').val(data.CC.toFixed(2));
                $('#DatoPMP').val(data.PMP.toFixed(2));
                $('#DatoDa').val(data.Da.toFixed(2));
            }
        });
    }
    if (sueloid != 0) {
        EditarSuelo();
        $('#seleccionSuelo').removeAttr('disabled');;
    }
    comprobarRequisitosCalculo();
});

function enVector(valor, arreglo) {
    var longitud = arreglo.length;
    for (var i = 0; i < longitud; i++) {
        if (arreglo[i] == valor)
            return true;
    }
    return false;
}

function iniciarLista(inicio, fin) {
    for (var i = inicio; i <= fin; i++) {
        lista = "#" + arregloListas[i].lista;
        categoria = arregloListas[i].categoria;
        $(lista).prop('disabled', true);
    };
    $("#" + arregloListas[inicio].lista).prop('disabled', false);
    $("#" + arregloListas[inicio].lista).val(0);
};

$("#seleccionOrigenDatos").change(function () {
    if ((this).value==="1")
    {
        $("#CuadroDatosUsuario").addClass('oculto');
        $("#CuadroDatosSistema").removeClass('oculto');
    }
    else
    {
        $("#CuadroDatosUsuario").removeClass('oculto');
        $("#CuadroDatosSistema").addClass('oculto');
    }
});

function apagarCajasSuelo()
{
    $('#DatoCC').prop("disabled", true);
    $('#DatoPMP').prop("disabled", true);
    $('#DatoDa').prop("disabled", true);
}

function apagarCajasFecha() {
    $('#siembra-anho').prop("disabled", true);
    $('#siembra-mes').prop("disabled", true);
    $('#siembra-dia').prop("disabled", true);
}

function apagarCajas(variable) {
    switch (variable) {
        case "suelo":
            $('#DatoCC').prop("disabled", true);
            $('#DatoPMP').prop("disabled", true);
            $('#DatoDa').prop("disabled", true);
            break;
        case "fecha":
            $('#siembra-anho').prop("disabled", true);
            $('#siembra-mes').prop("disabled", true);
            $('#siembra-dia').prop("disabled", true);
            break;
        case "estacion":
            $('#seleccionEstacion').prop("disabled", true);
            break;
        case "departamento":
            $('#seleccionDepartamento').prop("disabled", true);
            break;
        case "origen":
            $('#seleccionOrigenDatos').prop("disabled", true);
            break;
        case "estacion":
            $('#seleccionEstacion').prop("disabled", true);
            break;
    }
}

function iniciarDatosFecha() {
    $('#siembra-anho').val(0);
    $('#siembra-mes').val(0);
    $('#siembra-dia').val(0);
}

function iniciarDatosSuelo() {
    $('#DatoCC').val("");
    $('#DatoPMP').val("");
    $('#DatoDa').val("");
}

function anhoBisiesto(anho) {
    if(( anho % 100 != 0) && ((anho % 4 == 0) || (anho % 400 == 0)))
    {
        return true;
    }
    return false;
}

function comprobarRequisitosCalculo()
{
    listaCajas = ["seleccionCultivo", "seleccionDepartamento", "seleccionOrigenDatos", "seleccionEstacion",
        "siembra-anho", "siembra-mes", "siembra-dia", "seleccionSuelo"];

    if ($("#seleccionOrigenDatos").val() == 2) {
        listaCajas.splice(listaCajas.indexOf("seleccionEstacion"), 1);
        console.log("listaCajas: " + listaCajas);
    }

    for (var i=0;i<listaCajas.length;i++)
    {
        
        if ($("#" + listaCajas[i]).val() == 0 || $("#" + listaCajas[i]).val() == null)
        {
            console.log("Valor " + listaCajas[i] + " : " + $("#" + listaCajas[i]).val());
            $("#btn-Calcular").prop('disabled', true);
            return false;
        }
    }
    $("#btn-Calcular").prop('disabled', false);
    return true;
}

function marcarDepartamento(listaDepartamentos) {
    arregloCapas[0].fuente.forEachFeature(function (feature) {
        if (feature.get('coddane') === listaDepartamentos) {
            style = new ol.style.Style({
                fill: new ol.style.Fill({
                    color: 'rgba(116,31,28,0.5)'
                }),
                stroke: new ol.style.Stroke({
                    color: 'rgb(115,115,115)',
                    width: 1.5
                })
            });
            feature.setStyle(style);
        }
    });
};

function reiniciarMarcaDepartamentos() {
    arregloCapas[0].fuente.forEachFeature(function (feature) {
        style = new ol.style.Style({
            fill: new ol.style.Fill({
                color: 'rgba(230,201,99,0.25)'
            }),
            stroke: new ol.style.Stroke({
                color: 'rgb(115,115,115)',
                width: 1.5
            })
        });
        feature.setStyle(style);
    });
    map.getView().fit([-8795801.562415265, -466393.3042026925, -7445942.483830706, 1399645.1725650658], map.getSize());
};

function acercarDepartamento(codigoDepartamento) {
    for (var i = 0; i < coordenadasDpto.length; i++) {
        if (coordenadasDpto[i].codigo === codigoDepartamento) {
            var extent = coordenadasDpto[i].coordenadas.replace('[', '').replace(']', '');
            var coord = extent.split(',');
            style = new ol.style.Style({
                fill: new ol.style.Fill({
                    color: 'rgba(116,31,28,0.25)'
                }),
                stroke: new ol.style.Stroke({
                    color: 'rgb(115,115,115)',
                    width: 1.5
                })
            });
            arregloCapas[0].fuente.forEachFeature(function (feature) {
                if (feature.get('coddane') === coordenadasDpto[i].codigoDane) {
                    feature.setStyle(style);
                }
            });
            map.getView().fit(coord, map.getSize());
            break;
        }
    }
}

function marcarEstacion(codigoEstacion) {
    style2 = new ol.style.Style({
        image: new ol.style.Circle({
            radius: 1,
            fill: new ol.style.Fill({
                color: 'rgba(0,0,0,0.5)'
            }),
        })
    });
    arregloCapas[1].fuente.forEachFeature(function (feature) {
        if (feature.get('codigo') === codigoEstacion) {
            style1 = new ol.style.Style({
                image: new ol.style.Circle({
                    radius: 1,
                    fill: new ol.style.Fill({
                        color: 'rgba(0,255,0,0.5)'
                    }),
                })
            });
            feature.setStyle(style1);
        }
        else {
            feature.setStyle(style2);
        }
    });
};