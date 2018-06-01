Cash.factory('ajaxService', function ($http) {

    var getData = function (method, uri, data) {
        // Angular $http() and then() both return promises themselves 
        return $http({ method: method, url: uri, data: data }).then(function (result) {

            // What we return here is the data that will be accessible
            // to us after the promise resolves
            return result.data;
        });
    };

    return { getData: getData };
});