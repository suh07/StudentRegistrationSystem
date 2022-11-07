function EmailValidation(element) {
    var emailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (element.value.length == 0) {
        toastr.error("Email must be specified");
    }
    else if (element.value.length < 8 || element.value.length > 50) {
        toastr.error("Email must be between 8 to 50 characters");
    }
    else if (!emailRegex.test(element)) {
        toastr.error("Email is in Invalid Format");
    }
}
function PasswordValidation(element) {
    if (element.value.length < 8 || element.value.length > 25) {
        toastr.error("password must be specified");
    }
}
function NameValidation(element) {
    if (element.value.length < 2 || element.value.length > 100) {
        var attributeName = element.getAttribute("name");
        element.value = "";
        toastr.error("Name Should be between 2 and 100 characters");
    }
}
function NationalIdValidation(element) {
    var minLength = 9;
    var maxLength = 15;
    var NIDRegexCharacter = /^[a-zA-Z0-9]*$/;
    if (element.value.length < minLength || element.value.length > maxLength) {
        toastr.error("National Id should be between 9 and 15 characters");
    }
    if (!NIDRegexCharacter.test(element.value)) {
        toastr.error("National Id should be between 9 and 15 characters");
    }
}
function AddressValidation(element) {
    if ((element.value.length) < 2 || element.value.length > 30) {
        toastr.error("Address should be between 2 and 15 characters");
    }
}