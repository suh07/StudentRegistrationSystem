$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});
function register() {
    var firstname = $("#firstname").val(); 
    var lastname = $("#lastname").val();   
    var NationalId = $("#NationalId").val(); 
    var address = $("#address").val();
    var phoneNumber = $("#phoneNumber").val(); 
    var guardianName = $("#guardianName").val(); 
    var dateOfBirth = $("#dateOfBirth").val();
    var emailAddress = $("#emailAddress").val(); 
    var password = $("#password").val();  
    var password2 = $("#password2").val();  

    if (password != password2) {
        toastr.error('Password do not match');
        return false;
    }
    var userObj = {
        FirstName: firstname, LastName: lastname, NationalId: NationalId, StudentAddress: address, GuardianName: guardianName, PhoneNumber: phoneNumber, 
        DateOfBirth: dateOfBirth ,EmailAddress: emailAddress, UserPassword : password
    };

    sendData(userObj).then((response) => {
        if (response.result) {
            toastr.success("Successfully registered");
            window.location = response.url;
        }
        else {
            toastr.error("Please provide appropriate credentials");
         
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
            url: "/Registration/AddUser",
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