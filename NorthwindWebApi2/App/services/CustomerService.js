(function () {
    'use strict';

    northwindApp.service("CustomerService", CustomerService);

    CustomerService.$inject = ['$http'];

    function CustomerService($http) {
        var baseUrl = "/api/";
        var url = baseUrl + "Customer/";

        this.getAll = getAll;

        this.get = get;

        this.create = create;

        this.update = update;

        this.delete = destroy;

        function getAll() {
            return $http.get(url);
        }

        function get(id) {
            return $http.get(url + id);
        }

       function create(entity) {
           return $http.post(url, entity);
       }

        function update(entity) {
            return $http.put(url + entity.customerID, entity);
        }


        function destroy(entity) {
            return $http.delete(url + entity.customerID, entity);
        }

    }
})();