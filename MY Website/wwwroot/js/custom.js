$(document).ready(function () {
    showUserdata();
})

function showUserdata() {
    debugger 
    $.ajax({
        url: '/Ajax/UserList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td width="25%">' + item.id + '</td>';
                object += '<td>' + item.name + '</td>';
                object += '<td>' + item.email + '</td>';
                object += '<td>' + item.isActive + '</td>';
                object += '<td><a href="#" class="btn btn-dark">Edit</a><a href="#" class="btn btn-outline-sm px-2 ms-2">Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data Can't Get");
        }
    });
};