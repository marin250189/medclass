angular.module('loginCtrl', []).controller('LoginController', function ($scope, $http,$cookies) {
   
    $cookies.put('loginPage', true);
    
    $scope.submit = function () {

        $scope.status = [];
       
        
        // Returns the promise - Contains result once request completes
      
        var param = {
            user: $scope.email,
            password: $scope.password
        };
       
        var post = $http({
            method: "POST",
            url: "/Account/Login",
            dataType: 'json',
            data: { username: $scope.email, password: $scope.password },
            headers: { "Content-Type": "application/json" }
        });
        post.then(function (data) {          
           
            var message = data.data.Message;
            var name = data.data.UserName;
            
            if (data.data.Message == '') {

                $cookies.put('userCredentials', name);
                var prueba = $cookies.get('userCredentials');
                window.location = '/Home/Index';
            }
            else {
                $cookies.remove('userCredentials');
                $scope.status.push({ class: 'alert alert-danger alert-dismissible', label: message, close: 'close' });
            }
        },
        function (error) {
            alert(error.data);
        });

        

    }
    
})