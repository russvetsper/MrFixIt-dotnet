var test = "it works";



    $(document).ready(function () {
        $('.Claim This Job').click(function () {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                url: '/Claim/Job'
                success: function (model) {
                    var resultString = '<br>Title: ' + model.title + '<br>Description: ' + model.description;
                    $('#result1').html(resultString);
                }
            });
        });
    
