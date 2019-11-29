(function () {
    //Module 
    var app = angular.module('app', []);
    // Controller
    app.controller('InvoiceCtr', function ($scope, invoiceService) {

        $scope.InvoiceList = [];
        invoiceService.GetInvoices().then(function (d) {
            console.log(d);
            $scope.InvoiceList = d.data; // Success
        }, function () {
            alert('Failed'); // Failed
            });
        $scope.RedirectToDetails = function (id) {
            window.location.href = '/Invoice/Details/' + id;
        };
    });
    app.factory('invoiceService', function ($http) {
        return {
            GetInvoices: function () {
                return $http.get('/Invoice/GetInvoices');
            }
        };
    });
})();