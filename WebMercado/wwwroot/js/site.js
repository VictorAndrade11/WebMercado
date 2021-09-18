// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


adicionado = function (xhr) {
    swal({
        title: "Produto adicionado ao carrinho!",
        icon: "success",
        buttons: {
            continue: "Continuar Comprando ",
            goCart: { text: "Abrir meu Carrinho", value: "goCart" }
        }
    })
        .then((value) => {
            if (value == "goCart") {
                window.location.href = '/Cart/Index';
            };
        });
};



