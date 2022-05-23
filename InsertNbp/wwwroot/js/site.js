// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#currency-date").attr('max', new Date().toISOString().split("T")[0]);

$("#currency-date").min = "2002-01-02";

$("#currency-date").change(function () {
    if ($(this).val()) {
        window.location = "/Home/Index/" + $(this).val();
    }
    
})