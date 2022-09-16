//this ajax code to prevent refreshing the page each time you click on "next" or "previous page"

$

    (function () {

    $('#mainContent').on('click', '.pager a', function () {
        var url = $(this).attr('href');

        $('#mainContent').load(url);

        return false;
    })

});