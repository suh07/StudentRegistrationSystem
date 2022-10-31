$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});



function Register() {
    var emailAddress = $("#emailAddress").val(); // read email address input
    var password = $("#password").val(); // read password input
    var password2 = $("#password2").val();




    if (password != password2) {
        toastr.error('Password do not match');
        return false;
    }



    // create object to map LoginModel
    var authObj = { Email: emailAddress, Password: password };
    // alert(emailAddress);



    sendData(authObj).then((response) => {
        //alert(response.result);
        if (response.result) {
            toastr.success("Successfully registered");
            //window.location.href = response.url;
        }
        else {
            toastr.error("Please provide appropriate credentials");
            //alert("Incorrect credentials");
        }
    })
        .catch((error) => {
            toastr.error("Something went wrong, Please try again!");
        });
}



function sendData(userCredential) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Registrations/AddUser",
            data: userCredential,
            dataType: "json",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}