(function () {
    angular.module('tedushop.product_categories', ['tedushop.common']).config(config);

    //(Tại khai báo tedushop.common nên có thể sử dụng urlrouter)
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        //Cấu hình routing cho module tedushop.products
        $stateProvider
            .state('product_categories', {
                url: "/product_categories", //trang url thực tế
                templateUrl: "/app/components/product_categories/ProductCategoryListView.html", //Đường dẫn của home
                controller: "ProductCategoryListController" //tên controller
                //=> Đường dẫn /products gọi đến view productListView.html và nó sẽ tự động nhận productListController
            })
    }
})();