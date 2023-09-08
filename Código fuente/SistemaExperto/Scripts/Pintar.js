let conta_ima = 0;
var intervalo = 0;
var intervalo2 = 0;
let puntero_ima = 0;
let puntero_ima_trim = 0;
var zoom = 0.2518041049471737;
let Top_x = 30;
let Top_y = 30;
let bandera_ani = 0;
let mem_cuenta = 0;
var imgInstance = 0;
var imgInstance_1 = 0;
var imgInstance_2 = 0;
var imgInstance_3 = 0;
var canvas = 0;
var canvas2 = 0;
var zoom_2 = 0.15;
var base = "/Content/imagenes/";
var imagen_1 = new Image();
var imagen_2 = new Image();
var imagen_3 = new Image();
imagen_1.src = base+'Neutro/' + 'DEF_' + 'Neutro.jpg';
imagen_2.src = base+'Nino/' + 'DEF_' + 'Nino.jpg';
imagen_3.src = base+'Nina/' + 'DEF_' + 'Nina.jpg';

var refresco = false;
var neu_sele = false;
var nio_sele = false;
var nia_sele = false;
var Etique = ['DEF_', 'MAM_', 'JJA_', 'SON_'];

var op1 = 0;
var op2 = 0;
var op3 = 0;

var carpeta = [
    "Brillo_solar/", "Evapotranspiracion/", "Humedad_relativa/", "Precipitacion/",
    "Temperatura_maxima/", "Temperatura_media/", "Temperatura_minima/"
];

var Meses_ano = [
    "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
    "Junio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
];

var trim_ano = ["Promedio anual", "Trimestre: diciembre a febrero", "Trimestre: marzo a mayo",
    "Trimestre: junio a agosto", "Trimestre: septiembre a noviembre"
];

var unidad = ["BS_", "Eto_", "HR_", "PPT_", "TMAX_", "TMED_", "TMIN_"]

var Arr_Compl_Mes = ["01_ENE.jpg", "02_FEB.jpg", "03_MAR.jpg", "04_ABR.jpg", "05_MAY.jpg",
    "06_JUN.jpg", "07_JUL.jpg", "08_AGO.jpg", "09_SEP.jpg", "10_OCT.jpg", "11_NOV.jpg", "12_DIC.jpg"
];

var Arr_Compl_trim = ["promedio_anual.jpg", "trimestre_diciembre_enero_febrero.jpg",
    "trimestre_marzo_abril_mayo.jpg", "trimestre_junio_julio_agosto.jpg",
    "trimestre_septiembre_octubre_noviembre.jpg"
];



function Crear_mapa_leaf(){
    var map = L.map('map').setView([2, -72], 8);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);

    var layer = L.leafletGeotiff('../Content/imagenes/Brillo_solar/BS_01_ENE_geo.tif',{
                                        band: 0,
                                        name: 'Wind direction',
                                        opacity: 0.5,
                                    }).addTo(map);

    setInterval(function () {
        map.invalidateSize();
    }, 100);
}

function Rotarimagen(num_uni) {
    if (bandera_ani == 0) {
        intervalo = setInterval(graficar, 500, num_uni);
        bandera_ani = 1;
    }
}

function Cerrar_anima() {
    clearInterval(intervalo);
    bandera_ani = 0;
}

function graficar(num_uni) {
    document.getElementById("Mes_Anima").textContent = "Mes del año: " + Meses_ano[conta_ima];
    document.getElementById("Ima_estatica_2").src = base + carpeta[num_uni] + unidad[num_uni] + Arr_Compl_Mes[conta_ima];
    if (conta_ima < 11) { conta_ima += 1; } else { conta_ima = 0; }
}

function graficar_2(elementoImg, nume) {
    canvas = new fabric.Canvas(mapa_ani);
    var imagen = new Image();
    zoom = 0.20;
    imagen.src = elementoImg.src;
    imgInstance = new fabric.Image(imagen, {
        left: Top_y,
        top: Top_x,
        angle: 0,
        opacity: 1,
        width: 4135,
        height: 5849,
    });
    if (nume == 0) { canvas.setZoom(zoom); } else { canvas.setZoom(0.4); }
    canvas.add(imgInstance);
    canvas.on('mouse:wheel', function(opt) {
        var delta = opt.e.deltaY;
        var zoom = canvas.getZoom();
        zoom *= 0.999 ** delta;
        if (zoom > 20) zoom = 20;
        if (zoom < 0.01) zoom = 0.01;
        canvas.setZoom(zoom);
        opt.e.preventDefault();
        opt.e.stopPropagation();
    });
    console.log(imgInstance)
}

function cerran_canva() {
    canvas.remove(imgInstance);
}

function Rotarimagen_derecha(num_uni) {
    if (puntero_ima < 11) { puntero_ima += 1; } else { puntero_ima = 0; }
    document.getElementById("Ima_estatica").src = base + carpeta[num_uni] + unidad[num_uni] + Arr_Compl_Mes[puntero_ima];
    document.getElementById("Opc_mes_ano").value = puntero_ima;
}

function Rotarimagen_izquierda(num_uni) {
    if (puntero_ima > 0) { puntero_ima -= 1; } else { puntero_ima = 11; }
    document.getElementById("Ima_estatica").src = base + carpeta[num_uni] + unidad[num_uni] + Arr_Compl_Mes[puntero_ima];
    document.getElementById("Opc_mes_ano").value = puntero_ima;
}

function Rotarimagen_select(num_uni) {
    puntero_ima = parseInt(document.getElementById("Opc_mes_ano").value);
    document.getElementById("Ima_estatica").src = base + carpeta[num_uni] + unidad[num_uni] + Arr_Compl_Mes[puntero_ima];
}

function Rotarimagen_derecha_trim(num_uni) {
    if (puntero_ima_trim < 4) { puntero_ima_trim += 1; } else { puntero_ima_trim = 0; }
    document.getElementById("Ima_estatica_trim").src = base + carpeta[num_uni] + unidad[num_uni] + Arr_Compl_trim[puntero_ima_trim];
    document.getElementById("Opc_mes_trim").value = puntero_ima_trim;
}

function Rotarimagen_izquierda_trim(num_uni) {
    if (puntero_ima_trim > 0) { puntero_ima_trim -= 1; } else { puntero_ima_trim = 4; }
    document.getElementById("Ima_estatica_trim").src = base + carpeta[num_uni] + unidad[num_uni] + Arr_Compl_trim[puntero_ima_trim];
    document.getElementById("Opc_mes_trim").value = puntero_ima_trim;
}

function Rotarimagen_select_trim(num_uni) {
    if (puntero_ima_trim > 0) { puntero_ima_trim -= 1; } else { puntero_ima_trim = 4; }
    puntero_ima_trim = parseInt(document.getElementById("Opc_mes_trim").value);
    document.getElementById("Ima_estatica_trim").src = base + carpeta[num_uni] + unidad[num_uni] + Arr_Compl_trim[puntero_ima_trim];
}

function abreModalImagen(elementoImg) {
    let imagenModal = document.getElementById("miImagenModal");
    imagenModal.src = elementoImg.src;
}

function comprobar_mapas() {
    refresco = document.getElementById("Actchx").checked
}


function Rotarimagen_nino() {
    intervalo2 = setTimeout(graficar_3, 1000);
}

function seleccion_nio() {
    if (mem_cuenta == 1) {
        zoom_2 = 0.12;
    }
    if (mem_cuenta == 2) {
        zoom_2 = 0.12;
    }
    if (mem_cuenta == 3) {
        zoom_2 = 0.12;
    }
    //graficar_3();
    setTimeout(graficar_3, 2000);
    canvas2.setZoom(zoom_2);
}

function graficar_3() {

    canvas2 = new fabric.Canvas(Fenom);
    var object = canvas2.getActiveObject();
    canvas2.remove(object);

    //var imagen_1 = new Image();
    //var imagen_2 = new Image();
    //var imagen_3 = new Image();
    neu_sele = document.getElementById("Estado_n").checked;
    nio_sele = document.getElementById("Nino_n").checked;
    nia_sele = document.getElementById("Nina_n").checked;
    Etique = ['DEF_', 'MAM_', 'JJA_', 'SON_'];

    op1 = document.getElementById("Opc_neu").value;
    op2 = document.getElementById("Opc_nio").value;
    op3 = document.getElementById("Opc_nia").value;

    if (neu_sele == false && nio_sele == false && nia_sele == false) {
        document.getElementById("Estado_n").checked = true;
        imagen_1.src = base+'Neutro/' + Etique[0]+ 'Neutro.jpg';
        imagen_2.src = base+'Nino/' + Etique[0] + 'Nino.jpg';
        imagen_3.src = base+'Nina/' + Etique[0] + 'Nina.jpg';
    }
    else{
        imagen_1.src = base+'Neutro/' + Etique[op1] + 'Neutro.jpg';
        imagen_2.src = base+'Nino/' + Etique[op2] + 'Nino.jpg';
        imagen_3.src = base+'Nina/' + Etique[op3] + 'Nina.jpg';
    }
    
    var cuenta = 0;

    if (neu_sele == true) {
        var imgInstance_1 = new fabric.Image(imagen_1, {
            left: Top_y + (2481 * cuenta),
            top: Top_x,
            angle: 0,
            opacity: 1,
            width: 2481,
            height: 3509,
            selectable: false
        });
        canvas2.add(imgInstance_1);
        cuenta++;
    }


    if (nio_sele == true) {
        var imgInstance_2 = new fabric.Image(imagen_2, {
            left: Top_y + (2481 * cuenta),
            top: Top_x,
            angle: 0,
            opacity: 1,
            width: 2481,
            height: 3509,
            selectable: false
        });
        canvas2.add(imgInstance_2);
        cuenta++;
    }

    if (nia_sele == true) {
        var imgInstance_3 = new fabric.Image(imagen_3, {
            left: Top_y + (2481 * cuenta),
            top: Top_x,
            angle: 0,
            opacity: 1,
            width: 2481,
            height: 3509,
            selectable: false
        });
        canvas2.add(imgInstance_3);
        cuenta++;
    }
    mem_cuenta = cuenta;
    canvas2.setZoom(zoom_2);
    console.log(zoom_2);
    canvas2.on('mouse:wheel', function(opt) {
        var delta = opt.e.deltaY;
        console.log(zoom_2);
        zoom_2 = canvas2.getZoom();
        zoom_2 *= 0.999 ** delta;
        if (zoom_2 > 2) zoom_2 = 2;
        if (zoom_2 < 0.01) zoom_2 = 0.01;
        canvas2.setZoom(zoom_2);
        opt.e.preventDefault();
        opt.e.stopPropagation();
    });
    

}

function zoom_in() {
    var delta = -100;
    zoom_2 = canvas2.getZoom();
    zoom_2 *= 0.999 ** delta;
    if (zoom_2 > 2) zoom_2 = 2;
    if (zoom_2 < 0.01) zoom_2 = 0.01;
    canvas2.setZoom(zoom_2);
    opt.e.preventDefault();
    opt.e.stopPropagation();
}

function zoom_out() {
    var delta = 100;
    zoom_2 = canvas2.getZoom();
    zoom_2 *= 0.999 ** delta;
    if (zoom_2 > 2) zoom_2 = 2;
    if (zoom_2 < 0.01) zoom_2 = 0.01;
    canvas2.setZoom(zoom_2);
    opt.e.preventDefault();
    opt.e.stopPropagation();
}