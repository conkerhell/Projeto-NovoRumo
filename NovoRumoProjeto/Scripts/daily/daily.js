$(document).ready(function () {
    
});

function previewFile(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#previewImage").attr("src", e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$('#fileUpload').on('change', function () {
    var fileName = this.value.substring(12, 100);

    if (fileName.match(/.jpg/) > -1 ||
        fileName.match(/.png/) > -1 ||
        fileName.match(/.jpeg/) > -1) {
        $("#displayFileName").val(fileName);
        previewFile(this);
    }
});