var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/";
var odoId, row, position, tooth;

$(document).ready(function () {
    $('#createAttendFrm select[name=PatientType]').on('change', function () {
        var type = $(this).val();
        switch (type) {
            case "General":
                $('#createAttendFrm .orto').hide();
                $('#createAttendFrm .general').show();
                break;
            case "Ortodoncia":
                $('#createAttendFrm .general').hide();
                $('#createAttendFrm .orto').show();
                break;
        }
    })
    $('.tooth-svg').on('click', function () {
        row = $(this).attr('data-row');
        position = $(this).attr('data-position');
        tooth = $(this).attr('data-tooth');
        var odoDetails = odontogram.find(o => o.row == row && o.side == position && o.toothNumber == tooth);
        if (odoDetails == undefined || odoDetails == null) {
            odoId = 0;
            $('#odontogramModal input[name=odoDelete]').hide();
            $('#odontogramModal textarea[name=odoDescription]').val("");
        } else {
            odoId = odoDetails.id;
            $('#odontogramModal input[name=odoDelete]').show();
            $('#odontogramModal textarea[name=odoDescription]').val(odoDetails.description);
        }
        $('#odontogramModal').modal('show');
    });
    $('#odontogramModal input[name=odoSubmit]').on('click', async function () {
        $('#ondontogramError').text("");
        var value = $('#odontogramModal textarea[name=odoDescription]').val();
        if (value.trim() == "") {
            $('#ondontogramError').text("Este campo es obligatorio");
        }
        else {
            $('#odontogramModal input[name=odoSubmit]').prop('disabled', true);
            $('#odontogramModal input[name=odoDelete]').prop('disabled', true);
            var result = await postOdontogram(odoId, patientId, position, row, tooth, value);
            $('#odontogramModal input[name=odoSubmit]').prop('disabled', false);
            $('#odontogramModal input[name=odoDelete]').prop('disabled', false);
            $('#odontogramModal').modal('hide');
            if (result)
                Swal.fire('Enhorabuena', 'Se ha registrado correctamente', 'success');
            else
                Swal.fire('Error', 'ha ocurrido un error, porfavor intente más tarde', 'error');
            odontogram = await refreshOdontograms(patientId);
            verifyOdontogramTeeth();
        }
    });
    $('#odontogramModal input[name=odoDelete]').on('click', async function () {
        $('#odontogramModal').modal('hide');
        Swal.fire({
            title: '¿Está seguro de querer eliminar esta información?',
            showDenyButton: true,
            confirmButtonText: `Sí`,
            denyButtonText: `No`,
            icon: 'info'
        }).then(async function(result) {
            if (result.isConfirmed) {
                $('#odontogramModal input[name=odoSubmit]').prop('disabled', true);
                $('#odontogramModal input[name=odoDelete]').prop('disabled', true);
                var result = await deleteOdontogram(odoId);
                $('#odontogramModal input[name=odoSubmit]').prop('disabled', false);
                $('#odontogramModal input[name=odoDelete]').prop('disabled', false);
                if (result)
                    Swal.fire('Enhorabuena', 'Se ha eliminado correctamente', 'success');
                else
                    Swal.fire('Error', 'ha ocurrido un error, porfavor intente más tarde', 'error');
                odontogram = await refreshOdontograms(patientId);
                verifyOdontogramTeeth();
            }
        });
    });
    $('#createAttendFrm').on('submit', async function () {
        event.preventDefault();
        var record = {};
        var names = $("#createAttendFrm").serializeArray().map(a => a.name);
        var values = $("#createAttendFrm").serializeArray().map(a => a.value);
        var objLength = names.length;
        for (var i = 0; i < objLength; i++) {
            if (names[i] == "Smokes") {
                var val = $('#createAttendFrm input[name=Smokes]').prop('checked');
                record[names[i]] = val;
            }
            else if (names[i] == "AlcoholicDrinks") {
                var val = $('#createAttendFrm input[name=AlcoholicDrinks]').prop('checked');
                record[names[i]] = val;
            }
            else {
                record[names[i]] = values[i];
            }
        }
        var date = $('#createAttendFrm input[name=appointmentDate]').val();
        var description = $('#createAttendFrm textarea[name=description]').val();
        var historyD = {
            id: 0,
            appointmentDate: date,
            doctorId: doctorId,
            description: description,
            patient: {
                id: patientId
            }
        };
        var periapicalRx = $('#PeriapicalRx').prop('files')[0];
        var panoramicRx = $('#PanoramicRx').prop('files')[0];
        var cephalometricRx = $('#CephalometricRx').prop('files')[0];
        formData = new FormData();
        formData.append("recordJSON", JSON.stringify(record));
        formData.append("historyJSON", JSON.stringify(historyD));
        formData.append("periapicalRx", periapicalRx);
        formData.append("panoramicRx", panoramicRx);
        formData.append("cephalometricRx", cephalometricRx);
        const result = await postRecord(formData);
        if (result) 
            Swal.fire('Enhorabuena!', 'Se ha guardado la historia del paciente corectamente', 'success').then(() => location.reload());
        else
            Swal.fire('Error!', 'Ha ocurrido un error, porfavor intente más tarde', 'error').then(() => location.reload());

    });
    $('#createAttendFrm select[name=PatientType]').val(patientType == "" ? "General" : patientType).trigger('change');
    verifyOdontogramTeeth();
});
async function postRecord(data) {
    const result = $.ajax({
        url: baseUrl + `AttendAgenda/Post/`,
        method: 'POST',
        data: data,
        cache: false,
        contentType: false,
        processData: false,
    });
    return result;
}
async function deleteOdontogram(odoId) {
    const result = $.ajax({
        url: baseUrl + `AttendAgenda/DeleteOdontogram/${odoId}`,
        method: 'DELETE',
    });
    return result;
}
async function postOdontogram(odoId, id, side, row, toothNumber, description) {
    const result = $.ajax({
        url: baseUrl + `AttendAgenda/PostOdontogram`,
        method: 'POST',
        data: {
            id: odoId,
            toothNumber: toothNumber,
            row: row,
            side: side,
            description: description,
            patient: {
                id: id
            }
        }
    });
    return result;
}
async function refreshOdontograms(id){
    const result = $.ajax({
        url: baseUrl + `AttendAgenda/GetOdontograms/?id=${id}`,
        method: 'GET'
    });
    return result;
}
function verifyOdontogramTeeth() {
    $('.tooth-svg').removeClass('active');
    odontogram.forEach(function (data) {
        $(`.tooth-svg[data-row=${data.row}][data-position=${data.side}][data-tooth=${data.toothNumber}]`).addClass('active');
    });
}