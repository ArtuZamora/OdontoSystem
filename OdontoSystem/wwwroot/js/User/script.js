var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/";

$(document).ready(function () {
    $('.deleteOpt').on('click', function () {
        var id = $(this).attr('data-id');
        Swal.fire({
            title: '¿Está seguro de eliminar el usuario?',
            showDenyButton: true,
            confirmButtonText: `Sí`,
            denyButtonText: `No`,
            icon: 'info'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = baseUrl + `User/Delete/?id=` + id;
            }
        });
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