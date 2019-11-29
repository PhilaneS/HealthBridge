(function () {
    //Module
    var app = angular.module('app', ['toaster', 'ngAnimate']);
    // Controller
    app.controller('InvoiceCtr', function ($scope,toaster,invoiceService) {
        $scope.EditMode = false;
        $scope.currentInvoiceId = invoiceService.GetInvoceId();

        $scope.getTotal = function () {           

            var total = 0;
            for (var i = 0; i < $scope.invoice.InvoiceLine.length; i++) {
                var product = $scope.invoice.InvoiceLine[i];
                total += product.Qty * product.LineTotal;
            }
            return total;
        };
        $scope.getTotalQty = function () {

            var total = 0;
            for (var i = 0; i < $scope.invoice.InvoiceLine.length; i++) {
                var product = $scope.invoice.InvoiceLine[i];
                total += product.Qty;
            }
            return total;
        };

        $scope.resetInvoice = function () {
            $scope.invoice = {
                PatientId: $scope.invoice.PatientId,
                InvoiceDateTime: '',
                FirstName: '',
                LastName: '',
                InvoiceLine: []
            };
        };
        //$scope.resetInvoice();
        $scope.invoice = {};
        $scope.modeType = '';
        $scope.loadInvoice = function () {
            $scope.currentInvoiceId = invoiceService.GetInvoceId();
            invoiceService.GetInvoiceById($scope.currentInvoiceId).then(function (d) {
                $scope.invoice = d.data; // Success
             
            }, function () {
            });
        };       

        $scope.loadInvoice();

        $scope.AddLineNewInvoice = function (data) {
            //console.log(data);
            //alert(data.PatientId);
            $scope.EditMode = true;
            $scope.modeType = 'add';
            $scope.currentInvoiceId = 0;
            $scope.resetInvoice();
            $scope.invoice.PatientId = data.PatientId;

            $scope.invoice.InvoiceDateTime = new Date().getFullYear() + "/" + new Date().getMonth() + "/" + new Date().getDate();
            $scope.invoice.InvoiceLine.push({
                InvoiceLineId: 0,
                InvoiceId: $scope.currentInvoiceId,
                Qty: 0,
                Code: '',
                Description: '',
                LineTotal: 0.0
            });            
        };

        $scope.AddLineItem = function (data) {
            $scope.EditMode = true;

            if ($scope.currentInvoiceId === 0) {
                $scope.currentInvoiceId = 0;
                $scope.modeType = 'add';
            }
            else {
                $scope.currentInvoiceId = invoiceService.GetInvoceId();
                $scope.modeType = 'edit';
            }


            $scope.invoice.InvoiceId = data.InvoiceId;
            $scope.invoice.InvoiceLine.push({
                InvoiceLineId: 0,
                InvoiceId: $scope.currentInvoiceId,
                Qty: 0,
                Code: '',
                Description: '',
                LineTotal : 0.0
            });            
        };

        $scope.EditLineItem = function () {
            $scope.currentInvoiceId = invoiceService.GetInvoceId();
            $scope.EditMode = true;
            $scope.modeType = 'edit';
        };

        $scope.DeleteItem = function (item) {
            $scope.modeType = 'del';
            //console.log(item);
            if (item !== null && item !== undefined) {

                invoiceService.DeleteInvoice(item).then(function (d) {
                    //$scope.loadInvoice();
                    
                    var index = $scope.invoice.InvoiceLine.indexOf(item);
                    $scope.invoice.InvoiceLine.splice(index, 1);

                    alert('Deleted Successfully');
                    toaster.pop('success', 'SUCCESS!', "Deleted Successfully");
                }, function (d) {
                        alert('Could not delete the Item.');
                    toaster.pop('error', 'ERROR!', 'Could not delete the Item.');
                });

            }
        };
        $scope.cancel = function () {
            $scope.loadInvoice();
            $scope.modeType = '';
            $scope.EditMode = false;
        };  
        $scope.saveChanges = function (data) {
            console.log(data);
            switch ($scope.modeType) {
                case 'edit':
                    // call edit service
                    alert($scope.modeType);
                    invoiceService.EditInvoice(data).then(function (d) {
                        //$scope.loadInvoice();
                        alert('Updated Successfully.');

                        //toaster.pop('success', 'SUCCESS!', d.data);
                    }, function (d) {
                            //toaster.pop('error', 'ERROR!', d.data);
                            alert('Could not update the Item.');

                    });
                    break;
                case 'add':
                    // call add service
                    invoiceService.AddInvoice(data).then(function (d) {
                        $scope.modeType = '';
                        alert('Invoice added successfully.');
                        $scope.loadInvoice();
                       // toaster.pop('success', 'SUCCESS!', d.data);
                    }, function (d) {
                        //toaster.pop('error', 'ERROR!', d.data);
                            alert('Could not update the Item Invoice.');
                    });
                    break;
                default:
               
            }
            //alert($scope.modeType);
            //console.log(data);
        };
    });
    app.factory('invoiceService', function ($http, $q, $window) {
        return {
            GetInvoceId: function () {
                var urlPath = $window.location.href;
                var result = String(urlPath).split("/");
                if (result !== null && result.length > 0) {
                    var id = result[result.length - 1];
                    return id;
                }
            },
            GetInvoiceById: function (id) {
                return $http.get('/Invoice/GetInvoiceById', { params: { id: id } });
            },
            AddInvoice: function (data) {
                console.log(data);
                var defer = $q.defer();
                $http({
                    url: '/Invoice/createInvoice',
                    method: "POST",
                    data: data
                    //headers: { 'Content-Type': 'application/json' }
                }).then(function successCallback(d) {
                    defer.resolve(d);
                }, function errorCallback(e) {
                    defer.reject(e);
                });
                return defer.promise;
            },
            EditInvoice: function (data) {
                var defer = $q.defer();
                $http({
                    url: '/Invoice/updateInvoice',
                    method: "POST",
                    data: data
                }).then(function successCallback(d) {
                    defer.resolve(d);
                }, function errorCallback(e) {
                    defer.reject(e);
                });
                return defer.promise;
            },
            DeleteInvoice: function (data) {
                var defer = $q.defer();
                $http({
                    url: '/Invoice/DeleteInvoiceItem',
                    method: "POST",
                    data: data
                }).then(function successCallback(d) {
                    defer.resolve(d);
                }, function errorCallback(e) {
                    defer.reject(e);
                });
                return defer.promise;
            }
        };
    });
})();