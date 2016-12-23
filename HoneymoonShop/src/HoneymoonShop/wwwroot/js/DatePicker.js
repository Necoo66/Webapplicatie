﻿/*DATEPICKER*/
var disableddates = new Array;
var selected;
var date = new Date();
window.onload = getAvalibleDates(date.getMonth() + 1, date.getFullYear());

function DisableSpecificDates(date) {
    var string = jQuery.datepicker.formatDate('dd-mm-yy', date);
    return [disableddates.indexOf(string) === -1];
}

$('#datepicker')
    .datepicker({
        dateFormat: 'dd-mm-yy',
        inline: true,
        onSelect: function (dateText, inst) {
            var date = $(this).datepicker('getDate');
            selected = $(this).val();
            //getAvalibleTimes();
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
    console.log("sqlDates of data:", sqlDates.slice(0, 100));
    console.log("disableddates of data:", disableddates.slice(0, 100));
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
    console.log("sqlDates of data:", sqlDates.slice(0, 100));
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

function toggleSelecteerTijd(id1, id2, id3)
{
   // alert("message alert");
    var e1 = document.getElementById(id1);
    var e2 = document.getElementById(id2);
    var e3 = document.getElementById(id3);

    if(e1.style.display === "block") {
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

function toggleSelecteerTijdstip(id1, id2, id3)
{
    var e1 = document.getElementById(id1);
    var e2 = document.getElementById(id2);
    var e3 = document.getElementById(id3);


}