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
    $(".emailCheck").last().focusout(function () {
        var email = [$("input[type='email']").val()];
        if(email[0] !== email[1]){
            var alert = $(".hidden");
            alert.addClass("alert alert-warning alert-dismissible fade in").removeClass("hidden");
            //alert.removeClass("hidden");
        }
    });
    //$(".alert-warning alert-dismissable").on("")
    //$("").is(":visible")

    });

