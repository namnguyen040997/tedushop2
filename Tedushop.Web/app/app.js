
//Thư mục chính

(function () {
    //reference đến tedushop.products và tedushop.common để sử dụng ui-Router
    angular.module('tedushop', ['tedushop.products','tedushop.product_categories', 'tedushop.common']).config(config);


    //inject vào thư viện
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    //=> tự tiêm vào hàm config
    function config($stateProvider, $urlRouterProvider) {
        //Cấu hình routing cho module tedushop
        $stateProvider.state('home', {
                url: "/admin", //trang url thực tế
                templateUrl: "/app/components/home/homeView.html", //Đường dẫn của home
                controller: "homeController" //khai báo controller cho state home
                //=> Đường dẫn /admin gọi đến view homeView.html và nó sẽ tự động nhận homeController
            });
        //Nếu đường dẫn ko hợp lệ thì trả về /admin
        $urlRouterProvider.otherwise('/admin');
    }
})();
    //function configAuthentication($httpProvider) {
    //    $httpProvider.interceptors.push(function ($q, $location) {
    //        return {
    //            request: function (config) {

    //                return config;
    //            },
    //            requestError: function (rejection) {

    //                return $q.reject(rejection);
    //            },
    //            response: function (response) {
    //                if (response.status == "401") {
    //                    $location.path('/login');
    //                }
    //                //the same response/modified/or a new one need to be returned.
    //                return response;
    //            },
    //            responseError: function (rejection) {

    //                if (rejection.status == "401") {
    //                    $location.path('/login');
    //                }
    //                return $q.reject(rejection);
    //            }
    //        };
    //    });
    //}
