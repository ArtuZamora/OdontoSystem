var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/";

$(document).ready(function () {
    $('.cancelOpt').on('click', function () {
        var id = $(this).attr('data-id');
        Swal.fire({
            title: '¿Está seguro de querer eliminar el tratamineto?',
            showDenyButton: true,
            confirmButtonText: `Sí`,
            denyButtonText: `No`,
            icon: 'info'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = baseUrl + `Treatment/Delete/?id=` + id;
            }
        });
    })
});