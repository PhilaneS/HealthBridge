(function () {
    //Module 
    var app = angular.module('app', []); 
    // Controller
    app.controller('PatientController', function ($scope, patientService) {

        $scope.UpdatePatient = null;
        $scope.PatientList = [];
        $scope.Patient = null;       

        patientService.getPatients().then(function (d) {
            $scope.PatientList = d.data; // Success
        }, function () {
            alert('Failed'); // Failed
            });

        

        //Add Patient Record function
        $scope.submitRegisterForm = function (data) {
            $scope.message = '';
            $scope.Patient = data;
            if ($scope.registerForm.$valid) {
                patientService.AddPatient($scope.Patient).then(function (d) { //Calling AddPatient() from service
                    console.log(d.status);
                    if (d.status ===200) {
                        //Clear Form
                        //$scope.ClearForm();
                        window.location.href = '/Patient/Index';
                    }
                });
            }
            else {
               // $scope.message = 'Please fill the required fields';
            }
        };

        //Redirect index form to edit form with parameter
        $scope.RedirectToEdit = function (patient) {
            console.log(patient.PatientId);
            window.location.href = '/Patient/Edit/' + patient.PatientId;
        };
        //Redirect to Detail view from index view with parameter
        $scope.RedirectToDetails = function (patient) {
            window.location.href = '/Patient/Detail/' + patient.PatientId;
        };
        //Delete patient Record function
        $scope.DeletePatient = function (patient) {
            console.log(patient);
            if (patient.PatientId !== null) {
                if (window.confirm('Are you sure you want to delete this patient Id: ' + patient.PatientId + '?'))//Popup window will open to confirm
                {
                    patientService.DelPatientData(patient).then(function (response) { //Calling DelPatientData() from service with parameter
                        window.location.href = '/Patient/Index';
                    }, function () {
                        alert("Error in deleting record");
                    });
                }
            }
            else {
                alert("this id is null");
            }
        };

        //Update Patient infornation function
        $scope.UpdatePatient = function () {

            var Patient = {};
            Patient["PatientId"] = $scope.PatientId;
            Patient["FirstName"] = $scope.FirstName;
            Patient["LastName"] = $scope.LastName;
            Patient["IdNumber"] = $scope.IdNumber;
            patientService.UpdatePatientData(Patient);
        };

        
        //Clear the forms
        $scope.ClearForm = function () {
            $scope.Patient = {};
            $scope.RegisterPatientForm.$setPristine();
            $scope.UpdateEmp = {};
            $scope.EditForm.$setPristine();
        };

    });

    //Patient service.
    //This service is responsible to fetch, insert ,update and delete data for Patients
    app.factory('patientService', function ($http, $q, $window) {
        return {
            //Get Patient list
            getPatients : function () {
                return $http.get('/Patient/GetPatientList');
            },           
            //this function will get the last value of current page url.
            DelPatientData: function (patient) {
                var defer = $q.defer(); 

                $http({
                    url: '/Patient/DeletePatient',
                    method: 'POST',
                    data: patient
                }).then(function successCallback(d) {
                    alert("the patient has been deleted successfully");
                    defer.resolve(d);
                },function errorCallback(e) {
                    alert("Error");
                    defer.reject(e);
                });
                return defer.promise;

            },
            AddPatient: function (data) {
                var defer = $q.defer();
                $http({
                    url: '/Patient/Register',
                    method: "POST",
                    data: data
                }).then(function successCallback(d) {
                    defer.resolve(d);
                }, function errorCallback(e) {
                    alert("Error");
                    window.location.href = '/Patient/Register';
                    defer.reject(e);
                });
                return defer.promise;
            }
        };
    });
})();