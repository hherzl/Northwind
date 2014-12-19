(function () {
    'use strict';

    northwindApp
        .service('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['$http'];

    function EmployeeService($http) {
        this.getData = getData;

        function getData() { }
    }
})();