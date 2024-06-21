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
let numberOfDays = 0;
const calendar = document.getElementById("calendar");
let flag_calendario=0;
//var Est =0;
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
    var mm = fech_mem.getMonth() + 1; 
    var yyyy = fech_mem.getFullYear();
    if (dd < 10) { dd = '0' + dd; }
    if (mm < 10) { mm = '0' + mm; }
    fech_mem = yyyy + '-' + mm + '-' + dd;
    return fech_mem;
}

function saturador(eti) {
    if (parseInt(document.getElementById(eti).max) < parseInt(document.getElementById(eti).value)) {
        document.getElementById(eti).value = 90;
    }
    if (parseInt(document.getElementById(eti).value) < parseInt(document.getElementById(eti).min)) {
        document.getElementById(eti).value = 1;
    }
    graficar(0);
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

function Var_iniciales(flaghh) {
    //Condiciones iniciales
    document.getElementById("textoalarmhh").innerHTML = "Configure los parámetros de la aplicación para continuar.";
    document.getElementById("textoalarmhh1").innerHTML = " ";
    document.getElementById("imagen00").src=document.getElementById("imagen11").src;
    document.getElementById("imagen11").style.display='none';
    document.getElementById("imagen22").style.display='none';
    document.getElementById("imagen33").style.display='none';
    document.getElementById("imagen44").style.display='none';
    if(flaghh==0){
        document.getElementById("containercalendar").style.visibility ='hidden';
        document.getElementById("Estado_car_sul_tab2").style.visibility ='hidden';
    }

    var today = new Date();
    var yesterday = new Date(today);
    yesterday.setDate(today.getDate() - 2);

    var todayFormatted = today.toISOString().split('T')[0];
    var yesterdayFormatted = yesterday.toISOString().split('T')[0];

    today = formato_fecha(new Date());
    document.getElementById("Fechao").disabled = false;
    document.getElementById("Fechao").max = yesterdayFormatted;
    document.getElementById("Fechao").min = "2020-01-01";
    document.getElementById("Fechao").value = yesterdayFormatted;

    
    //OPCIÓN
    //opc1 = document.getElementById("opcion_dat").value;
    document.getElementById("dias").value=1;

    act_fecha_dia();
}

function act_fecha_dia() {
    var Total_d = Total_dias();

    if (Total_d < 90) {
        document.getElementById("dias").value = Total_d;
        document.getElementById("dias").max = Total_d;
    } else {
        document.getElementById("dias").value = 90;
        document.getElementById("dias").max = 90;
    }
    document.getElementById("dias").disabled = false;
    graficar(0);
}

function esDiaDeHoyDespuesSumarDias(diasASumar, fecha) {
    const fechaActual = new Date();
    const nuevaFecha = new Date(fecha);
    nuevaFecha.setDate(nuevaFecha.getDate() + diasASumar);

    return (
      nuevaFecha.getDate() === fechaActual.getDate() &&
      nuevaFecha.getMonth() === fechaActual.getMonth() &&
      nuevaFecha.getFullYear() === fechaActual.getFullYear()
    );
}

function Leer_csv(Estado_Cal) {

   
    var Fecha_siem_1 = document.getElementById("Fechao").value;
    let longitud = parseInt(document.getElementById("dias").value);
    const l1a = convertContentToIntegers(".selected1");
    const l1b = convertContentToIntegers(".selected2");
    const l1c = l1a.concat(l1b);

    try {
        longitud = parseInt(document.getElementById("dias").value);
        var Fecha_siem = document.getElementById("Fechao").value;
        //opc1 = document.getElementById("opcion_dat").value;
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
        let L_json = 0;
        var FechasRep=[];
        var EvapotransRep=[];
        var PrecipitaRep=[];
        for (var i = 0; i < Estjson.length; i++) {
            FechasRep.push(Estjson[i].Fecha);
            EvapotransRep.push((Estjson[i].ET0));
            PrecipitaRep.push(Estjson[i].PromedioPre);
        }
        L_json = Estjson.length;
        //Datos de la estacion
        Fecha_siem_1 = document.getElementById("Fechao").value;
        var Fecha_siem_2 = new Date(Fecha_siem_1);
        Fecha_siem_2.setDate(Fecha_siem_2.getDate());
        Fecha_siem_2.setDate(Fecha_siem_2.getDate() + longitud);
        Fecha_siem_2 = formato_fecha(Fecha_siem_2);

        //Extraer del json
        for (var i = 1; i < longitud+1; i++) {
            var memoria_ETO = 0;
            var memoria_Prec = 0;
            var Fecha_siem_3 = new Date(Fecha_siem_1);
            Fecha_siem_3.setDate(Fecha_siem_3.getDate() + i);
            Fecha_siem_3 = formato_fecha(Fecha_siem_3).toString();

            for (var j = 0; j < FechasRep.length; j++) {
                var Fecha_temp = formato_fecha(new Date(FechasRep[j].toString()));
                if (Fecha_temp == Fecha_siem_3) {
                    memoria_ETO = parseFloat(EvapotransRep[j]) + memoria_ETO;
                    memoria_ETO = Math.round(memoria_ETO * 100) / 100;
                    memoria_Prec = parseFloat(PrecipitaRep[j]) + memoria_Prec;
                    memoria_Prec = Math.round(memoria_Prec * 100) / 100;
                    console.log(memoria_ETO);
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
        let CC = 77.7;//parseFloat(document.getElementById("CC").value); //77.7; //Capacidad de campo a 0.1 cbar(%g) (52 % vol_3, 49.2%_2, 53.53%_1)
        let pmp = 54.95;//parseFloat(document.getElementById("PMP").value); //54.95; //Punto de marchitez permanente (%g)(35.5% vol_3, 29.5%_2,35.1%_1)
        let da = 0.646;//parseFloat(document.getElementById("DA").value); //0.646; //Densidad aparente (-)(0.646_3, 0.65_2,0.646_1) 
        //Planta
        let Rmin = 0.1; //Longitud de raíz máxima(m) 
        let Rmax = 0.30; //Longitud de raá½z máxima (m)
        let Jini = 1; //Tiempo de crecimiento de la raíz (dia)
        let Jmax = 60;
        let Kyini = 0.45; //Factor del cultivo 
        let Kydes = 0.8; //Factor del cultivo 
        let Kymed = 0.7; //Factor del cultivo 
        let Kyfin = 0.2; //Factor del cultivo 
        let Kcini = 0.7;//parseFloat(document.getElementById("Kco").value); // 0.86; //Coeficientes del cultivo por etapas
        let Kcmed = 1.1;//parseFloat(document.getElementById("Kcm").value); // 1.07;
        let Kcfin = 0.9;//parseFloat(document.getElementById("Kcf").value); // 0.67;
        let Lini = 20; // Duración etapa (dias) Para ciclo 2:35
        let Ldes = 40; // Para ciclo 2:30
        let Lmed = 20; // Para ciclo 2:53
        let Lfin = 10; // Para ciclo 2:20
        let pini = 0.3;//parseFloat(document.getElementById("Fa1").value); //0.35; //Factor de agotamiento (-)
        let pdes = 0.3;//parseFloat(document.getElementById("Fa1").value); //
        //////Calculo de agua disponible total//
        let ADT = 1000 * ((CC - pmp) / 100) * da; //ADT (mm/m)
        let a = 0.9; //Porcentaje para Precipitacion efectiva
        //Agotamiento inicial de agua en el suelo
        let Dr0 = 0; // Cero para iniciar a capacidad de campo
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
            } else{
                if (J[j] <= Jmax) {
                    let num_aux = Rmin + ((Rmax - Rmin) * ((J[j] - Jini) / (Jmax - Jini)));
                    num_aux = Math.round(num_aux * 100) / 100;
                    Longitud_raiz_m.push(num_aux);
                } else {
                    Longitud_raiz_m.push(Rmax);
                }
            }
            let num_aux_2 = 0;
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

            //Cálculo de agua disponible total ADT
            num_aux_2 = ADT * Longitud_raiz_m[j];
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            ADT_mm.push(num_aux_2);

            //Cálculo de factor de agotamiento  (cuadro 22 FAO 56)
            let num_aux_3 = 0;
            if (J[j] <= Lini + Ldes) {
                if (Eto_Calc_mm_d_1[j] == 5) {
                    num_aux_3 = pini;
                } else {
                    num_aux_3 = Math.max(pini + (0.04 * (5 - Eto_Calc_mm_d_1[j])), 0.1);
                }
            } else {
                if (Eto_Calc_mm_d_1[j] == 5) {
                    num_aux_3 = pdes;
                } else {
                    num_aux_3 = Math.max(pdes + (0.04 * (5 - Eto_Calc_mm_d_1[j])), 0.1);
                }
            }
            p_aj_mm.push(num_aux_3);
            //Cálculo de agua fácilmente aprovechable AFA
            num_aux_2 = ADT_mm[j] * p_aj_mm[j];
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            AFA_mm.push(num_aux_2);

            //Cálculo de lámina neta
            if(condicion_selector<=1){
                if(Estado_Cal==0){
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
                else{
                    if(estaEnArray(j+1, l1c)==false){
                        Lamina_bruta_mm.push(0);                  
                    }
                    else{

                        if (j == 0) {
                            let Flag = 0;
                            if (AFA_mm[j] <= Dr0) {
                                Flag = 1;
                            }
                            if (Flag == 0) {
                                Lamina_bruta_mm.push(Dr0);
                            } else {
                                Lamina_bruta_mm.push(Dr0);
                            }
                        } else {
                            if (AFA_mm[j] <= Dr_Final_mm[j - 1]) {
                                Lamina_bruta_mm.push(Dr_Final_mm[j - 1]);
                            } else {
                                Lamina_bruta_mm.push(Dr_Final_mm[j - 1]);
                            }
                        }                        
                    }

                }
            }
            else if(condicion_selector==2){
                Lamina_bruta_mm.push(0);
                flag_calendario = 1;
            }

            //Cálculo de la precipitación efectiva
            num_aux_2 = Precipitacion_mm[j] * a;
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            P_efec_mm.push(num_aux_2);
            
            //Cálculo del coeficiente de estrÃ©s hidrico Ks
            if(j==0){
                if(AFA_mm[j]<=Dr0){
                    let Ksa=(ADT_mm[j]-Dr0)/((1-p_aj_mm[j])*ADT_mm[j]);
                    if(Ksa>0){Ks.push(Ksa);}
                    else{Ks.push(0);}
                }
                else{
                    Ks.push(1);
                }
                
            }
            else{
                let auxDR=Dr_Final_mm[j-1];
                if(AFA_mm[j]<=auxDR){
                    let Ksa=(ADT_mm[j]-auxDR)/((1-p_aj_mm[j])*ADT_mm[j]);
                    if(Ksa>0){Ks.push(Ksa);}
                    else{Ks.push(0);}
                }
                else{
                    Ks.push(1);
                }            
            }

            //Cálculo de la evapotranspiración del cultivo ajustado ETcaj
            num_aux_2 = Eto_Calc_mm_d_1[j] * Kc[j] *Ks[j];
            num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            ETcaj_mm.push(num_aux_2);

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

            //num_aux_2 = Eto_Calc_mm_d_1[j]*Ks[j];
            //num_aux_2 = Math.round(num_aux_2 * 100) / 100;
            Eto_mm.push(Eto_Calc_mm_d_1[j]);
        }

         
        // Calcular fecha de hoy:
        const fechaver1 = esDiaDeHoyDespuesSumarDias(longitud+1, Fecha_siem_1);
        if(fechaver1){
            document.getElementById("imagen00").src=document.getElementById("imagen33").src;

            let DrF_sal = Dr_Final_mm[Dr_Final_mm.length - 1];
            let ADT_sal = ADT_mm[ADT_mm.length - 1];
            let AFA_sal = AFA_mm[AFA_mm.length - 1];
            let Lam_sal = Lamina_bruta_mm[Lamina_bruta_mm.length - 1];

            if(DrF_sal>=ADT_sal){
                document.getElementById("textoalarmhh").innerHTML = "El cultivo presenta estrés hídrico severo.\nDe mantenerse esta condición se pueden presentar disminuciones severas del rendimiento o pérdida total del cultivo.";
                document.getElementById("imagen00").src=document.getElementById("imagen33").src;
                if(Lam_sal>0){
                    document.getElementById("textoalarmhh1").innerHTML = "El día de hoy debe aplicar una lámina neta de " + Lam_sal + " mm.";
                }
                else{
                    document.getElementById("textoalarmhh1").innerHTML = "El día de hoy debe aplicar una lámina neta de " + DrF_sal + " mm.";
                }  
            }
            else if(DrF_sal<=AFA_sal){
                document.getElementById("textoalarmhh").innerHTML = "El cultivo no requiere riego.";
                document.getElementById("imagen00").src=document.getElementById("imagen44").src;
                if(Lam_sal>0){
                    document.getElementById("textoalarmhh1").innerHTML = "El día de hoy debe aplicar una lámina neta de " + Lam_sal + " mm.";
                }
                else{
                    document.getElementById("textoalarmhh1").innerHTML = " ";
                }
            }
            else if((DrF_sal>AFA_sal) && (DrF_sal<ADT_sal)){
                document.getElementById("textoalarmhh").innerHTML = "El cultivo presenta estrés hídrico moderado.\nDe mantenerse esta condición puede presentarse disminución del rendimiento potencial.";
                document.getElementById("imagen00").src=document.getElementById("imagen22").src;
                if(Lam_sal>0){
                    document.getElementById("textoalarmhh1").innerHTML = "El día de hoy debe aplicar una lámina neta de " + Lam_sal + " mm.";
                }
                else{
                    document.getElementById("textoalarmhh1").innerHTML = "El día de hoy debe aplicar una lámina neta de " + DrF_sal + " mm.";
                }  
            }
            else{
                document.getElementById("textoalarmhh").innerHTML = "Consultando la información histórica.";
                document.getElementById("imagen00").src=document.getElementById("imagen11").src;
                document.getElementById("textoalarmhh1").innerHTML = " ";
            }
        }
        else{
            document.getElementById("textoalarmhh").innerHTML = "Consultando la información histórica.";
            document.getElementById("imagen00").src=document.getElementById("imagen11").src;
            document.getElementById("textoalarmhh1").innerHTML = " ";
        }
        //Aqui termina el codigo del balance
    } catch (err) {
        console.log(err);
    }
    //Resumen

    document.getElementById('Laminacu').textContent = Math.round(sumatoria(Lamina_bruta_mm) * 100) / 100;
    document.getElementById('prepacu').textContent = Math.round(sumatoria(P_efec_mm) * 100) / 100;
    document.getElementById('cantve').textContent = contarMayoresQueCero(Lamina_bruta_mm);
    // Obtener el elemento del div con el ID "calendar"
    var calendarDiv = document.getElementById("calendar");
    // Reiniciar el contenido del calendario
    calendarDiv.innerHTML = "";
    //Crear calendario
    numberOfDays = longitud;
    // Generar el calendario al cargar la página
    generateCalendar();
}

function sumatoria(vector) {
    return vector.reduce((acumulador, elemento) => acumulador + elemento, 0);
}

function contarMayoresQueCero(lista) {
    return lista.reduce((contador, elemento) => contador + (elemento > 0 ? 1 : 0), 0);
}

function graficar(Estado_Cal) {
    $('#load').show();

    setTimeout(function(){
        //Bloquear interfaz
        
        Leer_csv(Estado_Cal);

        for (let i = 0; i < Perc_Prof_mm.length; i++) {
            Perc_Prof_mm[i] = -1 * Perc_Prof_mm[i];
            AFA_mm[i] = -1 * AFA_mm[i];
            ADT_mm[i] = -1 * ADT_mm[i];
            Dr_Final_mm[i] = -1 * Dr_Final_mm[i];
        }

        // Definir datos a graficar
        var G1 = {
            x: J,
            y: P_efec_mm,
            name: 'P (Precipitación efectiva)',
            type: 'bar',
            marker: {
                color: 'rgb(135,206,250)',
                size: 2,
                line: {
                    color: 'rgb(135,206,250)',
                    width: 2
                }
            },
            xaxis: 'x1',
            opacity: 0.5
        };

        var G2 = {
            x: J,
            y: Lamina_bruta_mm,
            name: 'Ln (Lámina neta)',
            type: 'bar',
            marker: {
                color: 'rgb(100,149,237)',
                size: 2,
                line: {
                    color: 'rgb(100,149,237)',
                    width: 2
                }
            },
            xaxis: 'x1',
            opacity: 1.0
        };

        var G3 = {
            x: J,
            y: Perc_Prof_mm,
            name: 'Perc',
            type: 'bar',
            marker: {
                color: 'rgb(205, 205, 205)',
                opacity: 0.8,
                size: 2,
                line: {
                    color: 'rgb(130, 130, 130)',
                    width: 1
                }
            },
            xaxis: 'x1' 
        };

        var G4 = {
            x: J,
            y: AFA_mm,
            name: 'AFA (Agua Fácilmente Aprovechable)',
            type: 'scatter',
            marker: {
                color: 'rgb(0, 0, 0)',
                opacity: 0.1,
                size: 2,
                line: {
                    color: 'rgb(0, 0, 0)',
                    width: 2
                }
            },
            xaxis: 'x1' 
        };

        var G5 = {
            x: J,
            y: ADT_mm,
            name: 'ADT (Capacidad de retención de humedad del suelo en zona de raíces)',
            type: 'scatter',
            marker: {
                color: 'rgb(220, 20, 60)',
                opacity: 0.1,
                size: 2,
                line: {
                    color: 'rgb(255, 0, 0)',
                    width: 2
                }
            },
            xaxis: 'x1' 
        };

        var G6 = {
            x: J,
            y: Dr_Final_mm,
            name: 'Dr (Agotamiento de agua en la zona de raíces)',
            fill: 'tozeroy',
            type: 'scatter',
            marker: {
                color: 'rgb(0, 0, 0)',
                opacity: 0.1,
                size: 2,
                line: {
                    opacity: 0.1,
                    color: 'rgb(0, 0, 0)',
                    width: 3
                }
            },
            xaxis: 'x1' 
        };

        var G7 = {
            x: J,
            y: ETcaj_mm,
            name: 'ETc',
            fill: 'tozeroy',
            type: 'scatter',
            marker: {
                color: 'rgb(255, 128, 0)',
                opacity: 0.5,
                size: 20,
                line: {
                    color: 'rgb(255, 165, 0)',
                    width: 2
                }
            },
            xaxis: 'x1' 
        };

        let resalto = [];
        let dia_res = [];
        let fec_res = [];
        for (let i = 0; i < Dr_Final_mm.length; i++) {
            if (Math.abs(AFA_mm[i]) < Math.abs(Dr_Final_mm[i])) {
                resalto.push(Dr_Final_mm[i]);
                dia_res.push(J[i]);
                fec_res.push(Fechas[i]);
            }
        }

        var G9 = {
            x: dia_res,
            y: resalto,
            name: 'Um',
            type: 'scatter',
            mode: 'markers',
            marker: {
                color: 'rgb(255, 0, 0)',
                opacity: 0.5,
                size: 10,
                line: {
                    color: 'rgb(255, 0, 0)',
                    width: 2
                }
            },
            showlegend: false,
            xaxis: 'x1' 
        };

        var G9a = {
            x: Fechas,
            y: ADT_mm,
            name: 'Um2',
            type: 'scatter',
            mode: 'markers',
            marker: {
                color: 'rgb(255, 0, 0)',
                opacity: 0,
                size: 10,
                line: {
                    color: 'rgb(255, 0, 0)',
                    width: 2
                }
            },
            showlegend: false,
            xaxis: 'x2' 
        };

        //var datos = [G6, G7, G3, G4, G5, G2, G1, G9];
        var datos = [G4, G5, G6, G1, G2, G9, G9a];

        var l2 = {
            xaxis: { title: 'Días despues de siembra' },
            xaxis2: {
                overlaying: 'x', 
                side: 'top' 
            },
            yaxis: { title: 'Agotamiento de la humedad en el suelo (mm)' },
            colorbar: true,
            legend: {
                x: 0,
                xanchor: 'left',
                y: -1,
                xanchor: 'top'
            },
            barmode: 'relative',
            title: 'Balance hídrico',
            width: 1100
        };

        var config = { responsive: true }
        // Mostrar
        //Plotly.newPlot("Suelo_canva", datos, l2, config);
        var visible1=1;
        var visible2=1;
        var visible3=1;
        var visible4=1;
        var visible5=1;

        Plotly.newPlot("Suelo_canva", datos, l2, config).then(grafico => {
            const botonGrafico1 = document.getElementById('botonGrafico1');
            const botonGrafico2 = document.getElementById('botonGrafico2');
            const botonGrafico3 = document.getElementById('botonGrafico3');
            const botonGrafico4 = document.getElementById('botonGrafico4');
            const botonGrafico5 = document.getElementById('botonGrafico5');


            botonGrafico1.addEventListener('click', () => {
                visible1 = !visible1;
                let visible;
                if (visible1) {
                    visible = true;
                } else {
                    visible = 'legendonly';
                }
                Plotly.restyle(grafico, { visible }, [0]);
                });

            botonGrafico2.addEventListener('click', () => {
                visible2 = !visible2;
                if (visible2) {
                    visible = true;
                } else {
                    visible = 'legendonly';
                }
                Plotly.restyle(grafico, { visible }, [1]);
                });

            botonGrafico3.addEventListener('click', () => {
                visible3 = !visible3;
                if (visible3) {
                    visible = true;
                } else {
                    visible = 'legendonly';
                }
                Plotly.restyle(grafico, { visible }, [2]);
                });

            botonGrafico4.addEventListener('click', () => {
                visible4 = !visible4;
                if (visible4) {
                    visible = true;
                } else {
                    visible = 'legendonly';
                }
                Plotly.restyle(grafico, { visible }, [3]);
                });

            botonGrafico5.addEventListener('click', () => {
                visible5 = !visible5;
                if (visible5) {
                    visible = true;
                } else {
                    visible = 'legendonly';
                }
                Plotly.restyle(grafico, { visible }, [4]);
                });

           });

        var tam_Lam = Lamina_bruta_mm.length;
        var Lam_sal = Lamina_bruta_mm[tam_Lam - 1];
        var AFA_sal = AFA_mm[tam_Lam - 1];
        var ADT_sal = ADT_mm[tam_Lam - 1];
        var DrF_sal = Dr_Final_mm[tam_Lam - 1];

        var Fecha_siem_5 = document.getElementById("Fechao").value;
        var num1ab = Dia_ano(Fecha_siem_5);
        var num2ab = Dia_ano(new Date())-1;

        if((num1ab-num2ab)==0){
            var Fecha_siem_6 = new Date(Fecha_siem_5);
            Fecha_siem_6.setDate(Fecha_siem_6.getDate() + tam_Lam);
            Fecha_siem_6 = formato_fecha(Fecha_siem_6).toString();
        }
        else{
            var Fecha_siem_6 = new Date(Fecha_siem_5);
            Fecha_siem_6.setDate(Fecha_siem_6.getDate() + tam_Lam + 1);
            Fecha_siem_6 = formato_fecha(Fecha_siem_6).toString();
        }

        //Crear tabla
        let tab1 = document.getElementById("tab_reporte");
        tab1.innerHTML = "";

        var tcab = document.createElement("thead");
        var tfot = document.createElement("tfoot");
        var tbod = document.createElement("tbody");
        //Rotulos cabeza
        var titulos = document.createElement("tr");
        var lista_titulos = ["Fecha", "Día", "Prec", "ET0", "Dr", "ETc", "Perc", "AFA", "ADT", "Ln", "P"];
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
            for (let j = 0; j < 11; j++) {
                var celda = document.createElement("td");
                var textoCelda;
                if (j == 0) { textoCelda = document.createTextNode(Fechas[i].toString()); } 
                else if (j == 1) { textoCelda = document.createTextNode(J[i].toString()); } 
                else if (j == 2) { textoCelda = document.createTextNode(Precipitacion_mm[i].toString()); } 
                else if (j == 3) { textoCelda = document.createTextNode(Eto_mm[i].toString()); } 
                else if (j == 4) { textoCelda = document.createTextNode(Dr_Final_mm[i].toString()); } 
                else if (j == 5) { textoCelda = document.createTextNode(ETcaj_mm[i].toString()); } 
                else if (j == 6) { textoCelda = document.createTextNode(Perc_Prof_mm[i].toString()); } 
                else if (j == 7) { textoCelda = document.createTextNode(AFA_mm[i].toString()); } 
                else if (j == 8) { textoCelda = document.createTextNode(ADT_mm[i].toString()); } 
                else if (j == 9) { textoCelda = document.createTextNode(Lamina_bruta_mm[i].toString()); } 
                else if (j == 10) { textoCelda = document.createTextNode(P_efec_mm[i].toString()); }
                else if (j == 11) { textoCelda = document.createTextNode(Kc[i].toString()); } 
                else if (j == 12) { let operaKs=Math.round(Ks[i]*100)/100;
                                        textoCelda = document.createTextNode(operaKs.toString()); }
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
        //Desbloquear interfaz
        if(flag_activa>=2){
            document.getElementById("Estado_car_sul_tab2").style.visibility ='visible';
            document.getElementById("containercalendar").style.visibility ='visible';
        }
        //window.alert("Un resultado estimado aparecera en las opciones Resultados y Tablas.");
        $('#load').hide();
        flag_activa=flag_activa+1;
    }, 10);
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

// Generar el calendario
function generateCalendar() {
    let dayCount = 1;
    var CScal=parseInt(document.getElementById("opcion_selec1").value);
    for (let i = 0; i < numberOfDays; i++) {
        const dayDiv = document.createElement("div");
        dayDiv.className = "day";
        dayDiv.innerText = dayCount;
        if(CScal!=0){
            dayDiv.addEventListener("click", toggleSelected);
        }
        
        dayDiv.addEventListener("mouseover", showDate);
        dayDiv.addEventListener("mouseout", hideDate);
        if(Lamina_bruta_mm[i]>0){
            //dayDiv.style.backgroundColor = "pink";
            dayDiv.classList.toggle("selected1");
        }

        calendar.appendChild(dayDiv);
        dayCount++;
    }
}

// Marcar/Desmarcar una fecha seleccionada
function toggleSelected(event) {
    const claseDespues = event.target.classList.contains("selected1");
    if(claseDespues){event.target.classList.toggle("selected1");}
    else{event.target.classList.toggle("selected2");}
    graficar(1);
}

// Mostrar la fecha en tiempo real al pasar el mouse sobre un día
function showDate(event) {
    const day = parseInt(event.target.innerText);
    const currentDate = new Date(document.getElementById("Fechao").value);
    currentDate.setDate(currentDate.getDate() + day);
    const year = currentDate.getFullYear();
    const month = String(currentDate.getMonth() + 1).padStart(2, '0');
    var diachh = String(currentDate.getDate()).padStart(2, '0');
    const formattedDate = `${year}-${month}-${diachh}`;
    event.target.setAttribute("title", formattedDate + ', R = '+Lamina_bruta_mm[day-1]+' mm');
}

// Ocultar la fecha al quitar el mouse de un día
function hideDate(event) {
    event.target.removeAttribute("title");
}

function convertContentToIntegers(selector) {
    const elements = document.querySelectorAll(selector);
    const integers = [];

    elements.forEach(element => {
        const content = element.textContent.trim();
        const parsedInt = parseInt(content);
        if (!isNaN(parsedInt)) {
            integers.push(parsedInt);
        }
    });

    return integers;
}

function estaEnArray(valor, array) {
    return array.includes(valor);
}