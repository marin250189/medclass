angular.module('mainCtrl', []).controller('MainController', function ($scope, $http, $cookie) {

    $scope.isAuth = $cookies.get('userCredentials');
    $scope.Logout = function () {
        $cookies.remove('userCredentials');
        window.location = "/Account/Login";



    }
})