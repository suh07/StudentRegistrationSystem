
$(function () {
    GetSummary();
});

function GetSummary() {

    getData().then((response) => {
        if (response) {
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

