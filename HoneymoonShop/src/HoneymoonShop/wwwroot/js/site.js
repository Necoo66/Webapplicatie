// Write your Javascript code.
function dynamicBanner() {
    if (document.getElementById("banner")) {
        document.body.style.backgroundColor = "#ffe4ea";
        document.getElementById("IDnavigation").className += ' navigationwhite';
        document.getElementById("noBanner").style.display = "none";
    } else {
        document.getElementById("noBanner").style.display = "block";
    }
}
window.onload = dynamicBanner;

/*DATEPICKER*/
//datum die niet beschikbaar zijn
var disableddates = ["20-12-2016", "12-12-2016", "13-12-2016", "01-01-2017"];
function DisableSpecificDates(date) {
    var string = jQuery.datepicker.formatDate('dd-mm-yy', date);
    if (disableddates.indexOf(string) !== -1) {
        return [false, "datumNonactief"];//geef een classe aan vol geplande datums
    } else
        return [disableddates.indexOf(string) === -1];
}
$(function () {
    $("#datepicker").datepicker({
        onSelect: function (dateText, inst) {
            var d = inst.currentDay + "-" + inst.currentMonth + "-" + inst.currentYear;
            $("#DatumSelecteren").attr("href", "/gebruiker/create?datum=" + d);
        },
        minDate: 0, //0 tot vandaag, 1 t/m vandaag, 2 morge
        beforeShowDay: DisableSpecificDates // ga naar functie
    });
});
$(function () {
    if ($("#datepicker").length) {
        var date = $("#datepicker").datepicker("getDate");
        var d = date.getDay() + "-" + (date.getMonth() + 1) + "-" + date.getFullYear();
        $("#DatumSelecteren").attr("href", "/afspraak/stap01b?datum=" + d);
    }
});



/*TOGGLE*/
function toggleVisibility(id) {
    var e = document.getElementById(id);
    if (e.style.display === "none") {
        e.style.display = "none";
    } else {
        e.style.display = "block";
    }
}

function toggleVisibility(id1, id2) {
    var e1 = document.getElementById(id1);
    var e2 = document.getElementById(id2);
    if (e1.style.display === "none") {
        e1.style.display = "block";
        e2.style.display = "none";
    } else {
        e1.style.display = "none";
        e2.style.display = "block";
    }
}

function toggleAfsrpaakmaken(id1, id2, id3, id4, id5, id6, id7, id8, id9) {
    if (document.getElementById(id1).style.display === "none") {
        document.getElementById(id1).style.display = "block";
        document.getElementById(id2).style.display = "block";
        document.getElementById(id3).style.display = "block";
        document.getElementById(id4).style.display = "none";
        document.getElementById(id5).style.display = "none";
        document.getElementById(id6).style.display = "none";
        document.getElementById(id7).style.display = "none";
        document.getElementById(id8).style.display = "none";
        document.getElementById(id9).style.display = "none";
    } 
}


$("document").ready(function () {
    $('#myform').submit(function () {
        if ($(".emailCheck2").val() === $(".emailCheck1").val()) {
            return true;
        } else {
            var alert = $(".hidden");
            console.log(alert);
            alert.addClass("alert alert-warning alert-dismissible fade in text-center").removeClass("hidden");
            alert.html("<a href='#' class='close' data-dismiss='alert'>&times;</a><strong> De ingevoerde emails komen niet overeen. </strong>" );
            return false;
        }
    });
});

