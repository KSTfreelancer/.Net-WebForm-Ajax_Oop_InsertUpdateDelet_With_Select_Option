$(document).ready(function () {
    $("#update").hide();
    $("#delete").hide();
    DepatmentShow();
    /*SubjecttShow();*/
    SemisterShow();
    DatatableShow();
});
function clrarInput() {
    myAutoId = 0;
    $("#name").val("");
    $("#roll").val("");
    $("#reg").val("");
    $("#dpt ").val("-1");
    $("#sub ").val("-1");
    $("#semisterShow ").val("-1");
    $("#sift ").val("-1");
    $("#admission").val("");
    $("#farewell").val("");
    $("#update").hide();
    $("#delete").hide();
    $("#insert").show();
}
/*var auroRowId = 0;*/
var autoRowId = 1;
var myAutoId = 0;
function InsertStudent() {

    var InsertObject = {
        AutoId: autoRowId,
        Roll: parseInt($("#roll").val()),
        RegNo: parseInt($("#reg").val()),
        Name: $("#name").val(),
        Department: $("#dpt option:selected").text(),
        Subject: $("#sub option:selected").text(),
        Semister: $("#semisterShow option:selected").text(),
        Shift: $("#sift").val(),
        Admission: $("#admission").val(),
        Farewell: $("#farewell").val()
    }

    $.ajax({
        url: "StudentUI.aspx/SaveStudent",
        data: JSON.stringify({ InsertObject: InsertObject }),
        type: "POST",
        dataType: "Json",
        contentType: "application/json; charset=utf-8",


        success: function (data) {
            alert(data.d);
            clrarInput();
            DatatableShow();
            SemisterShow();
        },

        error: function () {
            alert("Error")
        }
    })


}

function DatatableShow() {
    $.ajax({
        url: "StudentUI.aspx/DataTablrShow",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var tableData = "";
            var SL = 1;
            if (data.d.length > 0) {
                $.each(data.d, function (key, value) {
                    tableData += "<tr class='rowItemListRow'id=raw_" + autoRowId + ">";
                    tableData += "<th class='SL'>" + SL + "</th>";
                    tableData += "<td class='id d-none'>" + value.AutoId + "</td>";
                    tableData += "<td class='Name'>" + value.Name + "</td>";
                    tableData += "<td class='Roll'>" + value.Roll + "</td>";
                    tableData += "<td class='RegNo '>" + value.RegNo + "</td>";
                    tableData += "<td class='Department'>" + value.Department + "</td>";
                    /*tableData += "<td class='dptID d-none'>" + value.DptOId + "</td>";*/
                    tableData += "<td class='Subject '>" + value.Subject + "</td>";
                    tableData += "<td class='Semister '>" + value.Semister + "</td>";
                    tableData += "<td class='Shift '>" + value.Shift + "</td>";
                    tableData += "<td class='Admission '>" + value.Admission + "</td>";
                    tableData += "<td class='Farewell '>" + value.Farewell + "</td>";
                    tableData += "<td class='text-end'><button type='button' class='btn btn-info btn-sm' onclick='Edit(" + autoRowId + ")'>Edit</button></td>";
                    tableData += "</tr>";
                    SL++;
                    autoRowId++;
                });
            }

            $("#tabelBodyGenerate").empty();
            $("#tabelBodyGenerate").append(tableData);
        },
        error: function (ex) {
            alert("There are no supplier");
        }
    });
}
//Edit
function Edit(id) {
   
    myAutoId = $("#raw_" + id).find("td.id").text();
   
    //==============================================
    var dptId = $("#raw_" + id).find("td.Department").text();  
    if (dptId == "Computer") {dptId = 1;}
    else if (dptId == "Electrical") {dptId = 2;}
    else if (dptId == "Electronics") {dptId = 3; }
    //==============================================
    var sbjId = $("#raw_" + id).find("td.Subject").text();
    if (sbjId == "C++") {sbjId = 1;}
    else if (sbjId == "C#") {sbjId = 2;}
    else if (sbjId == "Java") {sbjId = 3;}
    else if (sbjId == "Web Development") { sbjId = 4;}
    else if (sbjId == "Python") {sbjId = 5;}
    else if (sbjId == "Electrical ControlsLearn ") {sbjId = 6;}
    else if (sbjId == "Drive PowerFlex ") {sbjId = 7;}
    else if (sbjId == "Electrical machines|AC/DC ") {sbjId = 8;}
    else if (sbjId == "Power System Simulations") {sbjId = 9;}
    else if (sbjId == "Electronics - A Beginners Guide") {sbjId = 10;}
    else if (sbjId == "Electronics and PCB Design") {sbjId = 11;}
    else if (sbjId == "Electricity & electronics - Robotics") {sbjId = 12;}
    else if (sbjId == "Electronics for Arduino Makers") {sbjId = 17;}

    //==============================================
    $("#name").val($("#raw_" + id).find("td.Name").text());
    $("#roll").val($("#raw_" + id).find("td.Roll").text());
    $("#reg").val($("#raw_" + id).find("td.RegNo").text());
    $("#dpt").val(dptId);
    SubjecttShow(sbjId);
    /*SubjecttShow();*/
    /*$("#sub").val(sbjId);*/
    /*$("#sub ").val(sbjId);*/
    $("#semisterShow").val($("#raw_" + id).find("td.Semister").text());
    $("#sift").val($("#raw_" + id).find("td.Shift").text());
    $("#admission").val($("#raw_" + id).find("td.Admission").text());
    $("#farewell").val($("#raw_" + id).find("td.Farewell").text());



    

    
    

    $("#insert").hide();
    $("#update").show();
    $("#delete").show();
}
function SelectSubjectForUpdate(sbjId) {
    $("#sub").val(sbjId);
}

//Edit
//Upadate
function UpdateStudent() {
    var InsertObject = {
        AutoId: parseInt(myAutoId),
        Roll: parseInt($("#roll").val()),
        RegNo: parseInt($("#reg").val()),
        Name: $("#name").val(),
        Department: $("#dpt option:selected").text(),
        Subject: $("#sub option:selected").text(),
        Semister: $("#semisterShow option:selected").text(),
        Shift: $("#sift").val(),
        Admission: $("#admission").val(),
        Farewell: $("#farewell").val()
    }
    $.ajax({
        url: "StudentUI.aspx/UpdateStudent",
        data: JSON.stringify({ aStudent: InsertObject }),
        type: "POST",
        dataType: "Json",
        contentType: "application/json; charset=utf-8",


        success: function (data) {
            alert(data.d);
            clrarInput();
            DatatableShow();;
        },

        error: function () {
            alert("Data Not Update")
        }
    })
}
//Delet
function DeleteStudent() {
    var x = confirm("Are you sure to delete ?");
    if (x == true) {
        var InsertObject = {
            AutoId: parseInt(myAutoId)
        }
        $.ajax({
            url: "StudentUI.aspx/DeleteStudent",
            data: JSON.stringify({ aStudent: InsertObject }),
            type: "POST",
            dataType: "Json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                alert(data.d);
                clrarInput();
                DatatableShow();
            },
            error: function () {
                alert("Data Not Delete")
            }
        })
    }
}
//DropDownShift

function SemisterShow() {
    $.ajax({
        url: "StudentUI.aspx/Semister",
        data: JSON.stringify({}),
        type: "POST",
        dataType: "Json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var option = "";
            if (data.d.length > 1) {
                option += "<option value='-1'>--Select Semisters--</option>";
            }

            $.each(data.d, function (key, value) {
                option += "<option value='" + value.Semister + "'>" + value.Semister + "</option>";
            });

            $("#semisterShow").empty();
            $("#semisterShow").append(option);
        },
        error: function () {
            alert("OPtions not Selected")
        }
    });
}
//DropDownDepartment

function DepatmentShow() {
    $.ajax({
        url: "StudentUI.aspx/Depatment",
        data: JSON.stringify({}),
        type: "POST",
        dataType: "Json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
            $("#dpt").empty();
            $("#dpt").append("<option value='-1'>--Select Department--</option>");
            if (data.d.length > 0) {
                $.each(data.d, function (key, value) {
                    $("#dpt").append($("<option></option>").val(value.AutoId).html(value.Department));
                });
            };
        },
        error: function () {
            alert("OPtions not Selected")
        }
    });
}
//DropDownSubject

function SubjecttShow(sbjId) {
    var InsertObject = {
        AutoId: parseInt($("#dpt").val())
    }
    $.ajax({
        url: "StudentUI.aspx/Subject",
        data: JSON.stringify({ aSubject : InsertObject }),
        type: "POST",
        dataType: "Json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#sub").empty();
            $("#sub").append("<option value='-1'>--Select Subject--</option>");
            if (data.d.length > 0) {
                $.each(data.d, function (key, value) {
                    $("#sub").append($("<option></option>").val(value.AutoId).html(value.Subject));
                });
            };

            if (sbjId!=0) {
                SelectSubjectForUpdate(sbjId);
            }
        },
        error: function () {
            alert("OPtions not Selected")
        }
    });
}











//$("#semisterShow").empty();
///*$("#semisterShow").append("<option value='-1'>--Select--</option>");*/
///* if (data.d.length > 0) {*/
//$.each(data.d, function (key, value) {
//    $("#semisterShow").append($("<option></option>").val(value.AutoId).html(value.Semister));
//});


