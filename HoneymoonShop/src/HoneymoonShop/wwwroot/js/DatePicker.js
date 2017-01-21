/*DATEPICKER*/
var disableddates = new Array;
var date = new Date();
var selected;
window.onload = getAvalibleDates(date.getMonth() + 1, date.getFullYear());

function DisableSpecificDates(date) {
    var string = jQuery.datepicker.formatDate('dd-mm-yy', date);
    return [disableddates.indexOf(string) === -1];
}

var dayNames = ["zondag", "maandag", "dinsdag", "woensdag", "donderdag", "vrijdag", "zaterdag"];
var monthNames = ["januari", "februari", "maart", "april", "mei", "juni", "juli", "augustus", "september", "oktober", "november", "december"];
var dayNamesMin = ["zo", "ma", "di", "wo", "do", "vr", "za"];

$('#datepicker')
    .datepicker({
        dateFormat: 'dd-mm-yy',
        inline: true,
        currentText: "Vandaag",
        monthNames: monthNames,
        monthNamesShort: ["jan", "feb", "mrt", "apr", "mei", "jun",
        "jul", "aug", "sep", "okt", "nov", "dec"],
        dayNames: dayNames,
        dayNamesShort: ["zon", "maa", "din", "woe", "don", "vri", "zat"],
        dayNamesMin: dayNamesMin,
        weekHeader: "Wk",
        onSelect: function (dateText, inst) {
            date = $(this).datepicker('getDate');
            selected = $(this).val();
            $("#Afspraak_Datum").val(jQuery.datepicker.formatDate('dd-mm-yy', date));
            $(".datumbanner").text(dayNamesMin[date.getDay()] + " " + date.getDate() + " " + monthNames[date.getMonth()] + " " + date.getFullYear());
        },
        onChangeMonthYear: function (year, month, widget) {
            getAvalibleDates(month, year);
        },
        minDate: +0,
        beforeShowDay: DisableSpecificDates
    });

function getAvalibleDates(month, year) {
    $.ajax({
        type: "POST",
        url: "/Afspraak/GetAvalibleDates",
        data: { month: month, year: year },
        success: successDate
    });
}

function successDate(sqlDates) {
    disableddates = [];
    for (var i = 0; i < sqlDates.length; i++) {
        disableddates[i] = toDate(sqlDates[i]);
    }

    $("#datepicker").datepicker("refresh");
}

function toDate(sqlDate) {
    var from = ("" + sqlDate).substr(0, 10).split('-');
    return from[2] + "-" + from[1] + "-" + from[0];
}

function stringDateToJason(select) {
    var from = ("" + select).split('-');
    return jQuery.parseJSON('{ "day": "' + from[0] + '" , "month": "' + from[1] + '" , "year": "' + from[2] + '" }');
}

function getAvalibleTimes() {
    $.ajax({
        type: "POST",
        url: "/Afspraak/GetTakenTimes",
        data: stringDateToJason(selected),
        success: successTijd
    });
}

function successTijd(sqlDates) {

    document.getElementById("radio1").style.display = "block";
    document.getElementById("radio2").style.display = "block";
    document.getElementById("radio3").style.display = "block";

    for (var i = 0; i < sqlDates.length; i++) {
        if ("" + sqlDates[i] === "9:30") {
            document.getElementById("radio1").style.display = "none";
        }
        if ("" + sqlDates[i] === "12:30") {
            document.getElementById("radio2").style.display = "none";
        }
        if ("" + sqlDates[i] === "15:00") {
            document.getElementById("radio3").style.display = "none";
        }
    }
}

/*TOGGLE*/
function toggleVisibility(id) {
    var e = document.getElementById(id);
    if (e.style.display === "none") {
        e.style.display = "none";
    } else {
        e.style.display = "block";
    }
}

function ToggelPages(id1, id2, id3) {
    if (id1 === "stap1") {
        $('div[id="stap1a"]').css("display", "block");
    } else {
        $('div[id="stap1a"]').css("display", "none");
    }
    $('div[id="' + id1 + '"]').css("display", "block");
    $('div[id="' + id2 + '"]').css("display", "none");
    $('div[id="' + id3 + '"]').css("display", "none");
    $('div[id="stap1b"]').css("display", "none");
}

function toggleSelecteerTijd(id1, id2, id3) {

    if (!$("input[name='Afspraak.Tijd']:checked").val()) {
        alert('Selecteer een tijd!');
    }
    else {
        $('div[id="' + id1 + '"]').css("display", "block");
        $('div[id="' + id2 + '"]').css("display", "none");
        $('div[id="' + id3 + '"]').css("display", "none");
        $('div[id="stap1b"]').css("display", "none");
        $('div[id="stap1a"]').css("display", "none");
        $(".datumbanner").text(dayNamesMin[date.getDay()] + " " + date.getDate() + " " + monthNames[date.getMonth()] + " " + date.getFullYear() + " om " + $("input:radio[name='Afspraak.Tijd']:checked").val() + " u");
    }
}

function toggleSelecteerDatum(id1, id2, id3) {

    if (selected == null) {
        alert("Selecteer een Datum");
    } else {
        var e1 = document.getElementById(id1);
        var e2 = document.getElementById(id2);
        var e3 = document.getElementById(id3);

        if (e1.style.display === "block") {
            e1.style.display = "none";
            e2.style.display = "block";
            e3.style.display = "block";

        }
        else {
            e1.style.display = "block";
            e2.style.display = "none";
            e3.style.display = "none";
        }
        getAvalibleTimes();
    }

}

function checkform() {
    var naam = $('#Gebruiker_VoornaamAchternaam').val().split(" ");

    if (naam.length >= 2) {
        if ($("#MyForm").valid()) {
            $('div[id="stap3"]').css("display", "block");
            $('div[id="stap1"]').css("display", "none");
            $('div[id="stap2"]').css("display", "none");
            //Set
            document.getElementById('LBnaam').innerHTML = $('#Gebruiker_VoornaamAchternaam').val();
            document.getElementById('LBtrouwdatum').innerHTML = toDate($('#Gebruiker_Trouwdatum').val());
            document.getElementById('LBtelefoon').innerHTML = $('#Gebruiker_Telefoonnummer').val();
            document.getElementById('LBemail').innerHTML = $('#Gebruiker_Email').val();
        }
    }
}

/*radiobuttons voor tijd*/
$("input[name='Tijd']").change(function () {
    var tijd = $(this).val();
    $("#Afspraak_Tijd").val(tijd);
});