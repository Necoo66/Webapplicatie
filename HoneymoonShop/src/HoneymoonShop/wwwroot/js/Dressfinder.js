$(document).ready(function () {
    $(".pijltje").parent("h5").click(function () {
        $(this).children(".pijltje").toggle();
    });

    $("#prijsSlider").slider({
        tooltip: 'always'
    });
    
    $("#prijsSlider").slider().on('slideStop', function (ev) {
        var minPrijs = $("#prijsSlider").data("slider").getValue()[0];
        var maxPrijs = $("#prijsSlider").data("slider").getValue()[1];

        $(".minPrijs").text(minPrijs);
        $(".maxPrijs").text(maxPrijs);

        $('input:hidden[name=minPrijs]').val(minPrijs);
        $('input:hidden[name=maxPrijs]').val(maxPrijs);
    });

});

