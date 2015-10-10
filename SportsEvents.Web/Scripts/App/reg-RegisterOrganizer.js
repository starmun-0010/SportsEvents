$(document).ready(function () {
    $("#country").change(getCities);
    $("#contactCountry").change(getContactCities);

});

function getCities() {

    $("#city").attr("disabled", true);
    var url = "/Countries/" + $("#country").val() + "/Cities";
    var jxhr = $.get(url, function (data) {
        $("#city").html(data);
        jxhr.fail(function () {
            $("#city").attr("disabled", true);
        });
        jxhr.done(function () {
            $("#city").attr("disabled", false);
        });
    });
}

function getContactCities() {

    $("#contactCity").attr("disabled", true);
    var url = "/Countries/" + $("#contactCountry").val() + "/Cities";
    var jxhr = $.get(url, function (data) {
        $("#contactCity").html(data);
        jxhr.fail(function () {
            $("#contactCity").attr("disabled", true);
        });
        jxhr.done(function () {
            $("#contactCity").attr("disabled", false);
        });
    });
}
