$(function () {

    $("a.deleteAnuncio").click(function (e) {

        e.preventDefault();
        _this = $(this);
        var url = _this.attr("href");

        var vAnuncio = $(_this).attr("data-delete");
        var dialog = confirm("Deseja realmente excluir " + vAnuncio + " ?");

        if (dialog) {
            window.location.href = url;
        }

    })

})