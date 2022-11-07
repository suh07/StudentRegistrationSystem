window.onload = function () {
    DisplayStudentInfo().then((response) => {
        var table = document.getElementById('studentInfoTable');
        for (var i = 0; i < response.length; i++) {
            var tr = document.createElement('tr');
            var data = response[i];
            var dateFormat = new Date(parseInt(data.DateOfBirth.substr(6)))



            var td = document.createElement('td');
            td.innerHTML = data.StudentId;
            tr.appendChild(td);


            var td = document.createElement('td');
            td.innerHTML = data.FirstName;
            tr.appendChild(td);



            var td = document.createElement('td');
            td.innerHTML = data.LastName;
            tr.appendChild(td);



            var td = document.createElement('td');
            td.innerHTML = data.EmailAddress;
            tr.appendChild(td);


            var td = document.createElement('td');
            td.innerHTML = data.TotalMark;
            tr.appendChild(td);



            table.appendChild(tr);
        }
    })
        .catch((error) => {
            toastr.error('Unable to make request!!');
        });
};




function DisplayStudentInfo() {
    return fetch("/Admin/GetStudentInfo", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
    })
        .then(response => { return response.json(); })
        .catch((error) => console.log(error))
}
