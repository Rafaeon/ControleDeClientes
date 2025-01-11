// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});



$(document).ready(function () {
    getDataTable('#table-contatos');
    getDataTable('#table-usuarios');
})

function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

function stringEscape(s) {
    return s ? s.replace(/\\/g, '\\\\') : s;
    function hex(c) { var v = '0' + c.charCodeAt(0).toString(16); return '\\x' + v.substr(v.length - 2); }
}
$.fn.AjaxPostCustom = function (url, textData, isAsync, callbackSuccess) {

    $.ajax({
        type: "POST",
        url: url,
        data: stringEscape(textData),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        processData: false,
        success: function (result) {
            callbackSuccess(result);
            location.reload();
        },

        async: isAsync,
        //error: function (xhr, ajaxOptions, thrownError) { alert(xhr.responseText); }
        error: function (xhr, ajaxOptions, thrownError) {
        }
    });
};
