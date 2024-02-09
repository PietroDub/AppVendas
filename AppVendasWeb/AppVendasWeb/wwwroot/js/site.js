// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    var cpfInput = document.getElementById('CPF');
    var celInput = document.getElementById('Telefone');
    cpfInput.addEventListener('input', function () {
        var cpf = cpfInput.value.replace(/\D/g, '');
        cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2");
        cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2");
        cpf = cpf.replace(/(\d{3})(\d{2})$/, "$1-$2");
        cpfInput.value = cpf;
    });
    celInput.addEventListener('input', function () {
        var cel = celInput.value.replace(/\D/g, '');
        cel = cel.replace(/(\d{2})(\d)/, "($1) $2");
        cel = cel.replace(/(\d{5})(\d)/, "$1-$2");
        celInput.value = cel;
    });
});
