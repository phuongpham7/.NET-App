var EmpControllers = angular.module("EmpControllers", []);
EmpControllers.controller("ListController", ['$scope', '$http',
    function($scope, $http)
    {
        $http.get('/api/employees').success(function(data)
        {
            $scope.employees = data;
        });
    }
]);

EmpControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function($scope, $http, $routeParams, $location)
    {
        $scope.id = $routeParams.id;
        $http.get('/api/employees/' + $routeParams.id).success(function(data)
        {
            $scope.firstname = data.FirstName;
            $scope.lastname = data.LastName;
            $scope.country = data.Country;
            $scope.state = data.State;
            $scope.salary = data.Salary;
            $scope.active = data.IsActive;
            $scope.dob = data.DateOfBirth;
            $scope.description = data.Description;
        });
        $scope.delete = function()
        {
            $http.delete('/api/Employees/' + $scope.id).success(function(data)
            {
                $location.path('/list');
            }).error(function(data)
            {
                $scope.error = "An error has occured while deleting employee! " + data;
            });
        };
    }
]);

EmpControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function($scope, $filter, $http, $routeParams, $location)
    {
        $http.get('/api/country').success(function(data)
        {
            $scope.countries = data;
        });
        $scope.id = 0;
        $scope.getStates = function()
        {
            var country = $scope.country;
            if (country)
            {
                $http.get('/api/country/' + country).success(function(data)
                {
                    $scope.states = data;
                });
            }
            else
            {
                $scope.states = null;
            }
        }
        $scope.save = function()
        {
            var obj = {
                Id: $scope.id,
                FirstName: $scope.firstname,
                LastName: $scope.lastname,
                Country: $scope.country,
                State: $scope.state,
                Salary: $scope.salary,
                IsActive: $scope.active,
                Description: $scope.description,
                DateOfBirth: $scope.dob
            };
            if ($scope.id == 0)
            {
                $http.post('/api/Employees/', obj).success(function(data)
                {
                    $location.path('/list');
                }).error(function(data)
                {
                    $scope.error = "An error has occured while adding employee! " + data.ExceptionMessage;
                });
            }
            else
            {
                $http.put('/api/Employees/', obj).success(function(data)
                {  
                    $location.path('/list');
                }).error(function(data)
                {
                    console.log(data);
                    $scope.error = "An Error has occured while saving employee! " + data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id)
        {
            $scope.id = $routeParams.id;
            $scope.title = "Edit Employee";
            $http.get('/api/employees/' + $routeParams.id).success(function(data)
            {
                $scope.firstname = data.FirstName;
                $scope.lastname = data.LastName;
                $scope.country = data.Country;
                $scope.state = data.State;
                $scope.salary = data.Salary;
                $scope.active = data.IsActive;
                $scope.description = data.Description;
                $scope.dob = new Date(data.DateOfBirth);
                $scope.getStates();
            });
        }
        else
        {
            $scope.title = "Create New Employee";
        }
    }
]);