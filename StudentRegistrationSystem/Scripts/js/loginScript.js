$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

/*
function register() {
    toastr.info('Page Under construction!!');
}
*/

function signIn() {
    var emailAddress = $("#emailAddress").val(); // read email address input
    var password = $("#password").val(); // read password input
    // create object to map LoginModel
    var authObj = { EmailAddress: emailAddress, Password: password };

    
    sendData(authObj).then((response) => {
        if (response.result) {
            toastr.success("Authentication Succeed. Redirecting to relevent page.....");
           window.location = response.url;
        }
        else {
            toastr.error('Unable to Authenticate user');
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
            url: "Logins/Auth",
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