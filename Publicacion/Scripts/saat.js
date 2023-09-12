$(document).ready(function () {
    $('.date-picker').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd-mm-yy'
    });
    $('#EstacionId').selectpicker();
});
function reemplazarPunto(txt) {
    txt.value = txt.value.replace(/\./g, ',');
}