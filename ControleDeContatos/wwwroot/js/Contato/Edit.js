document.addEventListener("DOMContentLoaded", function () {
    $("#btn-incluirObservacao").on("click", function () {
        var url = "/Contato/CriarObservacao?txtContatoId="+$("#hdnId").val()+ "&" +"txtObservacao=" + $("#txtObservacao").val() + "&" + "txtDataAtendimento=" + $("#txtDataAtendimento").val();
        var json = '';

        $().AjaxPostCustom(url, json, true, function (result) {
            
        });
    });
});

