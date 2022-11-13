var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/";
var odoId, row, position, tooth;

$(document).ready(function () {
    $('#createAttendFrm select[name=patientType]').on('change', function () {
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
    $('#createAttendFrm select[name=patientType]').trigger('change');
    verifyOdontogramTeeth();
});
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