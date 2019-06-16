(function () {
    angular.module('tedushop.products', ['tedushop.common']).config(config);

    //(Tại khai báo tedushop.common nên có thể sử dụng urlrouter)
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        //Cấu hình routing cho module tedushop.products
        $stateProvider
            .state('products', {
                url: "/products", //trang url thực tế
                templateUrl: "/app/components/products/productListView.html", //Đường dẫn của home
                controller: "productListController" //tên controller
                //=> Đường dẫn /products gọi đến view productListView.html và nó sẽ tự động nhận productListController
            })
            .state('product_add', {
                url: "/product_add", //trang url thực tế
                templateUrl: "/app/components/products/productAddView.html", //Đường dẫn của home
                controller: "productAddController" //tên controller
                //=> Đường dẫn /products gọi đến view productListView.html và nó sẽ tự động nhận productListController
            });
    }
})();