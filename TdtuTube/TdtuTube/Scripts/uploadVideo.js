$(document).ready(function () {
    $("#inputTitle").keyup(function () {
        $("#result-title-video").text($("#inputTitle").val());
    })
    $("#inputDes").keyup(function () {
        $("#result-des-video").text($("#inputDes").val());
    })
});