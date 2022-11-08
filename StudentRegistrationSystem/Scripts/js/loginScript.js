$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

function signIn() {
    var emailAddress = $("#emailAddress").val(); // read email address input
    var password = $("#password").val(); // read password input
    // create object to map LoginModel
    var authObj = { EmailAddress: emailAddress, UserPassword: password };
 
    sendData(authObj).then((response) => {
        if (response.result) {
            toastr.success("Authentication Succeed. Redirecting to relevent page.....");
           window.location = response.url;
        }
        else {
            toastr.error('Email Address or Password invalid');
            return false;
        }
    })
        .catch((error) => {
            toastr.error('Unable to make request!!');
        });
}
function sendData(dataObj) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "Login/Auth",
            data: dataObj,
            dataType: "json",
            success: function (result) {
                resolve(result)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}