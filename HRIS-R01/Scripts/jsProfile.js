$(document).ready(function () {



    var sourceProfile = {
        dataType: "json",
        dataFields: [
            
            { name: 'ID', type: 'number' },
          //  { name: 'IDParentName', value: 'IDParent', values: { source: listEmployee.records, value: 'ID', name: 'Name' } },
            { name: 'IDParent', type: 'number' },
            { name: 'IDParentLevel', type: 'number' },
            { name: 'UID', type: 'string' },
            { name: 'Name', type: 'string' },
            { name: 'NickName', type: 'string' },
            { name: 'Religion', type: 'string' },
            { name: 'Gender', type: 'string' },
            { name: 'Marital', type: 'string' },
            { name: 'NIP', type: 'string' },
            
            { name: 'Birthdate', type: 'string' },
            { name: 'Birthplace', type: 'string' },
            { name: 'Nationality', type: 'string' },

            { name: 'empEdu', type: 'string' },
            { name: 'empEduMajor', type: 'string' },
            
            { name: 'empDepartement', type: 'string' },
            { name: 'empDivision', type: 'string' },
            { name: 'empJobLevel', type: 'string' },
            { name: 'empOfficeLocation', type: 'string' },
            { name: 'empPosition', type: 'string' },
            
            
            { name: 'Phone1', type: 'string' },
            { name: 'Phone2', type: 'string' },
            
            { name: 'Address', type: 'string' },
            { name: 'AddressKab', type: 'number' },
            { name: 'AddressKec', type: 'number' },
            { name: 'AddressKel', type: 'number' },
            { name: 'AddressProv', type: 'number' },
            
            { name: 'UID_ABSENCE', type: 'number' },
            { name: 'empStatus', type: 'string' },
            { name: 'rowStatus', type: 'string' }
            
            
        ],
        id: 'ID',
        url: '/api/emp_master/' + idv
    };

    var dataAdapter = new $.jqx.dataAdapter(sourceProfile, {
        downloadComplete: function (data) {
            source.totalrecords = data.TotalRows;
        },
        success: function (results) {
                console.log("GET Success");
            
        },
        error: function (data) {
            console.log("Error");
            
        }
    });

    var dataRecord = dataAdapter.records;

    //Fill IN FORM
    function IN(id) {
       $(id).val(dataRecord.id);
    }


    //ID: '',
    IN('IDParent');
    IN('Name');


    $("#IDParent").val(dataRecord.IDParent);
    $("#IDParentLevel").val(dataRecord.IDParentLevel);
    //UID
    $("#Name").val(dataRecord.Name);
    $("#Nickname").val(dataRecord.NickName);



    $("#nip").val(dataRecord.NIP);
    $("#birthDate").val(dataRecord.Birthdate);
    $("#religion").val(dataRecord.Religion);
    $("#address").val(dataRecord.Address);
    $("#province").jqxDropDownList('val', parseInt(dataRecord.AddressProv));
    $("#district").jqxDropDownList('val', parseInt(dataRecord.AddressKab));
    $("#districts").jqxDropDownList('val', parseInt(dataRecord.AddressKec));
    $("#subDistricts").jqxDropDownList('val', parseInt(dataRecord.AddressKel));
    $("#birthPlace").val(dataRecord.Birthplace);
    $("#birthDate").val(dataRecord.Birthdate);

    

    //Marital:'',
    $("#nationality").val(dataRecord.Nationality);
    $("#phone1").val(dataRecord.Phone1);
    $("#phone2").val(dataRecord.Phone2);
    $("#religion").val(dataRecord.Religion);
    //UID_ABSENCE: '',
    $("#department").val(dataRecord.empDepartement);
    $("#division").val(dataRecord.empDivision);
    $("#education").val(dataRecord.empEdu);
    $("#eduMajor").val(dataRecord.empEduMajor);
    //empJobLevel: '',
    $("#officeLocation").val(dataRecord.empOfficeLocation);
    $("#position").val(dataRecord.empPosition);
    $("#joblevel").val(dataRecord.empJobLevel);
    $("#status").val(dataRecord.empStatus);
    if (dataRecord.Gender == "M") {
        $("#maleGender").val(true);
    } else if (dataRecord.Gender == "F") {
        $("#femaleGender").val(true);
    }
});

