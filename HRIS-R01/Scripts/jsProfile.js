$(document).ready(function() {
        
    //var idv = "@ViewBag.cIDV";
    console.log("jsProfile Loaded");
    var uri = 'api/emp_master/' + $.jStorage.get('idv');
    //console.log(uri);
    var sourceProfile = {
        dataType: 'json',
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
        url: uri
    };

    
    var dataAdapter = new $.jqx.dataAdapter(sourceProfile, {
        //autoBind: true,
        contentType: 'application/json; charset=utf-8',
        loadComplete: function (records) { 
            var dataRecord = dataAdapter.records;
            var dt = records;
          
            //Fill IN FORM
            IN('IDParent');
            IN('IDParentLevel');
            IN('UID');
            IN('Name');
            IN('NickName');
            IN('Religion');
            IN('Gender');
            IN('Gender');
            IN('Marital');
            IN('NIP');

            IN('Birthdate');
            IN('Birthplace');
            IN('Nationality');

            IN('empEdu');
            IN('empEduMajor');

            IN('empDepartement');
            IN('empDivision');
            IN('empJobLevel');
            IN('empOfficeLocation');
            IN('empPosition');

            IN('Phone1');
            IN('Phone2');

            IN('Address');
            IN('AddressKec');
            IN('AddressKel');
            IN('AddressKab');
            IN('AddressProv');

            IN('UID_ABSENCE');
            IN('empStatus');
            IN('rowStatus');

            //Fill IN FORM
            function IN(idval) {
                try {
                    var str = eval('dt.' + idval);
                    $('#' + idval).val(str);
                } catch (err) {
                    console.log('Error : ' + idval + ' ' + err);
                }
                
            }
        },
        loadError: function (jqXHR, status, error) {
            console.log('Retrieve Error : ', jqXHR.responseText);
        },
        beforeLoadComplete: function (records) {
            // console.log
        }
    });
    
    dataAdapter.dataBind();

    var vStatus = false;
    var th = $.jStorage.get("th");

    //bindInput("IDParent");
    //bindInput("IDParentLevel");
    //bindInput("UID");
    bindInput("Name");
    bindInput("NickName");
    bindCategory("Religion", "empReligion");
    bindCategory("Gender", "empGender");
    bindCategory("Marital", "empMarital");
    bindInput("NIP");

    bindDateTime("Birthdate");
    bindInput("Birthplace");
    bindCategory("Nationality", "empCountry");

    bindCategory("empEdu");
    bindCategory("empEduMajor");

    bindCategory("empDepartement");
    bindCategory("empDivision");
    bindCategory("empJobLevel");
    bindCategory("empOfficeLocation");
    bindCategory("empPosition");

    bindInput("Phone1");
    bindInput("Phone2");

    bindTextArea("Address");
    bindInput("AddressKel");
    bindLocation("AddressKec");
    bindLocation("AddressKab");
    bindLocation("AddressProv");

    //bindInput("UID_ABSENCE");
    bindCategory("empStatus", "empStatus");
    //bindCategory("rowStatus", "rowStatus");
    

    bindButton("SubmitButton");

    function bindButton(div) {
        try {
            $("#" + div).jqxButton({ disabled: vStatus, theme: 'orange', width: 120, height: 40 });
        } catch(err) {
            console.log('Error: ',err)
        }
        
    }

    function bindTextArea(div) {
        try {
            $("#" + div).jqxTextArea({ disabled: vStatus, placeHolder: "Text", width: '100%', height: 80 });
        } catch (err) {
            console.log('Error: ', err)
        }
    }

    function bindDateTime(div) {
        try {
            $("#" + div).jqxDateTimeInput({ disabled: vStatus, theme: th, height: '35px' });
        } catch (err) {
            console.log('Error: ', err)
        }
    }

    function bindInput(div) {
        try {
            var th = $.jStorage.get("th");
            $("#" + div).jqxInput({ disabled: true, theme: th, width: '100%', height: '35px' });
        } catch (err) {
            console.log('Error: ', err)
        }
    }

    function bindCategory(div, value) {
        try {
            var th = $.jStorage.get("th");
            $("#" + div).jqxDropDownList({ source: jsCategory(value), theme: th, disabled: false, displayMember: "uidname", valueMember: "id", width: '100%' });
            console.log('value: ' + th + '==' + value + ' : ' + jsCategory(value));
        } catch (err) {
            console.log('Error: ', err)
        }
    }

    function bindLocation(div, value) {
        try {
            var th = $.jStorage.get("th");
            $("#" + div).jqxComboBox({ source: jsCategory(value), theme: th, disabled: false, displayMember: "uidname", valueMember: "id" });
        } catch (err) {
            console.log('Error: ', err)
        }
    }

});
