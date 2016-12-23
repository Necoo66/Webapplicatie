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

function toggleAfsrpaakmaken(id1, id2, id3, id4, id5, id6, id7, id8, id9, id10) {
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
        document.getElementById(id10).style.display = "none";
    }
}

$("document").ready(function () {
    $('#myform').submit(function () {
        if ($(".emailCheck2").val().toLowerCase() === $(".emailCheck1").val().toLowerCase()) {
            return true;
        } else {
            var alert = $(".hidden");
            console.log(alert);
            alert.addClass("alert alert-warning alert-dismissible fade in text-center").removeClass("hidden");
            alert.html("<a href='#' class='close' data-dismiss='alert'>&times;</a><strong> De ingevoerde emails komen niet overeen. </strong>");
            return false;
        }
    });


    var datum;
    var naam;
    var trouwdatum;
    var telefoonnummer;
    var emailadres;
    
    $("#ButtonStap3").click(function () {
        initData();
        setData();
    });


});

function setData() {
    //alert(naam + trouwdatum + telefoonnummer + emailadres);
    $("#datumEntijdOverzicht").html("Datum en tijd: " + datum);
    $("#NaamOverzicht").html(naam);
    $("#TrouwdatumOverzicht").html(trouwdatum);
    $("#TelefoonOverzicht").html(telefoonnummer);
    $("#EmailOverzicht").html(emailadres);
}

function initData(){
    datum = $("#Afspraak_Datum").val();
    datum += $("#Afspraak_Tijd").val().toString();
    naam = $("#Gebruiker_Naam").val();
    trouwdatum = $("#Gebruiker_Trouwdatum").val();
    telefoonnummer = $("#Gebruiker_Telefoonnummer").val();
    emailadres = $("#Gebruiker_Emailadres").val();
}