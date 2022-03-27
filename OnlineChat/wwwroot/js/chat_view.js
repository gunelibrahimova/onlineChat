$(".side-user").on('click', function () {
    userId = $(this).attr("id");
    $(".chat-header ").css("display", "block");
    $(".chat-history ").css("display", "block");
    $(".chat-message ").css("display", "flex");
    var name = $(this).children().eq(1).children().eq(0).text();
    $('.chat-with').text(name);
    $('#chat-list').html('');

    $.ajax({
        type: 'GET',
        url: '/Home/GetMyMessages',
        data: {
            otherId: userId
        },
        success: function (response) {
            console.log(response)
            response.forEach(function (e) {
                if (e['senderId'] == userId) {
                    $('#chat-list').append(`
                        <li>
                            <div class="message my-message">
                              `+ e['messages'] + `
                            </div>
                        </li>
                    `);
                } else {
                    $('#chat-list').append(`
                        <li class="clearfix">
                            <div class="message other-message float-right">
                                `+ e['messages'] + `
                            </div>
                        </li>
                    `);
                }
            });
            scrollToBottom();

        }
    });
})