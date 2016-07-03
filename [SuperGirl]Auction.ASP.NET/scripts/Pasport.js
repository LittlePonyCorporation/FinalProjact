/// <reference path="jquery-2.2.3.min.js" />
/// <reference path="jquery-2.2.3.intellisense.js" />
var $NewLot = $('.NewLot'),
    $name = $('.name'),
    $description = $('.description'),
    $button = $('.butadd'),
    $id = $('.id');

$button.click(function () {
    $.ajax({
        url: '/Pages/User/NewLot',
        type: 'post',
        data: {
            name: $name.val(),
            description: $description.val(),
            id: $id.val()
        }
    })
    .success(function (data) {
        $NewLot.empty();
        $NewLot.append(data);
    });
});