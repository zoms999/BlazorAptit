// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$("#btnStart").click(function () {

//    var userJob = $('input[name=User_Job]:checked').val();

//    if (userJob == "A" || userJob == "B" || userJob == "C") {
//        $("#txt_User_Class_danger2").text("(반)을 입력해주세요.");
//        return;
//     }
    
//});

if ($("#select_User_Grade").val() == "해당없음") {
    $("#txt_User_Class").val('');
    $('#txt_User_Class').attr('disabled', true);
}

$("#select_User_Grade")

function ToggleInfo(el) {
    var result = el.value;
    console.log(result);

    if (result == "F") {
        $('#select_User_Grade').attr('disabled', true);
        $('#select_User_Grade option:eq(0)').prop('selected', true);
        $("#txt_User_Class").val('');
        $('#txt_User_Class').attr('disabled', true);
    }
    else if (result == "D" || result == "E")
    {
        $("#txt_User_Class").val('');
        $('#select_User_Grade').attr('disabled', true);
        $('#txt_User_Class').attr('disabled', true);
    }
    else {
        $('#select_User_Grade').attr('disabled', false);
        $("#txt_User_Class").val('');
        $('#txt_User_Class').attr('disabled', false);
    }
}


$("#select_User_Grade").change(function () {
    //alert(this.value);
    if (this.value == "해당없음") {
        $("#txt_User_Class").val('');
        $('#txt_User_Class').attr('disabled', true);
    }
    else {
        $('#txt_User_Class').attr('disabled', false);

    }
});

$("#select_User_Edu").change(function () {
    //alert(this.value);
    if (this.value == "전공") {

        $('#User_Finish').attr('disabled', false);

    }
    else if (this.value == "해당없음") {

        $("#User_Finish").val('');
        $('#User_Finish').attr('disabled', true);
    }
});

$("#btnLink").click(function () {
    $('#ModalPopUp').modal('show');
})

$("#passFind").click(function () {
    $('#ModalFindPass').modal('show');
})

$("#btn-next").click(function () {

    //alert($("input[type='radio']:radio:checked").length)
    if ($("input[type='radio']:radio:checked").length == 20) {
        $("form").submit();
    }
    else {

        if (document.getElementsByName('AQ_1')[0].checked == false && document.getElementsByName('AQ_1')[1].checked == false && document.getElementsByName('AQ_1')[2].checked == false
            && document.getElementsByName('AQ_1')[3].checked == false && document.getElementsByName('AQ_1')[4].checked == false && document.getElementsByName('AQ_1')[5].checked == false) {
            $('#toastbody').text('1번문제에 체크해주세요.');
            $('.toast').toast('show');

            document.getElementsByName('AQ_1')[0].focus();
        }
        else if (document.getElementsByName('AQ_2')[0].checked == false && document.getElementsByName('AQ_2')[1].checked == false && document.getElementsByName('AQ_2')[2].checked == false
            && document.getElementsByName('AQ_2')[3].checked == false && document.getElementsByName('AQ_2')[4].checked == false && document.getElementsByName('AQ_2')[5].checked == false) {
            $('#toastbody').text('2번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_2')[0].focus();
        }
        else if (document.getElementsByName('AQ_3')[0].checked == false && document.getElementsByName('AQ_3')[1].checked == false && document.getElementsByName('AQ_3')[2].checked == false
            && document.getElementsByName('AQ_3')[3].checked == false && document.getElementsByName('AQ_3')[4].checked == false && document.getElementsByName('AQ_3')[5].checked == false) {
            $('#toastbody').text('3번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_3')[0].focus();
        }
        else if (document.getElementsByName('AQ_4')[0].checked == false && document.getElementsByName('AQ_4')[1].checked == false && document.getElementsByName('AQ_4')[2].checked == false
            && document.getElementsByName('AQ_4')[3].checked == false && document.getElementsByName('AQ_4')[4].checked == false && document.getElementsByName('AQ_4')[5].checked == false) {
            $('#toastbody').text('4번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_4')[0].focus();
        }
        else if (document.getElementsByName('AQ_5')[0].checked == false && document.getElementsByName('AQ_5')[1].checked == false && document.getElementsByName('AQ_5')[2].checked == false
            && document.getElementsByName('AQ_5')[3].checked == false && document.getElementsByName('AQ_5')[4].checked == false && document.getElementsByName('AQ_5')[5].checked == false) {
            $('#toastbody').text('5번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_5')[0].focus();
        }
        else if (document.getElementsByName('AQ_6')[0].checked == false && document.getElementsByName('AQ_6')[1].checked == false && document.getElementsByName('AQ_6')[2].checked == false
            && document.getElementsByName('AQ_6')[3].checked == false && document.getElementsByName('AQ_6')[4].checked == false && document.getElementsByName('AQ_6')[5].checked == false) {
            $('#toastbody').text('6번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_6')[0].focus();
        }
        else if (document.getElementsByName('AQ_7')[0].checked == false && document.getElementsByName('AQ_7')[1].checked == false && document.getElementsByName('AQ_7')[2].checked == false
            && document.getElementsByName('AQ_7')[3].checked == false && document.getElementsByName('AQ_7')[4].checked == false && document.getElementsByName('AQ_7')[5].checked == false) {
            $('#toastbody').text('7번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_7')[0].focus();
        }
        else if (document.getElementsByName('AQ_8')[0].checked == false && document.getElementsByName('AQ_8')[1].checked == false && document.getElementsByName('AQ_8')[2].checked == false
            && document.getElementsByName('AQ_8')[3].checked == false && document.getElementsByName('AQ_8')[4].checked == false && document.getElementsByName('AQ_8')[5].checked == false) {
            $('#toastbody').text('8번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_8')[0].focus();
        }
        else if (document.getElementsByName('AQ_9')[0].checked == false && document.getElementsByName('AQ_9')[1].checked == false && document.getElementsByName('AQ_9')[2].checked == false
            && document.getElementsByName('AQ_9')[3].checked == false && document.getElementsByName('AQ_9')[4].checked == false && document.getElementsByName('AQ_9')[5].checked == false) {
            $('#toastbody').text('9번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_9')[0].focus();
        }
        else if (document.getElementsByName('AQ_10')[0].checked == false && document.getElementsByName('AQ_10')[1].checked == false && document.getElementsByName('AQ_10')[2].checked == false
            && document.getElementsByName('AQ_10')[3].checked == false && document.getElementsByName('AQ_10')[4].checked == false && document.getElementsByName('AQ_10')[5].checked == false) {
            $('#toastbody').text('10번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_10')[0].focus();
        }
        else if (document.getElementsByName('AQ_11')[0].checked == false && document.getElementsByName('AQ_11')[1].checked == false && document.getElementsByName('AQ_11')[2].checked == false
            && document.getElementsByName('AQ_11')[3].checked == false && document.getElementsByName('AQ_11')[4].checked == false && document.getElementsByName('AQ_11')[5].checked == false) {
            $('#toastbody').text('11번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_11')[0].focus();
        }
        else if (document.getElementsByName('AQ_12')[0].checked == false && document.getElementsByName('AQ_12')[1].checked == false && document.getElementsByName('AQ_12')[2].checked == false
            && document.getElementsByName('AQ_12')[3].checked == false && document.getElementsByName('AQ_12')[4].checked == false && document.getElementsByName('AQ_12')[5].checked == false) {
            $('#toastbody').text('12번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_12')[0].focus();
        }
        else if (document.getElementsByName('AQ_13')[0].checked == false && document.getElementsByName('AQ_13')[1].checked == false && document.getElementsByName('AQ_13')[2].checked == false
            && document.getElementsByName('AQ_13')[3].checked == false && document.getElementsByName('AQ_13')[4].checked == false && document.getElementsByName('AQ_13')[5].checked == false) {
            $('#toastbody').text('13번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_13')[0].focus();
        }
        else if (document.getElementsByName('AQ_14')[0].checked == false && document.getElementsByName('AQ_14')[1].checked == false && document.getElementsByName('AQ_14')[2].checked == false
            && document.getElementsByName('AQ_14')[3].checked == false && document.getElementsByName('AQ_14')[4].checked == false && document.getElementsByName('AQ_14')[5].checked == false) {
            $('#toastbody').text('14번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_14')[0].focus();
        }
        else if (document.getElementsByName('AQ_15')[0].checked == false && document.getElementsByName('AQ_15')[1].checked == false && document.getElementsByName('AQ_15')[2].checked == false
            && document.getElementsByName('AQ_15')[3].checked == false && document.getElementsByName('AQ_15')[4].checked == false && document.getElementsByName('AQ_15')[5].checked == false) {
            $('#toastbody').text('15번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_15')[0].focus();
        }
        else if (document.getElementsByName('AQ_16')[0].checked == false && document.getElementsByName('AQ_16')[1].checked == false && document.getElementsByName('AQ_16')[2].checked == false
            && document.getElementsByName('AQ_16')[3].checked == false && document.getElementsByName('AQ_16')[4].checked == false && document.getElementsByName('AQ_16')[5].checked == false) {
            $('#toastbody').text('16번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_16')[0].focus();
        }
        else if (document.getElementsByName('AQ_17')[0].checked == false && document.getElementsByName('AQ_17')[1].checked == false && document.getElementsByName('AQ_17')[2].checked == false
            && document.getElementsByName('AQ_17')[3].checked == false && document.getElementsByName('AQ_17')[4].checked == false && document.getElementsByName('AQ_17')[5].checked == false) {
            $('#toastbody').text('17번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_17')[0].focus();
        }
        else if (document.getElementsByName('AQ_18')[0].checked == false && document.getElementsByName('AQ_18')[1].checked == false && document.getElementsByName('AQ_18')[2].checked == false
            && document.getElementsByName('AQ_18')[3].checked == false && document.getElementsByName('AQ_18')[4].checked == false && document.getElementsByName('AQ_18')[5].checked == false) {
            $('#toastbody').text('18번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_18')[0].focus();
        }
        else if (document.getElementsByName('AQ_19')[0].checked == false && document.getElementsByName('AQ_19')[1].checked == false && document.getElementsByName('AQ_19')[2].checked == false
            && document.getElementsByName('AQ_19')[3].checked == false && document.getElementsByName('AQ_19')[4].checked == false && document.getElementsByName('AQ_19')[5].checked == false) {
            $('#toastbody').text('19번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_19')[0].focus();
        }
        else if (document.getElementsByName('AQ_20')[0].checked == false && document.getElementsByName('AQ_20')[1].checked == false && document.getElementsByName('AQ_20')[2].checked == false
            && document.getElementsByName('AQ_20')[3].checked == false && document.getElementsByName('AQ_20')[4].checked == false && document.getElementsByName('AQ_20')[5].checked == false) {
            $('#toastbody').text('20번문제에 체크해주세요.');
            $('.toast').toast('show');
            document.getElementsByName('AQ_20')[0].focus();
        }
        else
            return true;

        $("#response").animate({
            height: '+=72px'
        }, 300);
        $('<div class="alert alert-danger">' +
            '<button type="button" class="close" data-dismiss="alert">' +
            '&times;</button>모든항목에 체크하세요!</div>').hide().appendTo('#response').fadeIn(1000);
        $(".alert").delay(3000).fadeOut(
            "normal",
            function () {
                $(this).remove();
            });

        $("#response").delay(4000).animate({
            height: '-=72px'
        }, 300);



    }
});



