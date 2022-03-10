// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getBlog(id) {
    window.location.href = '/Blog/GetBlog/' + id;
}

function logout(event) {
    if (event.target.value == "logout") {
        window.location.href = `/Account/Logout`;
    }
 //   
}

function Comment(){
    var cmt = document.getElementById("cmt-text").value;
    
}