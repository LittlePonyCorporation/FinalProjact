/// <reference path="jquery-2.2.3.min.js" />
/// <reference path="jquery-2.2.3.intellisense.js" />
var $lodId = $('.lodId').val(),
    $youId = $('.youId').val(),
    $button = $('.button-buy'),
    $buy = $('.buy'),
    $lotId = $('.lotId').val(),
    $uId = $('.uId').val(),
    $butNewBuy = $('.button-new-buy'),
    $newbuy = $('.new-buy');

$button.click(function () {
    $.ajax({
        url: '/Pages/Buy',
        type: 'post',
        data: {
            lodId: $lodId,
            youId: $youId
        }
    })
    .success(function(data) {
        $buy.empty();
        $buy.append(data);
    });
});

$butNewBuy.click(function () {
    $.ajax({
        url: '/Pages/NewBuy',
        type: 'post',
        data: {
            lotId: $lotId,
            userId: $uId
        }
    })
    .success(function (data) {
        $newbuy.empty();
        $newbuy.append(data);
    });
});