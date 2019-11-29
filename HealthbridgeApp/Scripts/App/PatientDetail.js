(function () {
    //Module 
    var app = angular.module('app', []);
    // Controller
    app.controller('PatientCtr', function ($scope, patientService) {
        $scope.PatientId = 0;
        $scope.FirstName = '';
        $scope.currentPatientId = patientService.GetPaientId();
        patientService.GetPatientById($scope.currentPatientId).then(function (response) {
            $scope.Patient = response.data;
            $scope.PatientId = response.data.PatientId;
            $scope.FirstName = response.data.FirstName;
            $scope.LastName = response.data.LastName;
            $scope.IdNumber = response.data.IdNumber;
        });

        $scope.UpdatePatient = function () {
            var data = {
                PatientId: $scope.PatientId,
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                IdNumber: $scope.IdNumber
            };
            patientService.UpdatePatientData(data);

            //redirect to the main page
            window.location.href = '/Patient/Index';
        };
    });

    app.factory('patientService', function ($http, $q, $window) {

        return {
            //Get current selected patient Id
            GetPaientId: function () {
                var urlPath = $window.location.href;
                //will split the url by forword slash
                var result = String(urlPath).split("/");
                if (result !== null && result.length > 0) {
                    //will get the last value from url.
                    var id = result[result.length - 1];
                    return id;
                }
            },
            GetPatientById: function (patientId) {
                return $http.get('/Patient/GetPatientById', { params: { id: patientId } });
            },
            UpdatePatientData: function (patient) {
                var defer = $q.defer();
                patient.Id = this.GetPaientId();
                $http({
                    url: '/Patient/UpdatePatient',
                    method: 'POST',
                    data: patient
                }).then(function successCallback(d) {
                    defer.resolve(d);
                }, function errorCallback(e) {
                    alert("Error");
                    defer.reject(e);
                });
                return defer.promise;
            }
        };
    });
})();