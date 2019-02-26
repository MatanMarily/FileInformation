$(function () {
    $(".input-file").before(
        function () {
            if (!$(this).prev().hasClass('input-ghost')) {
                var element = $("<input type='file' accept='.txt, .txt,.html,.html,.js,.js,.css,.css' class='input-ghost' style='visibility:hidden; height:0'>");
                element.attr("name", $(this).attr("name"));
                element.change(function () {
                    element.next(element).find('input').val((element.val()).split('\\').pop());
                    $('#submit_btn').prop("disabled", false);
                });
                $(this).find("button.btn-choose").click(function () {
                    element.click();
                });
                $(this).find("button.btn-reset").click(function () {
                    $('#submit_btn').prop("disabled", true);
                    element.val(null);
                    $(this).parents(".input-file").find('input').val('');
                });
                $(this).find('input').css("cursor", "pointer");
                $(this).find('input').mousedown(function () {
                    $(this).parents('.input-file').prev().click();
                    return false;
                });
                return element;
            }
        }
    );

    $('#btn-reset').click(function () {
        $('#submit_btn').prop("disabled", true);
    });

    if ($('.all-data-div').length > 0) {
        $('#submit_btn_filter').prop("disabled", false);
        $('.loader').css("display", "inline-block");
    }

    $('#download-button').click(function () {
        var url = "/Home/DownloadFile";
        $.post(url, function (data) {
            alert("Thanks, your file are downloaded successfully!\n file is exsist in: C\\MyDownlads\\file.txt");
        });
    });

    $(window).load(function () {
        if ($('.all-data-div').length > 0) {
            $('.all-data-div').html($('.all-data-div').html().replace(/\/n/g, "\n"));
            $('.all-data-div').css("white-space", "pre-wrap");
            $('.all-data-div').show();
            $('.loader').hide();
        }
    });

    $('#submit_btn_filter').click(function () {
        if ($('#sub-str').val().length > 0) {
            $('#div-filter').hide();
            $('.loader-filter').show();
            var url = "/Home/Filtering";
            var subStr = $('#sub-str').val();
            $.post(url, { subString: subStr }, function (data) {
                $(".data-filter-div").html(data);
                $('.data-filter-div').css("white-space", "pre-wrap");
                var regex = new RegExp(subStr, "g");
                $('.data-filter-div').html($('.data-filter-div').html().replace(regex, '<mark>' + subStr + '</mark>'));
                $('#div-filter').show();
                $('.loader-filter').hide();
            });
        } else {
            alert("Enter at least one character to search");
        }
    })
});