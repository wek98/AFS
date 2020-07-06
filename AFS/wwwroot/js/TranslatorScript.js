$(document).ready(function () {
    $("#btn").click(function (e) {
        var outputrecord = "";
        var inputrecord = $("#enterText").val();
        e.preventDefault();
        $.post("/Home/TranslateToLeetAjax", { inputString: inputrecord }, function (data) {
            //alert(data);
            setInterval($("#Result").text(data), 5000);
            outputrecord = data;
        });
        $("#Result").text(outputrecord);
    });
}); 