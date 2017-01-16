$(document).ready(function () {
    $(".pijltje").parent("h5").click(function () {
        $(this).children(".pijltje").toggle();
    });

    $("#prijsSlider").slider();
});

