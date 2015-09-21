$(document).ready(function (e) {
    $(".partial-contents").each(load);

});
var loading = false;

function load(index, item) {
    if (loading) {
        return;
    }

    loading = true;
    var url = $(item).data("url");

    if (url && url.length > 0) {
        var jxhr = $.get(url, function (data) {
            $(".loading").before(data);
            jxhr.always(function () {
                loading = false;
            });
        });
    }
}

$(window).scroll(function () {
    if ($(window).scrollTop() + $(window).height() > $(document).height() - 150) {
        if (loading) {
            return;
        }

        loading = true;
        var skip = +$("#skip").val() + +$("#take").val();
        var count = +$("#count").val();
        var take = 10;

        if (count <= skip) {
            if (!$('.loading').hasClass("loading-hidden")) {
                $('.loading').addClass("loading-hidden");
            }
            return;
        }
        var url = $("#events").data("url");
        if (url && url.length > 0) {
            url += "/?skip=" + skip + "&take=" + take;
            var jxhr = $.get(url, function (data) {
                $("#statistics").replaceWith(data);
                jxhr.always(function () {
                    loading = false;
                });
            });
        }
    }
});