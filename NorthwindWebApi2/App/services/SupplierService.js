northwindApp.service("SupplierService", function ($http) {
    var baseUrl = "/api/";

    var url = baseUrl + "Supplier/";

    this.getAll = function () {
        return $http.get(url);
    }

    this.get = function(id) {
        return $http.get(url + id);
    }

    this.create = function(entity) {
        $http.post(url, entity);
    }
    
    this.update = function(entity) {
        $http.put(url + entity.supplierID, entity);
    }

    this.delete = function(entity)
    {
        $http.delete(url + entity.supplierID, entity);
    }
});
