$(document).ready(function () {
    $("#report_agk_08").click(function () {
        $("#content").text("Загрузка");
        var param = { date_report: "23.02.2015" };
        $.ajax({
            cache: false,
            data: param,
            url: '/Report/GetReportAgk08',
            success: function (data) {
                document.getElementById("content").innerHTML = data;
            },
            error: function (x, e, thrownError) {
                document.getElementById("content").innerHTML = '<p>Ошибка запроса</p><p>' + thrownError + '</p>';
            }
        });
    });
});