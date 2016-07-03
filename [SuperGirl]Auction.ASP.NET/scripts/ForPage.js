/// <reference path="jquery-2.2.3.min.js" />
/// <reference path="jquery-2.2.3.intellisense.js" />
var $search = $('.search'),
    $battonOk = $('.button-search'),
    $result = $('.main-content'),
    $login = $('.login');

$battonOk.click(function () {
    $.ajax({
        url: '/Pages/Search',
        type: 'post',
        data: {
            search: $search.val()
        }
    })
        .success(function (data) {
            $result.empty();
       $result.append(data);
   });
});

$login.click(function() {
    $.ajax({
        url: '/Pages/Login',
        type: 'get',
    })
    .success(function(data) {
        $result.empty();
        $result.append(data);
    });
});