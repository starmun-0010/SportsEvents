$(document).ready(function (e) {
    $(".partial-contents-events").each(load);

});
$(document).ready(function (e) {
    $(".partial-contents-adds").each(loadAdvertisements);

});

var loadingAdvertisements = false;

function loadAdvertisements(index, item) {
    if (loadingAdvertisements) {
        return;
    }

    loadingAdvertisements = true;
    var url = $(item).data("url");

    if (url && url.length > 0) {
        var jxhr = $.get(url, function (data) {
            $("#advertiements").replaceWith(data);
            jxhr.always(function () {
                loadingAdvertisements = false;
            });
        });
    }
}

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

var addClass = function (el, className) {
    if (el.classList) {
        el.classList.add(className);
    } else {
        el.className += ' ' + className;
    }
},
    hasClass = function (el, className) {
        return el.classList ?
            el.classList.contains(className) :
            new RegExp('(^| )' + className + '( |$)', 'gi').test(el.className);
    },
    removeClass = function (el, className) {
        if (el.classList) {
            el.classList.remove(className);
        } else {
            el.className = el.className.replace(new RegExp('(^|\\b)' + className.split(' ').join('|') + '(\\b|$)', 'gi'), ' ');
        }
    },
    updateSelectPlaceholderClass = function (el) {
        var opt = el.options[el.selectedIndex];
        if (hasClass(opt, "placeholder")) {
            addClass(el, "placeholder");
        } else {
            removeClass(el, "placeholder");
        }
    },
    selectList = document.querySelectorAll("select");
//Simulate placeholder text for Select box
for (var i = 0; i < selectList.length; i++) {
    var el = selectList[i];
    updateSelectPlaceholderClass(el);
    el.addEventListener("change", function () {
        updateSelectPlaceholderClass(this);
    });
}
