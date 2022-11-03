function EmailValidation(element) {
    var emailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (element.value.length == 0) {
        //errorMessages.push("Email must be specified");
        toastr.error("Email must be specified");
    }
    else if (element.value.length < 8 || element.value.length > 50) {
        //.push("Email must be between 8 to 50 characters");
        element.value = "";
        toastr.error("Email must be specified");
    }
    else if (!emailRegex.test(element)) {
        //errorMessages.push("Email is in Invalid Format");
        element.value = "";
        toastr.error("Email must be specified");
    }
}



function PasswordValidation(element) {
    if (element.value.length < 8 || element.value.length > 25) {
        //errorMessages.push("Password should be between 8 to 25 characters");
        toastr.error("password must be specified");
        element.value = "";

    }
}



function NameValidation(element) {
    if (element.value.length < 2 || element.value.length > 100) {
        var attributeName = element.getAttribute("name");
        //errorMessages.push("Password should be between 8 to 25 characters");
        //toastr.error("Incorrect " + attributeName + " length");
        element.value = "";
        toastr.error("Should be between 2 and 100 characters");
    }
}



function NationalIdValidation(element) {
    var minLength = 9;
    var maxLength = 15;
    var NIDRegexCharacter = /^[a-zA-Z0-9]*$/;
    if (element.value.length < minLength || element.value.length > maxLength) {



        //errorMessages.push("Incorrect NationalID length");





        toastr.error("National Id should be between 9 and 15 characters");
        element.value = "";
    }
    if (!NIDRegexCharacter.test(element.value)) {
        //errorMessages.push("Incorrect NationalID length");



        toastr.error("National Id should be between 9 and 15 characters");

        element.value = "";
    }
}



function AddressValidation(element) {
    if ((element.value.length) < 2 || element.value.length > 30) {
        // errorMessages.push("should be between 2 and 30 characters");
        toastr.error("should be between 2 and 15 characters");
        element.value = "";
    }
}