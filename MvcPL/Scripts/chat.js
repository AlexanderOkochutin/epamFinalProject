﻿$(document).ready(function () {

    setTimeout("Refresh();", 5000);

    //обработчик кнопки выхода из чата
    $("#btnLogOff").click(function() {
        //обращаемся к методу Index и передаем параметр "logOff"
        var href = "/User?id=" + encodeURIComponent($("#ProfileTo").text());
        $("#ActionLink").attr("href", href).click();
        document.location.href = href;
    });

    $('#txtMessage').keydown(function(e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnMessage").click();
        }
    });

    //установка обработчика нажатия кнопки для отправки сообщений
    $("#btnMessage").click(function () {
        var text = $("#txtMessage").val();
        if (text) {

            //обращаемся к методу Index и передаем параметр "chatMessage"
            var href = "/Message/SendMessage?id=" + encodeURIComponent($("#ProfileTo").text());
            href = href + "&chatMessage=" + encodeURIComponent(text);
            $("#ActionLink").attr("href", href).click();
        }
    });
});

function Refresh() {
    var href = "/Message/SendMessage?id=" + encodeURIComponent($("#ProfileTo").text());
    $("#ActionLink").attr("href", href).click();
    setTimeout("Refresh();", 5000);
}


function ChatOnFailure(result) {
    $("#Error").text(result.responseText);
    setTimeout("$('#Error').empty();", 2000);
}

function ChatOnSuccess(result) {
    Scroll();
}

function Scroll() {
    if ($(window).scrollTop() + $(window).height() == $(document).height()) {
        window.scrollTo(0, document.body.scrollHeight);
    }
}