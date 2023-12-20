var Fechas = []
let Temp_aire = []; 
let Acumulado = [];
let Acumulado_proceso = 0;
let bandera = false;
let opc1 = 0;
let flag = 0;
let dia_eti = [];
let J = [];
let Kc = [];
let Eto_mm = [];
let P_mm = [];
let ISNH1 = [];
let ISNHA = [];

function Total_dias() {
    /*if (opc1 == 1) {
        var Hoy = new Date("2021-09-10");
    } else { var Hoy = new Date(); }*/
    var Hoy = new Date();
    var Hoy_str = Hoy.getFullYear() + "-" + (Hoy.getMonth() + 1) + "-" + Hoy.getDate();
    var Fecha_siem = document.getElementById("Fechao").value;
    var uno_d = new Date(Hoy_str);
    var dos_d = new Date(Fecha_siem);
    var Total_d = Math.round((uno_d.getTime() - dos_d.getTime()) / (1000 * 60 * 60 * 24));
    return Total_d;
}

function formato_fecha(fech_mem) {
    var dd = fech_mem.getDate();
    var mm = fech_mem.getMonth() + 1; //January is 0!
    var yyyy = fech_mem.getFullYear();
    if (dd < 10) { dd = '0' + dd; }
    if (mm < 10) { mm = '0' + mm; }
    fech_mem = yyyy + '-' + mm + '-' + dd;
    return fech_mem;
}

function saturador(eti) {
    if (parseInt(document.getElementById(eti).max) < parseInt(document.getElementById(eti).value)) {
        document.getElementById(eti).value = 152;
    }
    if (parseInt(document.getElementById(eti).value) < parseInt(document.getElementById(eti).min)) {
        document.getElementById(eti).value = 1;
    }
}

function Var_iniciales() {
    //Condiciones iniciales
    var today = formato_fecha(new Date());
    document.getElementById("Fechao").disabled = false;
    document.getElementById("Fechao").max = today;
    document.getElementById("Fechao").min = "2020-01-01";
    document.getElementById("Fechao").value = "2023-09-10";
    //OPCIÓN
    opc1 = document.getElementById("opcion_dat").value;
    if (opc1 == 0) {
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP01 - CASATEJA";
    } else if (opc1 == 1) {
        document.getElementById("dias").value = 99;
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP02 - CI TIBAITATA";
    } else if (opc1 == 2) {
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP03 - LA FORTUNA";
    }
    document.getElementById("dias").value = 99;
}

function act_fecha_dia() {
    var Total_d = Total_dias();
    if (Total_d < 152) {
        document.getElementById("dias").value = Total_d;
        document.getElementById("dias").max = Total_d;
    } else {
        document.getElementById("dias").value = 152;
        document.getElementById("dias").max = 152;
    }
    document.getElementById("dias").disabled = false;
    if (Total_d <= 0) {
        document.getElementById("dias").disabled = true;
        document.getElementById("dias").value = 1;
    }
}

function Leer_csv() {
    if (document.getElementById("dias").value <= 0) {
        document.getElementById("dias").value = 1;
    }
    if (bandera == false) {
        Var_iniciales();
        bandera = true;
    }
    try {
        let longitud = parseInt(document.getElementById("dias").value);
        var Fecha_siem = document.getElementById("Fechao").value;
        opc1 = document.getElementById("opcion_dat").value;
        //Reiniciar valores
        Fechas = [];
        Eto_Calc_mm_d_1 = [];
        Precipitacion_mm = [];
        dia_eti = [];
        J = [];
        Kc = [];
        P_efec_mm = [];
        P_mm = [];
        Eto_mm = [];
        ETcaj_mm = [];
        ISNH1 = [];
        ISNHA = [];
        var aux_acu = 0;
        //Leer csv
        var Est = 0;
        var Fech = "Est1_Fecha";
        let L_json = 0;
        var FechasRep = [];
        var EvapotransRep = [];
        var PrecipitaRep = [];

        if (opc1 == 0) {
            L_json = Estjson.Fecha1.length;
            FechasRep = Estjson.Fecha1;
            EvapotransRep = Estjson.Evapo1;
            PrecipitaRep = Estjson.Preci1;
            //Est = JSON.parse(Estacion1);
            //Fech = "Est1_Fecha";
        } else if (opc1 == 1) {
            L_json = Estjson.Fecha2.length;
            FechasRep = Estjson.Fecha2;
            EvapotransRep = Estjson.Evapo2;
            PrecipitaRep = Estjson.Preci2;
            //Est = JSON.parse(Estacion2);
            //Fech = "Est2_Fecha";
        } else {
            L_json = Estjson.Fecha3.length;
            FechasRep = Estjson.Fecha3;
            EvapotransRep = Estjson.Evapo3;
            PrecipitaRep = Estjson.Preci3;
            //Est = JSON.parse(Estacion3);
            //Fech = "Est3_Fecha";
        }
        //Datos de la estacion
        var Fecha_siem_1 = document.getElementById("Fechao").value;

        var Fecha_siem_2 = new Date(Fecha_siem_1);
        Fecha_siem_2.setDate(Fecha_siem_2.getDate());
        Fecha_siem_2.setDate(Fecha_siem_2.getDate() + longitud);
        Fecha_siem_2 = formato_fecha(Fecha_siem_2);
        //let L_json = Object.keys(Est[0][Fech]).length;

        //Extraer del json
        for (var i = 1; i < longitud+1; i++) {
            var memoria_ETO = 0;
            var memoria_Prec = 0;
            var Fecha_siem_3 = new Date(Fecha_siem_1);
            Fecha_siem_3.setDate(Fecha_siem_3.getDate() + i);
            Fecha_siem_3 = formato_fecha(Fecha_siem_3).toString();
            for (var j = 0; j < L_json; j++) {
                var Fecha_temp = formato_fecha(new Date(FechasRep[j].toString()));
                if (Fecha_temp == Fecha_siem_3) {
                    memoria_ETO = parseFloat(EvapotransRep[j]) + memoria_ETO;
                    memoria_ETO = Math.round(memoria_ETO * 100) / 100;
                    memoria_Prec = parseFloat(PrecipitaRep[j]) + memoria_Prec;
                    memoria_Prec = Math.round(memoria_Prec * 100) / 100;
                }
            }
            Fechas.push(Fecha_siem_3);
            Eto_Calc_mm_d_1.push(memoria_ETO);
            Precipitacion_mm.push(memoria_Prec);
        }
        let Kcini = 0.73; //Coeficientes del cultivo por etapas
        let Kcmed = 0.87;
        let Kcfin = 0.80;

        let Lini = 27; // Duración etapa (dias) Para ciclo 2:35
        let Ldes = 39; // Para ciclo 2:30
        let Lmed = 47; // Para ciclo 2:53
        let Lfin = 42; // Para ciclo 2:20

        let nr = longitud;
        let dia = 1; //dia que inicia el balance. Se asume que inicia en capacidad de campo
        let con = 1;
        let a = 0.9;
        //Crear variables de dataframe en JS

        for (var j = con - 1; j < nr; j++) {
            J.push(dia + j);

            //Cálculo de coeficiente del cultivo Kc
            if (J[j] <= Lini) {
                Kc.push(Kcini);
            } else if (J[j] <= (Lini + Ldes)) {
                var num_aux = Kcini + (((J[j] - Lini) / Ldes) * (Kcmed - Kcini));
                num_aux = Math.round(num_aux * 100) / 100;
                Kc.push(num_aux);
            } else if (J[j] <= (Lini + Ldes + Lmed)) {
                Kc.push(Kcmed);
            } else {
                var num_aux = Kcmed + (((J[j] - (Lini + Ldes + Lmed)) / Lfin) * (Kcfin - Kcmed));
                num_aux = Math.round(num_aux * 100) / 100;
                Kc.push(num_aux);
            }

            let num_aux_2 = 0;
            //Cálculo de la evapotranspiración del cultivo ajustado ETcaj
            num_aux_2 = Eto_Calc_mm_d_1[j] * Kc[j];
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            ETcaj_mm.push(num_aux_2);

            //Cálculo de la precipitación efectiva
            num_aux_2 = Precipitacion_mm[j] * a;
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            P_efec_mm.push(num_aux_2);

            P_mm.push(Precipitacion_mm[j]);
            Eto_mm.push(Eto_Calc_mm_d_1[j]);

            //Calculo ISNH
            num_aux_2 = P_mm[j] * 100 / Eto_mm[j];
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            ISNH1.push(num_aux_2)

            //Aviso
            var texto22 = "";
            if (num_aux_2 <= 55) {
                texto22 = "Inadecuado ISNH";
            } else if (num_aux_2 > 55 & num_aux_2 <= 65) {
                texto22 = "Marginal ISNH";
            } else {
                texto22 = "Adecuado ISNH";}
            ISNHA.push(texto22);
        }

    } catch (err) {
        console.log(err);
    }
}

function CalcularISNH() {
    $('#load').show();

    setTimeout(function(){
        //Bloquear interfaz
        document.getElementById("Fechao").disabled = true;
        document.getElementById("dias").disabled = true;

        Leer_csv();

        //Crear tabla
        let tab1 = document.getElementById("tab_reporte");
        tab1.innerHTML = "";

        var tcab = document.createElement("thead");
        var tfot = document.createElement("tfoot");
        var tbod = document.createElement("tbody");

        //Rotulos cabeza
        var titulos = document.createElement("tr");
        var lista_titulos = ["Fecha", "Dia", "Et0_mm", "Kc", "Etc_mm", "PPT_mm", "ISNH_a", "ISNH_b"];
        for (let i = 0; i < lista_titulos.length; i++) {
            var celda = document.createElement("th");
            var textoCelda = document.createTextNode(lista_titulos[i]);
            celda.appendChild(textoCelda);
            titulos.appendChild(celda);
        }
        //Rotulos pie de pagina
        var piespag = document.createElement("tr");
        for (let i = 0; i < lista_titulos.length; i++) {
            var celda = document.createElement("th");
            var textoCelda = document.createTextNode(lista_titulos[i]);
            celda.appendChild(textoCelda);
            piespag.appendChild(celda);
        }

        //Contenido
        for (let i = 0; i < J.length; i++) {
            var fila = document.createElement("tr");
            for (let j = 0; j < 8; j++) {
                var celda = document.createElement("td");
                var textoCelda;
                if (j == 0) { textoCelda = document.createTextNode(Fechas[i].toString()); } 
                else if (j == 1) { textoCelda = document.createTextNode(J[i].toString()); }
                else if (j == 2) { textoCelda = document.createTextNode(Eto_mm[i].toString()); }
                else if (j == 3) { textoCelda = document.createTextNode(Kc[i].toString()); }
                else if (j == 4) { textoCelda = document.createTextNode(ETcaj_mm[i].toString()); }
                else if (j == 5) { textoCelda = document.createTextNode(P_mm[i].toString()); }
                else if (j == 6) { textoCelda = document.createTextNode(ISNH1[i].toString()); }
                else { textoCelda = document.createTextNode(ISNHA[i].toString()); }
                celda.appendChild(textoCelda);
                fila.appendChild(celda);
            }
            tbod.appendChild(fila);
        }

        //Generar
        tcab.appendChild(titulos);
        tfot.appendChild(piespag);
        tab1.appendChild(tcab);
        tab1.appendChild(tbod);
        tab1.appendChild(tfot);
        tab1.setAttribute("class", "table table-bordered");
        tab1.setAttribute("width", "100%");
        tab1.setAttribute("cellspacing", "0");

        const divContenedor = document.getElementById('tabladiv');
        const tabla = document.getElementById('tab_reporte');

        // Obtén la altura del div contenedor después de haber realizado las ediciones
        const alturaContenedor = divContenedor.clientWidth;

        // Establece la altura de la tabla igual a la altura del div contenedor
        tabla.style.height = alturaContenedor + 'px';

        //Desbloquear interfaz
        //if (opc1 != 1) { }
        document.getElementById("Fechao").disabled = false;
        document.getElementById("dias").disabled = false;

        if (flag != 0) {
            $('#modal2a').modal('show');
        }
        else { flag = 1;}
        $('#load').hide();
        
    }, 100);
}

function Exportarcsv(filename) {
    var csv = [" "];
    var rows = document.querySelectorAll("#tab_reporte tr");
    for (var i = 0; i < rows.length; i++) {
        var row = [],
            cols = rows[i].querySelectorAll("#tab_reporte th, #tab_reporte td");
        for (var j = 0; j < cols.length; j++) {
            //unir contenido de las filas
            row.push(cols[j].innerText);
        }
        //poner en el arreglo de salida
        csv.push([row]);
        csv.push(["\n"]);
    }
    //Función para descargar el archivo en formato csv 
    DescargaCSV(csv, filename);
}

function DescargaCSV(csv, nombrearchivo) {
    var csvFile;
    var downloadLink;
    // Crear objeto blob csv
    csvFile = new Blob([csv], { type: "text/csv" });
    // Crear link de descarga
    downloadLink = document.createElement("a");
    // Asignar link de descarga
    downloadLink.download = nombrearchivo;
    // Crear link al archivo
    downloadLink.href = window.URL.createObjectURL(csvFile);
    // Ocultar link
    downloadLink.style.display = "none";
    // Agregar link de descarga
    document.body.appendChild(downloadLink);
    // Ejecutar función
    downloadLink.click();
}