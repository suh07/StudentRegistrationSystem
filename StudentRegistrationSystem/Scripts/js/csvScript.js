$(function () {
    getCsv();
});

function getCsv() {
    var studData = null;
    getData().then((response) => {
        studData = response;
        createCSV(response);
    }).catch((error) => {
        console.log(error);
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

