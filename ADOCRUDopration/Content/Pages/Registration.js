$(document).ready(function () {
    getlist();
    GetState();
});

var GetState = function () {
    debugger
    $.ajax({
        type: "Post",
        url: "/Registration/GetState",
        data: "{}",
        contentType: "application/json;chrset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '<option value=1>---Please Select --</option>';
            for (var i = 0; i < data.length; i++) {
                html += '<option value="' + data[i].StateId + '">' + data[i].StateName + '</option>';
            }
            $("#ddlState").html(html);
        },
        error: function (response) {
            alert(response.d);
        }
    });
}
function DDLStateCityChange() {
    CityData();
}
var CityData = function () {
    debugger
    $.ajax({
        type: "POST",
        url: "/Registration/GetCity?StateId=" + $("#ddlState").val(),
        data: '{}',
        contentType: "application/json;chrset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '<option value="-1">---please select---</option>';
            for (var i = 0; i < data.length; i++) {
                html += '<option value="' + data[i].CityId + '">' + data[i].CityName + '</option>';
            }
            $("#ddlCity").html(html);
            debugger;

        },
        error: function (response) {
            alert(response.d);
        }
    });

}

var SaveReg = function () {
    debugger;

    //if ($("#txtName").val() == "") {
    //    alert("Please Enter Your Name")
    //    $("#txtName").focus();
    //    return false;
    //}

    //else if ($("#txtAddress").val() == "") {
    //    alert("Please Enter Your Address")
    //    $("#txtAddress").focus();
    //    return false;
    //}

    //else if ($("#txtEmail").val() == "") {
    //    alert("Please Enter Your Email")
    //    $("#txtEmail").focus();
    //    return false;
    //}

    //else if ($("#txtGender").val() == "") {
    //    alert("Please Enter Your Gender")
    //    $("#txtGender").focus();
    //    return false;
    //}

    //else if ($("#ddlState").val() == "") {
    //    alert("Please Enter Your State")
    //    $("#ddlState").focus();
    //    return false;
    //}

    //else if ($("#ddlCity").val() == "") {
    //    alert("Please Enter Your City")
    //    $("#ddlCity").focus();
    //    return false;
    //}

    //else if ($("#txtPincode").val() == "") {
    //    alert("Please Enter Your Pincode")
    //    $("#txtPincode").focus();
    //    return false;
    //}

    var model = {
        Id: $("#hdnid").val(),
        Name: $("#txtname").val(),
        Gender: $("#txtgender").val(),
        MobileNo: $("#txtmobile").val(),
        Address: $("#txtaddress").val(),
        City: $("#ddlCity").val(),
        State: $("#ddlState").val(),
        Pincode: $("#txtpincode").val(),
        Email: $("#txtemail").val(),
        PassWord: $("#txtpass").val(),
        Hobbies: $("#txthobbies").val(),
    };
    $.ajax({

        url: "/Registration/SaveReg",
        type: "Post",
        dataType: "json",
        data: JSON.stringify(model),
        contentType: "application/json;chrset=utf-8",
        success: function () {
            alert("Data Save Successfully...");
            ClearData();
            getlist();
            
        }
    });
}

var getlist = function () {
    debugger;
    $.ajax({
        url: "/Registration/GetReg",
        type: "Post",
        data: '{}',
        contentType: "application/json;chrset=utf-8",
        dataType: "JSON",
        success: function (response) {
            var html = "";
            $.each(response, function (index, elementValue) {
                html += "<tr><td>" +
                    elementValue.Id + "</td><td>" +
                    elementValue.Name + "</td><td>" +
                    elementValue.Gender + "</td><td>" +
                    elementValue.MobileNo + "</td><td>" +
                    elementValue.Address + "</td><td>" +
                    elementValue.CityName + "</td><td>" +
                    elementValue.StateName + "</td><td>" +
                    elementValue.Pincode + "</td><td>" +
                    elementValue.Email + "</td><td>" +
                    elementValue.PassWord + "</td><td>" +
                    elementValue.Hobbies + "</td><td><input type='button' value='Delete' onclick= 'deleteReg(" + elementValue.Id + ")'/><input type='button' value='Edit' onclick= 'EditReg(" + elementValue.Id + ")'/></td></tr>";

            });

            $("#regid tbody").append(html);

            alert("Didplay Sucessfully");
        },
        error: function (response) {
            alert(response);
        }
    });

};

var deleteReg = function (id) {
    var ans = confirm("Are You Sure You Want To Delete This Record");
    if (ans) {
        var model = { Id: id };
        $.ajax({
            url: "/Registration/Delete",
            method: "Post",
            data: JSON.stringify(model),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                alert("Record Deleted Successfully");
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
    }
}

var EditReg = function (id) {
    debugger
    var model = { Id: id }
    $.ajax({
        url: "/Registration/EditReg",
        type: "POST",
        data: JSON.stringify(model),
        async: false,
        contentType: "application/json;chrset:utf-8",
        success: function (result) {
            debugger;
            alert("update sucessfully");
            loadRegData(result);
        },
    });
}
var loadRegData = function (result) {

    debugger
    $('#hdnid').val(result[0].Id);
    $('#txtname').val(result[0].Name);
    $('#txtgender').val(result[0].Gender);
    $('#txtmobile').val(result[0].MobileNo);
    $('#txtaddress').val(result[0].Address);
    $('#ddlCity').val(result[0].City);
    $('#ddlState').val(result[0].State);
    $('#txtpincode').val(result[0].Pincode);
    $('#txtemail').val(result[0].Email);
    $('#txtpass').val(result[0].PassWord);
    $('#txthobbies').val(result[0].Hobbies);

    var CityId = result[0].City
    loadCityData(CityId);
    $('#ddlCity').val(CityId);
    $("#btnSave").text("Update");
}

    var ClearData = function () {
        $("#hdnid").val("");
        $("#txtname").val("");
        $("#txtgender").val("");
        $("#txtmobile").val("");
        $("#txtaddress").val("");
        $("#ddlCity").val("");
        $("#ddlState").val("");
        $("#txtpincode").val("");
        $("#txtemail").val("");
        $("#txtpass").val("");
        $("#txthobbies").val("");
   
}