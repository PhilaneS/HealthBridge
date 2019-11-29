(function () {
    //Module 
    var app = angular.module('app', ['toaster', 'ngAnimate']);
    // Controller
    app.controller('MyController', function ($scope, toaster) {
        $scope.Message = "Congratulation you have created your first application using AngularJs";
    });
})();