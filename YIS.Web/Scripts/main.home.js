//$(document).ready(function () {
//    $("button").click(function (event) {
//        alert("You clicked");
//    });  
//});

//$(document).ready(function () {
//    $("button").click(function (event) {
//        debugger;
//        $.ajax({
//            type: "POST",
//            dataType: "json",
//            url: '@Url.Action("GetGDPChartModel","JsonHome")',
//            success: function (data) {
//                alert(data);
//            },            
//            error: function (result) {
//                alert(result.responseText);
//            }
//        });
//    });
//});
$(document).ready(function () {
    $("button").click(function () {        
        $.getJSON("/JsonHome/GetGDPChartModel", null, function (data) {
            alert(JSON.stringify(data));
        });
    })
});