var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/";

$(document).ready(function () {
    $('.cancelOpt').on('click', function () {
        var id = $(this).attr('data-id');
        Swal.fire({
            title: '¿Está seguro de querer cancelar la cita?',
            showDenyButton: true,
            confirmButtonText: `Sí`,
            denyButtonText: `No`,
            icon: 'info'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = baseUrl + `Agenda/Cancelar/?id=` + id;
            }
        });
    })
});