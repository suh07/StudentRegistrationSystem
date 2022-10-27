$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});


function register() {
    var firstname = $("#name").val(); 
    var lastname = $("#lastname").val();   
    var NID = $("#NID").val(); 
    var address = $("#address").val();
    var phone = $("#phone").val(); 
    var guardian = $("#guardian").val(); 
    var email = $("#email").val(); 
    var password = $("#password").val();  
    var date = $("#date").val();

    var errorMessages = [];
    // create object to map usermodel
    var userObj = {
        FirstName: firstname, LastName: lastname, NID: NID, UserAddress: address, GuardianName: guardian, PhoneNumber: phone, 
        DateOfBirth: date ,EmailAdress: email, Password : password
    };

    if (errorMessages.length == 0) {
        sendData(usertObj).then((response) => {
            if (response.result) {
                toastr.success("Authentication Succeed. Redirecting to relevent page.....");
                setTimeout(redirect, 3000);
                

            }
            else {
                toastr.error('Unable to Register user');
                return false;
            }
        })
            .catch((error) => {
                toastr.error('Unable to make request!!');
            });
    } else {
        for (var i = 0; i < errorMessages.length; i++) {
            toastr.error(errorMessages[i]);
        }
        
    }
    
}

function sendData(user) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/RegController/CreateStudent",
            data: user,
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

function redirect() {
    window.location.href = "/Logins/Index";
}