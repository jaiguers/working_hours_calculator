$(document).ready(function () {
    //Date range picker with time picker
    $('#StarDate').daterangepicker({
        timePicker: true,
        timePickerIncrement: 30,
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        maxYear: parseInt(moment().format('YYYY'), 10),
        locale: {
            format: 'YYYY-MM-DD HH:mm'
        }
    }, function (start, end, label) {
        console.log('StarDate:');
        console.log(start);
    });

    $('#EndDate').daterangepicker({
        timePicker: true,
        timePickerIncrement: 30,
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        maxYear: parseInt(moment().format('YYYY'), 10),
        locale: {
            format: 'YYYY-MM-DD HH:mm'
        }
    }, function (start, end, label) {
        console.log('EndDate:');
        console.log(start);
    });
});

function registerHours() {

    if ($('#formHours').valid()) {
        SubmitFn('formHours');

        /*
          var data = $('#formHours').serializeObject();
    
            $.ajax({
                url: "http://localhost:57088/api/Report/RegisterHours",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: { data },
                type: "POST",
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
        else {
            NotificaFn("error", "Por favor verifique los campos diligenciados.");
        }
         */

    }
}
