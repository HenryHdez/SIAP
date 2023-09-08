var Fechas = []
var Eto_Calc_mm_d_1 = []
var Etc_mm_d_1 = []
var Precipitacion_mm = [];
//Atributos de la matriz
let Fecha = []; //          R[1]
let P_mm = []; //P(mm)          R[2]
let Eto_mm = []; //Eto(mm)      R[3]
let J = []; //dia               R[4]
let Longitud_raiz_m = []; // R[5]
let Kc = []; // R[6]
let ADT_mm = []; // R[7]
let p_aj_mm = []; // R[8]
let AFA_mm = []; // R[9]
let Lamina_bruta_mm = []; //R[10]
let P_efec_mm = []; //R[11]
let Ks = []; //R[13] 
let ETcaj_mm = []; //R[14]  
let Perc_Prof_mm = []; //R[15]
let Dr_Final_mm = []; //R[16]
let bandera = false;
let opc1 = 0;
let flag_activa=0;
//Leer historico de las estaciones meteorologicas
var Coef_1q = [];
var Coef_2q = [];
var Coef_3q = [];

fetch('../Content/Coefi_Modelos.xlsx').then(res => {
    return res.arrayBuffer();
}).then(res => {
    var workbook = XLSX.read(new Uint8Array(res), {
        type: 'array'
    });
    workbook.SheetNames.forEach(sheet => {
        if (sheet == "Coeficientes_Epsilon") { Coef_1q = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]);}
        else if (sheet == "Coeficientes_FCsat") { Coef_2q = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]); }
        else if (sheet == "Coeficientes_RD") { Coef_3q = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheet]); }
    });
});

function Graf_est(elementoImg) {
    window.modal1.showModal();
    canvas3 = new fabric.Canvas(mapa_est);
    var object = canvas3.getActiveObject();
    var imagen_4 = new Image();
    imagen_4.src=elementoImg.src;
    var imgInstance_4 = new fabric.Image(imagen_4, {
        left:100,
        top: 100,
        angle: 0,
        opacity: 1,
        width: 4135,
        height: 5849,
        selectable: false
    });

    var zoom_6 =0.5;
    canvas3.add(imgInstance_4);
    canvas3.setZoom(zoom_6);
    canvas3.on('mouse:wheel', function(opt) {
        var delta = opt.e.deltaY;
        console.log(zoom_6);
        zoom_6 = canvas3.getZoom();
        zoom_6 *= 0.999 ** delta;
        if (zoom_6 > 2) zoom_6 = 2;
        if (zoom_6 < 0.001) zoom_6 = 0.001;
        canvas3.setZoom(zoom_6);
        opt.e.preventDefault();
        opt.e.stopPropagation();
    });
}

function Total_dias() {
    if (opc1 == 3) {
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

function ocultar_fecheros(){
    let os = parseInt(document.getElementById("Cant_fech_in").value);
    for(var i=1;i<10;i++){
        let nttex="COND";
        nttex=nttex+i.toString();
        document.getElementById(nttex).style.visibility='hidden';
    }

    for(var i=1;i<os;i++){
        console.log(i);
        let nttex="COND";
        nttex=nttex+i.toString();
        document.getElementById(nttex).style.visibility='visible';
    }
}

function Ocultar_car_sul(){
    let os = document.getElementById("opcion_selec").value;
    if (os == 0) {
        document.getElementById("Car_sul_tab").style.display='none';
    }
    else{
        document.getElementById("Car_sul_tab").style.display='block';
    }
}

function Ocultar_car_fech(){
    let os = document.getElementById("opcion_selec1").value;
    if (os == 0 || os == 1) {
        document.getElementById("Tabla_fech_sel").style.display='none';
    }
    else{
        document.getElementById("Tabla_fech_sel").style.display='block';
    }
}

function actualizar_dia(caja9){
    var Fecha_siem = document.getElementById("Fechao").value;
    const hoymismo = new Date(Fecha_siem);
    const tomorrow = new Date(Fecha_siem);
    let nttex="FSD";
    nttex=nttex+caja9.toString();
    tomorrow.setDate(hoymismo.getDate() + parseInt(document.getElementById(nttex).value));
    nttex="FSA";
    nttex=nttex+caja9.toString();
    document.getElementById(nttex).value=formato_fecha(tomorrow);
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

function actualizar_fecha_caja(caja9){
    let nttex="FSA";
    nttex=nttex+caja9.toString();
    const punto1a = 1+Dia_ano(document.getElementById(nttex).value);
    const punto1b = Dia_ano(document.getElementById("Fechao").value);
    nttex="FSD";
    nttex=nttex+caja9.toString();
    document.getElementById(nttex).value=punto1a-punto1b;
}

function Var_iniciales() {
    //Condiciones iniciales
    document.getElementById("textoalarmhh").innerHTML = "Configure los parámetros de la aplicación para continuar.";
    document.getElementById("textoalarmhh1").innerHTML = " ";
    document.getElementById("imagen00").src=document.getElementById("imagen11").src;
    document.getElementById("imagen11").style.display='none';
    document.getElementById("imagen22").style.display='none';
    document.getElementById("imagen33").style.display='none';
    document.getElementById("imagen44").style.display='none';

    document.getElementById("Car_sul_tab").style.display='none';
    document.getElementById("opcion_selec").value=0;
    document.getElementById("Tabla_fech_sel").style.display='none';
    document.getElementById("opcion_selec1").value=0;
    var today = formato_fecha(new Date());
    document.getElementById("Fechao").disabled = false;
    document.getElementById("Fechao").max = today;
    document.getElementById("Fechao").min = "2020-01-01";
    document.getElementById("Fechao").value = today;//"2022-06-06";
    var Tot_dia = Total_dias();
    /*if (Tot_dia < 152) {
        document.getElementById("dias").value = Tot_dia;
        document.getElementById("dias").max = Tot_dia;
    } else {
        document.getElementById("dias").value = 152;
        document.getElementById("dias").max = 152;
    }*/

    //OPCIÓN
    opc1 = document.getElementById("opcion_dat").value;

    if (opc1 == 1) {
        document.getElementById("Fechao").disabled = true;
        document.getElementById("dias").value = 138;
        document.getElementById("CC").value = 77.7;
        document.getElementById("PMP").value = 54.95;
        document.getElementById("DA").value = 0.646;
        document.getElementById("Kco").value = 0.73;
        document.getElementById("Kcm").value = 0.87;
        document.getElementById("Kcf").value = 0.80;
        document.getElementById("Fa1").value = 0.35;
        //document.getElementById("dias").max = 138;
        document.getElementById("Fechao").value = "2021-02-03";

    } else if (opc1 == 2) {
        document.getElementById("CC").value = 77.7;
        document.getElementById("PMP").value = 54.95;
        document.getElementById("DA").value = 0.646;
        document.getElementById("Kco").value = 0.73;
        document.getElementById("Kcm").value = 0.87;
        document.getElementById("Kcf").value = 0.80;
        document.getElementById("Fa1").value = 0.35;
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP01 - CASATEJA";

    } else if (opc1 == 3) {
        document.getElementById("CC").value = 77.7;
        document.getElementById("PMP").value = 54.95;
        document.getElementById("DA").value = 0.646;
        document.getElementById("Kco").value = 0.73;
        document.getElementById("Kcm").value = 0.87;
        document.getElementById("Kcf").value = 0.80;
        document.getElementById("Fa1").value = 0.35;
        document.getElementById("Fechao").value = "2021-01-01";
        document.getElementById("Fechao").max = "2021-09-09";
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP02 - CI TIBAITATA";

    } else if (opc1 == 4) {
        document.getElementById("CC").value = 77.7;
        document.getElementById("PMP").value = 54.95;
        document.getElementById("DA").value = 0.646;
        document.getElementById("Kco").value = 0.73;
        document.getElementById("Kcm").value = 0.87;
        document.getElementById("Kcf").value = 0.80;
        document.getElementById("Fa1").value = 0.35;
        document.getElementById('Esta_sel').innerText = "Estación seleccionada = SIAP03 - LA FORTUNA";
    }

    fijar_fechas();
    ocultar_fecheros();
}

function fijar_fechas(){
    let longitud = parseInt(document.getElementById("dias").value);
    var Fecha_siem = document.getElementById("Fechao").value;
    const hoymismo = new Date(Fecha_siem);
    const tomorrow = new Date(Fecha_siem);
    for(var i=1;i<11;i++){
        
        let nttex="FSD";
        nttex=nttex+i.toString();
        document.getElementById(nttex).value=i.toString();

        nttex="FSA";
        nttex=nttex+i.toString();

        tomorrow.setDate(hoymismo.getDate() + (i));
        document.getElementById(nttex).value=formato_fecha(tomorrow);
        document.getElementById(nttex).min=formato_fecha(hoymismo);
        tomorrow.setDate(hoymismo.getDate() + longitud);
        document.getElementById(nttex).max=formato_fecha(tomorrow);
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
    fijar_fechas();
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
        Fechas = []
        Eto_Calc_mm_d_1 = []
        Etc_mm_d_1 = []
        Precipitacion_mm = [];
        //Atributos de la matriz
        Fecha = []; //R[1]
        P_mm = []; //R[2]    P(mm)          
        Eto_mm = []; //R[3]    Eto(mm)      
        J = []; //R[4]    dia               
        Longitud_raiz_m = []; //R[5]
        Kc = []; //R[6]
        ADT_mm = []; //R[7]
        p_aj_mm = []; //R[8]
        AFA_mm = []; //R[9]
        Lamina_bruta_mm = []; //R[10]
        P_efec_mm = []; //R[11]
        Ks = []; //R[13] 
        ETcaj_mm = []; //R[14]  
        Perc_Prof_mm = []; //R[15]
        Dr_Final_mm = []; //R[16]
        //Leer csv
        /*if (opc1 <= 1) {
            var array = archivojson();
            //Leer fechas
            for (var i = 0; i < longitud; i++) {
                Fechas.push(array[i]["Fecha"].toString());
                Eto_Calc_mm_d_1.push(+array[i]["Eto_Calc_mm_d-1"]);
                Etc_mm_d_1.push(+array[i]["Etc_mm_d-1"]);
                Precipitacion_mm.push(+array[i]["Precipitacion (mm)"]);
            }
            Vector de fechas
            const inicio = new Date(Fecha_siem);
            for (var i = 0; i < longitud; i++) {
                inicio.setDate(inicio.getDate() + 1);
                let feaux = " " + inicio
                Fechas.push(feaux);
            }
        } else {*/
        var Est = 0;
        var Fech = "Est1_Fecha";
        if (opc1 == 2) {
            Est = JSON.parse(Estacion1);
            Fech = "Est1_Fecha";
        } else if (opc1 == 3) {
            Est = JSON.parse(Estacion2);
            Fech = "Est2_Fecha";
        } else {
            Est = JSON.parse(Estacion3);
            Fech = "Est3_Fecha";
        }
        //Datos de la estacion
        var Fecha_siem_1 = document.getElementById("Fechao").value;

        var Fecha_siem_2 = new Date(Fecha_siem_1);
        Fecha_siem_2.setDate(Fecha_siem_2.getDate());
        Fecha_siem_2.setDate(Fecha_siem_2.getDate() + longitud);
        Fecha_siem_2 = formato_fecha(Fecha_siem_2);
        let L_json = Object.keys(Est[0][Fech]).length;
        //Extraer del json
        for (var i = 1; i < longitud+1; i++) {
            var memoria_ETO = 0;
            var memoria_Prec = 0;
            var Fecha_siem_3 = new Date(Fecha_siem_1);
            Fecha_siem_3.setDate(Fecha_siem_3.getDate() + i);
            Fecha_siem_3 = formato_fecha(Fecha_siem_3).toString();
            for (var j = 0; j < L_json; j++) {
                var Fecha_temp = formato_fecha(new Date(Est[0][Fech][j].toString()));
                if (Fecha_temp == Fecha_siem_3) {
                    memoria_ETO = parseFloat(Est[0]["E3_Evapotrans"][j]) + memoria_ETO;
                    memoria_ETO = Math.round(memoria_ETO * 100) / 100;
                    memoria_Prec = parseFloat(Est[0]["A2_Precipitation_sum"][j]) + memoria_Prec;
                    memoria_Prec = Math.round(memoria_Prec * 100) / 100;
                }
            }
            Fechas.push(Fecha_siem_3);
            Eto_Calc_mm_d_1.push(memoria_ETO);
            Precipitacion_mm.push(memoria_Prec);
        }
        //}
        //Promedio
        let sum = Eto_Calc_mm_d_1.reduce((previous, current) => current += previous);
        let mean = sum / Eto_Calc_mm_d_1.length;
        //DATOS DE ENTRADA
        let delta = 1; //delta de dias para simular
        //Suelo
        let CC = parseFloat(document.getElementById("CC").value); //77.7; //Capacidad de campo a 0.1 cbar(%g) (52 % vol_3, 49.2%_2, 53.53%_1)
        let pmp = parseFloat(document.getElementById("PMP").value); //54.95; //Punto de marchitez permanente (%g)(35.5% vol_3, 29.5%_2,35.1%_1)
        let da = parseFloat(document.getElementById("DA").value); //0.646; //Densidad aparente (-)(0.646_3, 0.65_2,0.646_1) 
        //Planta
        let Rmin = 0.05; //Longitud de raíz máxima(m) 
        let Rmax = 0.30; //Longitud de raá½z máxima (m)
        let Jini = 1; //Tiempo de crecimiento de la raíz (dia)
        let Jmax = 66;
        let Kyini = 0.45; //Factor del cultivo 
        let Kydes = 0.8; //Factor del cultivo 
        let Kymed = 0.7; //Factor del cultivo 
        let Kyfin = 0.2; //Factor del cultivo 
        let Kcini = parseFloat(document.getElementById("Kco").value); // 0.86; //Coeficientes del cultivo por etapas
        let Kcmed = parseFloat(document.getElementById("Kcm").value); // 1.07;
        let Kcfin = parseFloat(document.getElementById("Kcf").value); // 0.67;
        let Lini = 27; // Duración etapa (dias) Para ciclo 2:35
        let Ldes = 39; // Para ciclo 2:30
        let Lmed = 47; // Para ciclo 2:53
        let Lfin = 42; // Para ciclo 2:20
        let pini = parseFloat(document.getElementById("Fa1").value); //0.35; //Factor de agotamiento (-)
        let pdes = parseFloat(document.getElementById("Fa1").value); //
        //////Calculo de agua disponible total//
        let ADT = 1000 * ((CC - pmp) / 100) * da; //ADT (mm/m)
        let a = 0.9; //Porcentaje para Precipitacion efectiva
        //Agotamiento inicial de agua en el suelo
        let Dr0 = 10; // Cero para iniciar a capacidad de campo
        let k = Lini + Ldes + Lmed + Lfin;
        let ciclo = Lini + Ldes + Lmed + Lfin;
        let nr = longitud;
        let dia = 1; //dia que inicia el balance. Se asume que inicia en capacidad de campo
        let con = 1;
        //Crear variables de dataframe en JS
        //let x = matrix(data = NA, nrow = nr, ncol = 19, byrow = FALSE, dimnames = NULL)
        //let R = data.frame(x)
        //Llenar matriz
        var condicion_selector=parseInt(document.getElementById("opcion_selec1").value);
        for (var j = 0; j < nr; j++) {
            con = dia + j;
            J.push(con);
            //Calculo de la longitud de raíz
            if (J[j] <= Jini) {
                Longitud_raiz_m.push(Rmin);
            } else
            if (J[j] <= Jmax) {
                let num_aux = Rmin + ((Rmax - Rmin) * ((J[j] - Jini) / (Jmax - Jini)));
                num_aux = Math.round(num_aux * 100) / 100;
                Longitud_raiz_m.push(num_aux);
            } else {
                Longitud_raiz_m.push(Rmax);
            }
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

            //Cálculo de agua disponible total ADT
            num_aux_2 = ADT * Longitud_raiz_m[j];
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            ADT_mm.push(num_aux_2);

            //Cálculo de factor de agotamiento  (cuadro 22 FAO 56)
            let num_aux_3 = 0;
            if (J[j] <= Lini + Ldes) {
                if (Longitud_raiz_m[j] == 5) {
                    num_aux_3 = pini;
                } else {
                    //num_aux_3 = Math.max(pini + (0.04 * (5 - Etc_mm_d_1[j])), 0.1);
                    num_aux_3 = Math.max(pini + (0.04 * (5 - ETcaj_mm[j])), 0.1);
                }
            } else {
                if (Longitud_raiz_m[j] == 5) {
                    num_aux_3 = pdes;
                } else {
                    //num_aux_3 = Math.max(pdes + (0.04 * (5 - Etc_mm_d_1[j])), 0.1);
                    num_aux_3 = Math.max(pdes + (0.04 * (5 - ETcaj_mm[j])), 0.1);
                }
            }
            //num_aux_3 = Math.round(num_aux_3 * 100) / 100;

            p_aj_mm.push(num_aux_3);

            //Cálculo de agua fácilmente aprovechable AFA
            num_aux_2 = ADT_mm[j] * p_aj_mm[j];
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            AFA_mm.push(num_aux_2);

            //Cálculo de lámina neta
            if(condicion_selector==0){
                if (j == 0) {
                    let Flag = 0;
                    if (AFA_mm[j] <= Dr0) {
                        Flag = 1;
                    }
                    if (Flag == 0) {
                        Lamina_bruta_mm.push(Dr0);
                    } else {
                        Lamina_bruta_mm.push(0);
                    }
                } else {
                    if (AFA_mm[j] <= Dr_Final_mm[j - 1]) {
                        Lamina_bruta_mm.push(Dr_Final_mm[j - 1]);
                    } else {
                        Lamina_bruta_mm.push(0);
                    }
                }
            }
            else if(condicion_selector==1){
                Lamina_bruta_mm.push(0);
            }
            else{
                let Fechas_activas=parseInt(document.getElementById("Cant_fech_in").value);
                let lamina_registrada=0;
                let dia_registrado=1;
                for(var uu=1;uu<=Fechas_activas;uu++){
                    let nttex="FSD";
                    nttex=nttex+uu.toString();
                    dia_registrado=parseInt(document.getElementById(nttex).value);
                    if(dia_registrado==con){
                        nttex="CL";
                        nttex=nttex+uu.toString();
                        lamina_registrada=parseFloat(document.getElementById(nttex).value);
                        break;
                    }
                    else{
                        if (j == 0) {
                            let Flag = 0;
                            if (AFA_mm[j] <= Dr0) {
                                Flag = 1;
                            }
                            if (Flag == 0) {
                                lamina_registrada=Dr0;                                
                            } else {
                                lamina_registrada=0;                                
                            }
                        } else {
                            if (AFA_mm[j] <= Dr_Final_mm[j - 1]) {
                                lamina_registrada=Dr_Final_mm[j - 1];              
                            } else {
                                lamina_registrada=0;
                            }
                        }
                        
                    }
                }
                Lamina_bruta_mm.push(lamina_registrada);
            }
            //Cálculo de la precipitación efectiva
            num_aux_2 = Precipitacion_mm[j] * a;
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            P_efec_mm.push(num_aux_2);
            
            //Cálculo del coeficiente de estrÃ©s hidrico Ks
            Ks.push(1);

            //Cálculo de la evapotranspiración del cultivo ajustado ETcaj 2
            //num_aux_2 = Etc_mm_d_1[j];
            //num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            //ETcaj_mm.push(num_aux_2);

            //Cálculo de la percolación profunda

            if (j == 0) {
                if ((P_efec_mm[j] + Lamina_bruta_mm[j] - ETcaj_mm[j] - Dr0) < 0) {
                    Perc_Prof_mm.push(0);
                } else {
                    num_aux_2 = P_efec_mm[j] + Lamina_bruta_mm[j] - ETcaj_mm[j] - Dr0;
                    num_aux_2 = Math.round(num_aux_2 * 100) / 100;
                    Perc_Prof_mm.push(num_aux_2);
                }
            } else {
                if ((P_efec_mm[j] + Lamina_bruta_mm[j] - ETcaj_mm[j] - Dr_Final_mm[j - 1]) < 0) {
                    Perc_Prof_mm.push(0);
                } else {
                    num_aux_2 = P_efec_mm[j] + Lamina_bruta_mm[j] - ETcaj_mm[j] - Dr_Final_mm[j - 1];
                    num_aux_2 = Math.round(num_aux_2 * 100) / 100;
                    Perc_Prof_mm.push(num_aux_2);
                }
            }

            //Cálculo del agotamiento de agua final en el suelo Dr final
            if (j == 0) {
                num_aux_2 = Dr0 - P_efec_mm[j] + ETcaj_mm[j] - Perc_Prof_mm[j];
                num_aux_2 = Math.round(num_aux_2 * 100) / 100;
                Dr_Final_mm.push(num_aux_2); //Ya tiene el riego en Dr ini        
            } else {
                num_aux_2 = Dr_Final_mm[j - 1] - P_efec_mm[j] + ETcaj_mm[j] + Perc_Prof_mm[j] - Lamina_bruta_mm[j];
                num_aux_2 = Math.round(num_aux_2 * 100) / 100;
                Dr_Final_mm.push(num_aux_2);
            }
            P_mm.push(Precipitacion_mm[j]);
            Eto_mm.push(Eto_Calc_mm_d_1[j]);
        }
        //Aqui termina el codigo del balance
    } catch (err) {
        console.log(err);
    }
}

function graficar() {
    $('#load').show();

    setTimeout(function(){
        //Mostrar coeficientes 
        //Tabla 1   
        funtabla1("tab_reporte1", Coef_1q, 0);
        //Tabla 2
        funtabla1("tab_reporte2", Coef_2q, 1);
        //Tabla 3
        funtabla1("tab_reporte3", Coef_3q, 2);
        mostrarDiv("1");
        $('#load').hide();

    }, 500);
}

function mostrarDiv(divNum) {
    // Ocultar todos los divs antes de mostrar el deseado
    var divs = document.getElementsByClassName('div-contenidohh');
    for (var i = 0; i < divs.length; i++) {
        divs[i].style.display = 'none';
    }

    // Mostrar el div seleccionado
    var divToShow = document.getElementById('Tablamodel' + divNum);
    if (divToShow) {
        divToShow.style.display = 'block';
    }
}

function funtabla1(Rep, Datas, nnf){
    //Crear tabla
    let tab1 = document.getElementById(Rep);
    tab1.innerHTML = "";

    var tcab = document.createElement("thead");
    var tfot = document.createElement("tfoot");
    var tbod = document.createElement("tbody");
    //Rotulos cabeza
    var titulos = document.createElement("tr");

    var lista_titulos = ["Etapa", "Condicion", "Eps_Tipo", "Eps_Lambda", "Eps_B0", "Eps_B1", "Eps_B2", "Eps_B3", "R2"];
    if(nnf==1){lista_titulos = ["Etapa", "Condicion", "FCsat_Tipo", "FCsat_Lambda", "FCsat_B0", "FCsat_B1", "FCsat_B2", "FCsat_B3", "R2"];}
    if(nnf==2){lista_titulos = ["Etapa", "Condicion", "RD_Tipo", "RD_Lambda", "RD_B0", "RD_B1", "RD_B2", "RD_B3", "R2"];}
    
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

    //Contenido de las tablas
    for (let j = 0; j < Datas.length; j++) {
        var fila = document.createElement("tr");
        for (let i = 0; i < lista_titulos.length; i++) {
            var celda = document.createElement("td");
            var textoCelda;
            textoCelda = document.createTextNode(Datas[j][lista_titulos[i]].toString());
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
}

function Exportarcsv(filename, rephh) {
    var csv = [" "];
    var rows = document.querySelectorAll("#tab_reporte"+rephh+" tr");
    for (var i = 0; i < rows.length; i++) {
        var row = [],
            cols = rows[i].querySelectorAll("#tab_reporte"+rephh+" th, #tab_reporte"+rephh+" td");
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

function actualizar_pag(){
    leerarchxls();
    graficar();
}