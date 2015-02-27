$(document).ready(function () {
    $("#head_type").click(function () {
        $.ajax({
            cache: false,
            url: '/Head/GetTypes',
            success: function (data) {
                document.getElementById("content").innerHTML = data;
            },
            error: function (x, e, thrownError) {
                document.getElementById("content").innerHTML = '<p>Ошибка запроса</p><p>' + thrownError + '</p>';
            }
        });
    });
});

function LoadSitesByType(TypeId) {
    var param = { typeid: TypeId };
    $("#panel-body-" + TypeId).text("Загрузка");
    $.ajax({
        cache: false,
        url: '/Head/GetSites',
        data: param,
        success: function (data) {
            document.getElementById("panel-body-" + TypeId).innerHTML = data;
        },
        error: function (x, e, thrownError) {
            document.getElementById("panel-body-" + TypeId).innerHTML = '<p>Ошибка запроса</p><p>' + thrownError + '</p>';
        }
    });    
    
}