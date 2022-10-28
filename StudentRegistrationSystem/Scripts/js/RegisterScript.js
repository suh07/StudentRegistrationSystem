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

   
    // create object to map usermodel
    var userObj = {
        FirstName: firstname, LastName: lastname, NID: NID, UserAddress: address, GuardianName: guardian, PhoneNumber: phone, 
        DateOfBirth: date ,EmailAdress: email, Password : password
    };

    sendData(userObj).then((response) => {
        if (response.result) {
            toastr.success("Authentication Succeed. Redirecting to relevent page.....");
            window.location = response.url;
        }
        else {
            toastr.error('Unable to Register user');
            return false;
        }
    })
        .catch((error) => {
            toastr.error('Unable to make request!!');
        });
        
    }
    


function sendData(userObj) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "Reg/CreateUser",
            data: userObj,
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