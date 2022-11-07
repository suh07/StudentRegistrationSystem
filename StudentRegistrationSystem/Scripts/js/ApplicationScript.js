
$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

function registerResult() { 
    var resultList = [];
    var gradeScore;

    for (let turn = 1; turn < 4; turn++) {
        var subjectValue = parseInt($("#subject"+turn+"Name").val());
        var gradeValue = $("#subject" + turn + "Grade").val();
        if (gradeValue == "A") {
            gradeScore = 10;
        }
         else if (gradeValue == "B") {
            gradeScore = 8;
        }
        else if (gradeValue == "C") {
            gradeScore = 6;
        }
        else if (gradeValue == "D") {
            gradeScore = 4;
        }
        else if (gradeValue == "E") {
            gradeScore = 2;
        }
        else if (gradeValue == "F") {
            gradeScore = 0;
        }

        const result = { SubjectId: subjectValue, SubjectGrade: gradeValue, GradeScore: gradeScore };
        resultList.push(result);
    }

    var testSub1 = parseInt($("#subject1Name").val());
    var testSub2 = parseInt($("#subject2Name").val());
    var testSub3 = parseInt($("#subject3Name").val());

    if (testSub1 == testSub2 || testSub1 == testSub3 || testSub2 == testSub3) {
        toastr.error('Duplicate Subject have been entered');
    }; 

    var data = { Results: resultList };

    CreateResult(data).then((response) => {
        if (response.result) {
            toastr.success('Result Created Successfully');
            window.location = response.url;
            
        }
        else {
            toastr.error('Unable to create result');
            return false;
        }
    }).catch((error) => {
        toastr.error('Unable to create result!');
        console.error(error);
    });
};


function CreateResult(resultList) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Application/AddStudentResult",
            data: JSON.stringify(resultList),
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}