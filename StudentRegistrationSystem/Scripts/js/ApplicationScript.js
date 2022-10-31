$("#submit").click(function()
{
    var resultList = [];
    
    var subjectValue = $('.subject1Name' +' :selected').val();
    var gradeValue = $('.subject1Grade' + ' :selected').val();
        const result1 = { SubjectId: subjectValue, Grade: gradeValue };
    resultList.push(result1);

    var subjectValue = $('.subject2Name' + ' :selected').val();
    var gradeValue = $('.subject2Grade' + ' :selected').val();
    const result2 = { SubjectId: subjectValue, Grade: gradeValue };
    resultList.push(result2);

    var subjectValue = $('.subject3Name' + ' :selected').val();
    var gradeValue = $('.subject3Grade' + ' :selected').val();
    const result3 = { SubjectId: subjectValue, Grade: gradeValue };
    resultList.push(result3);


   
    CreateResult({ results: resultList }).then((response) => {
        if (response.result) {
            toastr.success('Result Created Successfully')
        }
        else {
            toastr.error('Unable to create result');
            return false;
        }
    }).catch((error) => {
        toastr.error('Unable to create result!');
        console.error(error);
    });



});


function CreateResult(resultList) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Application/AddResult",
            data: resultList,
            dataType: 'json',
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}