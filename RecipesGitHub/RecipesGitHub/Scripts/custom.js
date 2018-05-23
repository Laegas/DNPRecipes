var str = location.href.toLowerCase();
$(".nav-link").each(function () {
    if (str.indexOf($(this).attr("href").toLowerCase()) > -1) {
        $(".nav-link").removeClass("active");
        $(this).addClass("active");
    }
});
