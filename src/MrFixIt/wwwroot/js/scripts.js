var test = "it works";



$(function () {

    //claim a job
    $(".claimjob").click(function () {
        // alert("clicked");
        var jobid = $(this).siblings('.ThisJobId').val();
        var username = $('.ThisUserName-' + jobid).val();
        $(".HideBtn-" + jobid).hide();

        $.ajax({
            url: "/Jobs/Claim",
            data: { jobId: jobid, userName: username },
            type: 'GET',
            success: function (result) {
                $('.ClaimedJob-' + jobid).html(result);
            }
        });
    });
});