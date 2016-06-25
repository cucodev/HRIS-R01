$(document).ready(function () {


    console.log("jsProfile Loaded");

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
        loadComplete: function (records) { 
            var dataRecord = dataAdapter.records;
            var dt = dataRecord[0];
            //console.log(dt);

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
                var str = eval('dt.' + idval);
                $('#' + idval).val(str);
            }
        },
        loadError: function (jqXHR, status, error) {
            console.log(jqXHR.responseText);
        },
        beforeLoadComplete: function (records) {
           // console.log
        }
    });
    
    dataAdapter.dataBind();

    


})