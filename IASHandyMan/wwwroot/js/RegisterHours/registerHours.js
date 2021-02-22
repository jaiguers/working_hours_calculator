$(document).ready(function () {
    //Date range picker with time picker
    $('#reservationtime').daterangepicker({
        timePicker: true,
        timePickerIncrement: 30,
        locale: {
            format: 'MM/DD/YYYY hh:mm A'
        }
    });
});

function registerHours() {

    $.ajax({
        url: "/Reviews/Reviews/GetDocs",
        data: { id: idDoc },
        type: "GET",
    }).done(function (result) {

        console.log(result);

        if (result.success) {


            // $('#pdfDisplay').modal();
        }
        else {
            console.error("Error ver documentos");
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Error en el servidor");
    });

}