var studentData = null;
$(function () {
    
    GetSummary();
    $("#dowloadCSVBtn").click(function () {
        createCSV(studentData);
    });
});

function createCSV(studentList) {
    if (studentList != null) {
        var listApproved = [];
        var listRejected = [];
        var listWaiting = [];

        for (var i = 0; i < studentList.length; i++) {

            console.log(studentList.length);
            if (studentList[i].StudentStatus == "Waiting")
            {
                listWaiting.push(studentList[i].FirstName + " " + studentList[i].LastName);
            }
            if (studentList[i].StudentStatus == "Approved")
            {
                listApproved.push(studentList[i].FirstName + " " + studentList[i].LastName);
            }
            if (studentList[i].StudentStatus == "Rejected")
            {
                listRejected.push(studentList[i].FirstName +" " +studentList[i].LastName);
            }
        }


        var headers = "Approved, Rejected, Waiting\n";
        var data = "";
        var maxLength = listApproved.length;
        if (listRejected.length > maxLength)
            maxLength = listRejected.length;
        if (listWaiting > maxLength)
            maxLength = listWaiting.length;

        for (var index = 0; index < maxLength; index++) {
            if (listApproved.length > index) {
                data += listApproved[index];
            }
            data += ',';
            if (listRejected.length > index) {
                data += listRejected[index];
            }
            data += ',';
            if (listWaiting.length > index) {
                data += listWaiting[index];
            }
            data += ',\n';

        }

        var csv2 = headers;
        csv2 += data;
        var hiddenElement = document.createElement('a');
        hiddenElement.href = 'data:text/csv;charset=utf-8,' + encodeURI(csv2);
        hiddenElement.target = '_blank';
        hiddenElement.download = 'StudentSummary.csv';
        hiddenElement.click();

    }
}

function GetSummary() {

    getData().then((response) => {
        if (response) {
            studentData = response;
            console.log(response);
            summaryTable(response);
            
        }

    }).catch((error) => {
        console.error(error);
        toastr.error('');
    });
}


function getData() {

    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: "/Admin/GetStudentInfo",
            data: null,
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
function summaryTable(studentSummary) {
    var table = $("table#studentInfoTable");
    var tbody = "";
    if (studentSummary) {
        for (var indexStudent = 0; indexStudent < studentSummary.length; indexStudent++) {

            tbody += `<tr>
                           
                            <td>${studentSummary[indexStudent].StudentId}</td>
                            <td>${studentSummary[indexStudent].FirstName}</td>
                            <td>${studentSummary[indexStudent].LastName}</td>
                            <td>${studentSummary[indexStudent].TotalPoints}</td>
                            <td>${studentSummary[indexStudent].StudentStatus}</td>
                            </tr>`;

        }
    }
    else {
        tbody = "<tr colspan='7'>No students found</tr>";
    }
    table.append(tbody);
}

