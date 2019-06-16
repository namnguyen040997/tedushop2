(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http']; //directive có sẵn của angular

    function apiService($http) {
        return {
            get: get
            //post: post,
            //put: put,
            //del: del
        }
        function get(url, params, success, failure) {
            //authenticationService.setHeader();
            $http.get(url, params)          //Gọi request đến API
                .then(function (result) {   //Xử lý sau khi gọi api: trả về 2 hàm: 1 sẽ trả về hàm success(result), và failure(error)
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('tedushop.common')) //Module dùng chung

        //function del(url, data, success, failure) {
        //    authenticationService.setHeader();
        //    $http.delete(url, data).then(function (result) {
        //        success(result);
        //    }, function (error) {
        //        console.log(error.status)
        //        if (error.status === 401) {
        //            notificationService.displayError('Authenticate is required.');
        //        }
        //        else if (failure != null) {
        //            failure(error);
        //        }

        //    });
        //}
        //function post(url, data, success, failure) {
        //    authenticationService.setHeader();
        //    $http.post(url, data).then(function (result) {
        //        success(result);
        //    }, function (error) {
        //        console.log(error.status)
        //        if (error.status === 401) {
        //            notificationService.displayError('Authenticate is required.');
        //        }
        //        else if (failure != null) {
        //            failure(error);
        //        }

        //    });
        //}
        //function put(url, data, success, failure) {
        //    authenticationService.setHeader();
        //    $http.put(url, data).then(function (result) {
        //        success(result);
        //    }, function (error) {
        //        console.log(error.status)
        //        if (error.status === 401) {
        //            notificationService.displayError('Authenticate is required.');
        //        }
        //        else if (failure != null) {
        //            failure(error);
        //        }

        //    });
        //}
