var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/";

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
    $('#createAttendFrm select[name=patientType]').trigger('change');
});
