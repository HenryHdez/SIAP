var Fechas = []
let Temp_aire = []; 
let Acumulado = [];
let Acumulado_proceso = 0;
let bandera = false;
let opc1 = 0;
let flag = 0;
let dia_eti = [];

//Leer historico de las estaciones meteorologicas
var Temp_E15_1 = [];
var Temp_E15_2 = [];
var Temp_E15_3 = [];
var Temp_E30_1 = [];
var Temp_E30_2 = [];
var Temp_E30_3 = [];

fetch('../Content/DATOS_Estaciones.xlsx').then(res => {
        return res.arrayBuffer();
    }).then(res => {
        var workbook = XLSX.read(new Uint8Array(res), {
            type: 'array'
        });
        workbook.SheetNames.forEach(sheet => {
            if (sheet == "TIBA30") { Temp_E30_1 = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]);}
            else if (sheet == "TIBA15") { Temp_E15_1 = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]); }
            else if (sheet == "FACA30") { Temp_E30_2 = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]); }
            else if (sheet == "FACA15") { Temp_E15_2 = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]); }
            else if (sheet == "SUBA30") { Temp_E30_3 = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]); }
            else if (sheet == "SUBA15") { Temp_E15_3 = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]); }
        });
    });

function Total_dias() {
    if (opc1 == 1) {
        var Hoy = new Date("2021-09-10");
    } else { var Hoy = new Date(); }
    var Hoy_str = Hoy.getFullYear() + "-" + (Hoy.getMonth() + 1) + "-" + Hoy.getDate();
    var Fecha_siem = document.getElementById("Fechao").value;
    var uno_d = new Date(Hoy_str);
    var dos_d = new Date(Fecha_siem);
    var Total_d = Math.round((uno_d.getTime() - dos_d.getTime()) / (1000 * 60 * 60 * 24));
    return Total_d;
}

function formato_fecha(fech_mem) {
    var dd = fech_mem.getDate();
    var mm = fech_mem.getMonth() + 1;
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
    document.getElementById("Fechao").value = "2023-01-06";
    //OPCIÓN
    opc1 = document.getElementById("opcion_dat").value;
    if (opc1 == 0) {
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP01 - CASATEJA";
    } else if (opc1 == 1) {
        //document.getElementById("Fechao").disabled = true;
        document.getElementById("Fechao").value = "2021-01-01";
        document.getElementById("Fechao").max = "2021-09-09";
        document.getElementById("dias").value = 152;
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP02 - CI TIBAITATA";
    } else if (opc1 == 2) {
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP03 - LA FORTUNA";
    }
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

function Dia_ano(fecha_ingr) {
    // Crear una instancia del objeto Date con la fecha actual
    const today = new Date(fecha_ingr);//new Date();
    // Obtener el año actual
    const year = today.getFullYear();
    // Crear una nueva instancia del objeto Date para el 1 de enero del año actual
    const firstDayOfYear = new Date(year, 0, 1);
    // Calcular la diferencia en milisegundos entre la fecha actual y el 1 de enero
    const differenceInMilliseconds = today - firstDayOfYear;
    // Convertir la diferencia de milisegundos a días (1 día = 24 horas * 60 minutos * 60 segundos * 1000 milisegundos)
    const dayOfYear = Math.floor(differenceInMilliseconds / (24 * 60 * 60 * 1000)) + 1;
    // El resultado es el número del día del año
    return dayOfYear;
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
        let longitud = parseInt(document.getElementById("dias").value)+1;
        var Fecha_siem = document.getElementById("Fechao").value;
        opc1 = parseInt(document.getElementById("opcion_dat").value);
        //Reiniciar valores
        Fechas = [];
        Temp_aire = [];
        Acumulado = [];
        dia_eti = [];
        var aux_acu = 0;

        //Leer csv e información historica de la temperatura
        var Est = 0;
        var Fech = "Est1_Fecha";
        let dia_res = [];
        let T_max = [];
        let T_min = [];
        let T_med1 = [];
        let T_med2 = [];
        let T1_aux = [];
        let T2_aux = [];

        var L_json = 0;
        var FechasRep=[];
        var TempRep=[];
        var PrecipitaRep=[];

        if (opc1 == 0) {
            L_json = Estjson.Fecha1.length;
            FechasRep=Estjson.Fecha1;
            TempRep=Estjson.TempPr1;
            //Est = JSON.parse(Estacion1);
            //Fech = "Est1_Fecha";
            T1_aux = Temp_E30_2;
            T2_aux = Temp_E15_2;
        } else if (opc1 == 1) {
            L_json = Estjson.Fecha2.length;
            FechasRep=Estjson.Fecha2;
            TempRep=Estjson.TempPr2;
            //Cambiar por 2 al final
            //Est = JSON.parse(Estacion2);
            //Fech = "Est2_Fecha";
            T1_aux = Temp_E30_1;
            T2_aux = Temp_E15_1;
        } else {
            L_json = Estjson.Fecha3.length;
            FechasRep=Estjson.Fecha3;
            TempRep=Estjson.TempPr3;
            //Cambiar por 3 al final
            //Est = JSON.parse(Estacion3);
            //Fech = "Est3_Fecha";
            T1_aux = Temp_E30_3;
            T2_aux = Temp_E15_3;
        }
        //console.log(L_json);
        //console.log(FechasRep);
        //console.log(TempRep);
        //Datos de la estacion
        var Fecha_siem_1 = document.getElementById("Fechao").value;
        var acumula_GDA_min = [];
        var acumula_GDA_max = [];
        var acumula_GDA_med1 = [];
        var acumula_GDA_med2 = [];
        let calc_T1_a = 0;
        let calc_T2_a = 0;
        let calc_T3_a = 0;
        let calc_T4_a = 0;
        let dia1_cult = 0;

        //Acondicionar vector de entrada
        dia1_cult = Dia_ano(Fecha_siem_1);
        for (var i = 0; i < 152; i++) {
            if (dia1_cult > 365) { dia1_cult = 0; }
            // Crear una instancia del objeto Date con la fecha actual
            const today = new Date(Fecha_siem_1);
            // Sumar un día a la fecha actual
            const tomorrow = new Date(today);
            tomorrow.setDate(today.getDate() + i);
            const options = { year: '2-digit', month: '2-digit', day: 'numeric' };
            const formattedTomorrow = tomorrow.toLocaleDateString(undefined, options);
            //dia_res.push(T1_aux[dia1_cult]["Dia"]);
            //dia_res.push(i);
            dia_res.push(formattedTomorrow);
            T_max.push(T1_aux[dia1_cult]["Promedio de Tmax"]);
            T_min.push(T1_aux[dia1_cult]["Promedio de Tmin"]);
            T_med1.push(T1_aux[dia1_cult]["Promedio de Tmed"]);
            T_med2.push(T2_aux[dia1_cult]["Promedio de Tmed"]);
            dia1_cult = dia1_cult + 1;
        }

        for (var i = 0; i < 152; i++) {
            calc_T1_a = calc_T1_a + (parseFloat(T_min[i]) - 2);
            acumula_GDA_min.push(calc_T1_a);
            calc_T2_a = calc_T2_a + (parseFloat(T_max[i]) - 2);
            acumula_GDA_max.push(calc_T2_a);
            calc_T3_a = calc_T3_a + (parseFloat(T_med1[i]) - 2);
            acumula_GDA_med1.push(calc_T3_a);
            calc_T4_a = calc_T4_a + (parseFloat(T_med2[i]) - 2);
            acumula_GDA_med2.push(calc_T4_a);
        }

        //Otros datos de la estación
        //let L_json = Object.keys(Est[0][Fech]).length;
        let mem_temp = 0;
        //Extraer del json
        for (var i = 1; i < longitud; i++) {
            var memoria_T = 0;
            var Temp_T = 0;
            var Temp_mem = 0;
            var contat = 0;
            var Fecha_siem_3 = new Date(Fecha_siem_1);
            Fecha_siem_3.setDate(Fecha_siem_3.getDate() + i);
            Fecha_siem_3 = formato_fecha(Fecha_siem_3).toString();
            for (var j = 0; j < L_json; j++) {
                var Fecha_temp = formato_fecha(new Date(FechasRep[j].toString()));
                if (Fecha_temp == Fecha_siem_3) {
                    contat++;
                    Temp_T = parseFloat(TempRep[j]);
                    memoria_T = Temp_T + memoria_T;
                    mem_temp = j;
                }
            }
            Temp_mem = memoria_T / contat;

            if (Temp_mem <= 0 || contat == 0) {
                let termina = 0;
                let acut22 = 0;
                let cuentatt = mem_temp;
                for (var j = 0; j < L_json; j++) {
                    let memt22 = parseFloat(TempRep[cuentatt]);
                    cuentatt = cuentatt + j;
                    if (cuentatt > L_json) { cuentatt = 0;}
                    if (memt22 > 0) {
                        acut22 = acut22 + memt22;
                        termina++;
                    }
                    if (termina == 5) { break; }
                }
                if (acut22 <= 0) { Temp_mem = 10; }
                else { Temp_mem = acut22 / 5; }
            }
            //Calculo de GDA desde el JSON
            Temp_mem = Math.round(Temp_mem * 100) / 100;
            aux_acu = aux_acu + Temp_mem - 2;
            aux_acu = Math.round(aux_acu * 100) / 100;
            Fechas.push(Fecha_siem_3);
            dia_eti.push(i);
            Temp_aire.push(Temp_mem);
            Acumulado.push(aux_acu);
            Acumulado_proceso = aux_acu;
        }
        
        //Graficas
        const today = new Date(Fecha_siem_1);
        const tomorrow = new Date(today);
        tomorrow.setDate(today.getDate() + (longitud - 1));
        const options = { year: '2-digit', month: '2-digit', day: 'numeric' };
        const formattedTomorrow = tomorrow.toLocaleDateString(undefined, options);
        //Graficar temperatura
        var trac1 = [
            {
                x: dia_res, y: T_min, stackgroup: 'one', name: 'Minimo', fill: 'none',
                marker: {
                    color: 'rgb(155, 155, 155)',
                    opacity: 0.5,
                    size: 10,
                    line: {
                        color: 'rgb(155, 155, 155, 0.5)',
                        width: 2
                    }
                },
                showlegend: false
            },
            {
                type: 'scatter',
                x: [formattedTomorrow, formattedTomorrow],
                y: [0, 40],
                mode: 'lines',
                name: 'Días despues de la siembra o fecha actual',
                line: { color: 'yellow', width: 5 }
            },
            { x: dia_res, y: T_med1, name: 'Tempertura promedio [30 años (1990-2020)]', type: 'scatter' },
            { x: dia_res, y: T_med2, name: 'Tempertura promedio [15 años (2005-2020)]', type: 'scatter' },
            { x: dia_res, y: Temp_aire, name: 'Temperatura diara promedio registrada por la estación', type: 'scatter' },
            {
                x: dia_res, y: T_max, stackgroup: 'one', name: 'Error', fill: 'tonexty', fillcolor: 'rgba(155, 155, 155, 0.5)',
                marker: {
                    color: 'rgb(155, 155, 155)',
                    opacity: 0.5,
                    size: 10,
                    line: {
                        color: 'rgb(155, 155, 155, 0.5)',
                        width: 2
                    }
                }
            }
        ];
        var laya1 = {
            xaxis: {
                title: 'Día del año',
                dtick: 10
            },
            yaxis: { title: 'Temperatura [°C]' },
            legend: {
                x: 0,
                xanchor: 'left',
                y: -1,
                xanchor: 'top'
            },
            colorbar: true,
            barmode: 'relative',
            title: 'Temperatura registrada e histórica ',
            width: 600
        };
        //Graficar GDA
        var trac2 = [
            {
                x: dia_res, y: acumula_GDA_min, stackgroup: 'one', name: 'Minimo', fill: 'none',
                marker: {
                    color: 'rgb(155, 155, 155)',
                    opacity: 0.5,
                    size: 10,
                    line: {
                        color: 'rgb(155, 155, 155, 0.5)',
                        width: 2
                    }
                },
                showlegend: false
            },
            {
                type: 'scatter',
                x: [formattedTomorrow, formattedTomorrow],
                y: [0, 4000],
                mode: 'lines',
                name: 'Días después de la siembra o fecha actual',
                line: { color: 'yellow', width: 5 }
            },
            { x: dia_res, y: acumula_GDA_med1, name: 'GDA promedio [30 años (1990-2020)]', type: 'scatter' },
            { x: dia_res, y: acumula_GDA_med2, name: 'GDA promedio [15 años (2005-2020)]', type: 'scatter' },
            { x: dia_res, y: Acumulado, name: 'GDA estimados por la aplicación', type: 'scatter' },
            {
                x: dia_res, y: acumula_GDA_max, stackgroup: 'one', name: 'Error', fill: 'tonexty', fillcolor: 'rgba(155, 155, 155, 0.5)',
                marker: {
                    color: 'rgb(155, 155, 155)',
                    opacity: 0.5,
                    size: 10,
                    line: {
                        color: 'rgb(155, 155, 155, 0.5)',
                        width: 2
                    }
                }
            }
        ];
        var laya2 = {
            xaxis: {
                title: 'Día del año',
                dtick: 10
            },
            yaxis: { title: 'Grados día acumulados [°C]' },
            legend: {
                x: 0,
                xanchor: 'left',
                y: -1,
                xanchor: 'top'
            },
            colorbar: true,
            barmode: 'relative',
            title: 'GDA registrados e históricos',
            width: 600
        };

        Plotly.newPlot("GDA_Temp2", trac1, laya1);
        Plotly.newPlot("GDA_Temp1", trac2, laya2);

    } catch (err) {
        console.log(err);
    }
}

function CalcularGDA() {
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
        var lista_titulos = ["Fecha", "Día", "Temperatura promedio por día [°C]", "Temperatura promedio acumulada [°C]"];
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
        for (let i = 0; i < dia_eti.length; i++) {
            var fila = document.createElement("tr");
            for (let j = 0; j < 4; j++) {
                var celda = document.createElement("td");
                var textoCelda;
                if (j == 0) { textoCelda = document.createTextNode(Fechas[i].toString()); } 
                else if (j == 1) { textoCelda = document.createTextNode(dia_eti[i].toString()); }
                else if (j == 2) { textoCelda = document.createTextNode(Temp_aire[i].toString()); } 
                else { textoCelda = document.createTextNode(Acumulado[i].toString()); } 
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
        //>>>>>>>>>>>>>>>>>>>>>>>>Descripciones<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //Riego
        var texto_descp1=" ";
        var texto_descp2=" ";
        if(Acumulado_proceso>=0 && Acumulado_proceso<=59){
            texto_descp1="brotación";
            texto_descp2="su cultivo debe estar en el periodo de brotación, con aparición de los primeros tallos y yemas.";
        }
        else if(Acumulado_proceso>59 && Acumulado_proceso<=206){
            texto_descp1="brotación + desarrollo de hojas + alargamiento del tallo principal";
            texto_descp2="su cultivo debe estar en el periodo de brotación, con aparición de tallos y yemas; así mismo, debe estar en desarrollo continuo y sostenido de las hojas, así como en crecimiento del tallo principal.";        
        }
        else if(Acumulado_proceso>206 && Acumulado_proceso<=283){
            texto_descp1="brotación + desarrollo de hojas + formación de brotes laterales + alargamiento del tallo principal";
            texto_descp2="su cultivo debe encontrarse finalizando el periodo de brotación; no obstante, debe seguir un desarrollo continuo y sostenido de las hojas y la elongación del tallo principal.  En este momento, debe iniciar la formación de los brotes laterales, tanto aéreos como subterráneos.";        
        }
        else if(Acumulado_proceso>283 && Acumulado_proceso<=522){
            texto_descp1="desarrollo de hojas + formación de brotes laterales + alargamiento del tallo principal";
            texto_descp2="su cultivo debe encontrarse en pleno desarrollo de las hojas y aún en proceso de elongación del tallo principal. En este momento continua con la formación de los brotes laterales, tanto aéreos como subterráneos.";        
        }
        else if(Acumulado_proceso>522 && Acumulado_proceso<=603){
            texto_descp1="desarrollo de hojas + formación de brotes laterales + alargamiento del tallo principal + inflorescencia (emergencia)";
            texto_descp2="su cultivo debe encontrarse en pleno desarrollo de las hojas y aún en proceso de elongación del tallo principal. En este momento continua en la formación de los brotes laterales, tanto aéreos como subterráneos, así como iniciar el periodo de inflorescencia.";        
        }
        else if(Acumulado_proceso>603 && Acumulado_proceso<=794){
            texto_descp1="desarrollo de hojas + formación de brotes laterales + alargamiento del tallo principal + inflorescencia (emergencia) + floración + formación de tubérculos";
            texto_descp2="su cultivo debe encontrarse en pleno desarrollo de las hojas y aún en proceso de alargamiento del tallo principal.  En este momento continua en la formación de los brotes laterales, tanto aéreos como subterráneos, así como el periodo de inflorescencia.  De la misma forma, debe iniciar el periodo de floración propiamente dicho y las primeras formaciones de los tubérculos.";        
        }
        
        if(Acumulado_proceso>794 && Acumulado_proceso<=931){
            if(document.getElementById("Tiporiego").value==0){
                texto_descp1="desarrollo de hojas + alargamiento del tallo principal + inflorescencia (emergencia) + floración + formación de tubérculos";
                texto_descp2="su cultivo debe encontrarse en desarrollo de las hojas y aún en proceso de alargamiento del tallo principal.  En este momento continua el periodo de inflorescencia y de floración, donde se consolida la formación de tubérculos.";    
            }   
        }

        if(Acumulado_proceso>794 && Acumulado_proceso<=867){
            if(document.getElementById("Tiporiego").value==1){
                texto_descp1="desarrollo de hojas + alargamiento del tallo principal + inflorescencia (emergencia) + floración + formación de tubérculos";
                texto_descp2="su cultivo debe encontrarse en desarrollo de las hojas y aún en proceso de alargamiento del tallo principal.  En este momento continua el periodo de inflorescencia y de floración, donde se consolida la formación de tubérculos.";    
            }    
        }
        
        if(Acumulado_proceso>931 && Acumulado_proceso<=1116){
            if(document.getElementById("Tiporiego").value==0){
                texto_descp1="desarrollo de hojas + alargamiento del tallo principal + inflorescencia (emergencia) + formación de tubérculos";
                texto_descp2="su cultivo debe estar finalizando el proceso de desarrollo de hojas y en la etapa final del proceso de alargamiento del tallo principal. En este momento continua el periodo de inflorescencia, consolidando la formación de tubérculos.";    
            }   
        }

        if(Acumulado_proceso>867 && Acumulado_proceso<=1116){
            if(document.getElementById("Tiporiego").value==1){
                texto_descp1="desarrollo de hojas + alargamiento del tallo principal + inflorescencia (emergencia) + formación de tubérculos";
                texto_descp2="su cultivo debe estar finalizando el proceso de desarrollo de hojas y en la etapa final del proceso de alargamiento del tallo principal. En este momento continua el periodo de inflorescencia, consolidando la formación de tubérculos.";    
            }    
        }

        if(Acumulado_proceso>1116 && Acumulado_proceso<=1181){
            if(document.getElementById("Tiporiego").value==0){
                texto_descp1="inflorescencia (emergencia) + formación de tubérculos";
                texto_descp2="su cultivo debe estar en el periodo de inflorescencia, consolidando la formación de tubérculos.";    
            }   
        }

        if(Acumulado_proceso>1116 && Acumulado_proceso<=1258){
            if(document.getElementById("Tiporiego").value==1){
                texto_descp1="inflorescencia (emergencia) + formación de tubérculos";
                texto_descp2="su cultivo debe estar en el periodo de inflorescencia, consolidando la formación de tubérculos.";    
            }    
        }

        if(Acumulado_proceso>1181 && Acumulado_proceso<=1677){
            if(document.getElementById("Tiporiego").value==0){
                texto_descp1="formación de tubérculos + senescencia";
                texto_descp2="su cultivo debe encontrarse en el periodo de formación de tubérculos, comenzando la senescecia.";    
            }   
        }

        if(Acumulado_proceso>1258 && Acumulado_proceso<=1677){
            if(document.getElementById("Tiporiego").value==1){
                texto_descp1="formación de tubérculos + senescencia";
                texto_descp2="su cultivo debe encontrarse en el periodo de formación de tubérculos, comenzando la senescecia.";    
            }    
        }

        if (Acumulado_proceso > 1677) {
                texto_descp1 = "formación de tubérculos + senescencia";
                texto_descp2 = "su cultivo debe encontrarse en el periodo de formación de tubérculos, comenzando la senescecia.";
        }

        //GDA WEB
        document.getElementById("GDA_Total1").innerText = "- Tiene un acumulado de " + Acumulado_proceso.toString()+ " grados días (°Gd).";
        document.getElementById("EtapaGDA1").innerText = "- Deberia estar en la etapa de " + texto_descp1 + ".";
        document.getElementById("DescripcionGDA1").innerText = "- En está etapa " + texto_descp2;
        //GDA Modal
        document.getElementById("GDA_Total2").innerText = "- Tiene un acumulado de " + Acumulado_proceso.toString() + " grados días (°Gd).";
        document.getElementById("EtapaGDA2").innerText = "- Deberia estar en la etapa de " + texto_descp1 + ".";
        document.getElementById("DescripcionGDA2").innerText = "- En está etapa " + texto_descp2;

        //Desbloquear interfaz
        //if (opc1 != 1) { document.getElementById("Fechao").disabled = false; }
        document.getElementById("Fechao").disabled = false;
        document.getElementById("dias").disabled = false;

        if (flag != 0) {
            $('#modal2a').modal('show');
        }
        else { flag = 1;}
        $('#load').hide();
        
    }, 500);
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