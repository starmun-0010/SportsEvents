$(document).ready(function () {
    $("#country").change(function () {
        $("#city > select").attr("disabled", true);
        var url = "Countries/" + $("#country").val + "/Cities";
        var jxhr = $.get(url, function (data) {
            $("#city").replaceWith(data);
            jxhr.fail(function () {
                $("#city > select").attr("disabled", true);
            });
            jxhr.done(function () {
                $("#city > select").attr("disabled", false);
            });
        });
    });
});