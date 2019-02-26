$(function () {
    $('.myContainer input[type=file]').change(function () {
        $(this).next().find('input[type=text]').val($(this).val().split('\\').pop());
        var myButton = $(this).parents('.form-group').next().find('input[type=submit]');
        myButton.prop("disabled", false);
    });
    
    $('button.btn-choose').click(function () {
        $(this).parents('.input-file').prev().click();
    });

    $('.myContainer input[type=text]').mousedown(function () {
        $(this).parents('.input-file').prev().click();
        return false;
    });

});