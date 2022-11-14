var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/";

$(document).ready(function () {

    $('.cancelOpt').on('click', function () {
        var id = $(this).attr('data-id');
        Swal.fire({
            title: '¿Está seguro de querer eliminar este paciente?',
            showDenyButton: true,
            confirmButtonText: `Sí`,
            denyButtonText: `No`,
            icon: 'info'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = baseUrl + `Paciente/Delete/?id=` + id;
            }
        });
    });

    $('#citafrm select[name=PatientId]').select2({
        dropDownParent: $('#citafrm')
    });
    $('#createPatient').on('click', function () {
        $('#createPatientModal').modal('show');
    });    
    $('#createTemporalPatientFrm').on('submit', async function () {
        event.preventDefault();
        var formDataArr = $('#createTemporalPatientFrm').serializeArray();
        var names = formDataArr.map(fd => fd.name);
        var values = formDataArr.map(fd => fd.value);
        var data = {};
        var objLength = names.length;
        for (var i = 0; i < objLength; i++) {
            data[names[i]] = values[i];
        }
        var result = await postPaciente({
            "paciente": data,
            "__RequestVerificationToken": data['__RequestVerificationToken']
        });
        if (result == "Se ha creado el paciente exitosamente") {
            $('#createPatientModal').modal('hide');
            Swal.fire('Enhorabuena', result, 'success');
            refreshPacientes();
        }
        else if (result == 'Han existido errores procesando su solicitud. Porfavor intente más tarde') {
            $('#createPatientModal').modal('hide');
            Swal.fire('Error', result, 'error').then(function () { $('#createPatientModal').modal('show'); });
        }
    });
    var table = $('#table').DataTable({
        "language": { "url": "https://cdn.datatables.net/plug-ins/1.11.3/i18n/es_es.json" },
        "responsive": true,
        "lengthChange": true,
        "dom": '<"html5buttons"B>lTfgitp',
        "autoWidth": false,
        "buttons": [
            { extend: 'copy' },
            { extend: 'excel' },
            { extend: 'pdf' },
            { extend: 'colvis' }
        ]
    });
});

async function refreshPacientes() {
    $('#citafrm select[name=PatientId]').empty();
    var pacientes = await getPacientes();
    $('#citafrm select[name=PatientId]').append(new Option("Seleccione...", "", false, true));
    pacientes.forEach(function (paciente) {
        var newOption = new Option(paciente.firstName + " " + paciente.middleName + " " + paciente.lastName, paciente.id, false, true);
        $('#citafrm select[name=PatientId]').append(newOption).trigger('change');
    });
    $('#citafrm select[name=PatientId]').trigger('change');
}

async function postPaciente(data) {
    const result = await $.ajax({
        url: baseUrl + `Paciente/CreateTemporal/`,
        type: 'POST',
        data: data
    });
    return result;
}

async function getPacientes() {
    const result = await $.ajax({
        url: baseUrl + `Paciente/GetDDL/`,
        type: 'GET'
    });
    return result;
}