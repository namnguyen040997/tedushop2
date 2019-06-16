(function (app) {

    //tạo Controller productCategoryListController
    app.controller('ProductCategoryListController', ProductCategoryListController);

    //Inject 2 service vào controller là $scope và apiService
    ProductCategoryListController.$inject = ['$scope', 'apiService'];

    //Định nghĩa function productCategoryListController
    function ProductCategoryListController($scope, apiService) {

        //Tạo mới 1 scope là productCategories bằng 1 mảng trống
        $scope.productCategories = [];

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.keyword = '';

        //Tạo mới 1 scope là getProductCategories được gán bằng phương thức getProductCategories
        $scope.getProductCategories = getProductCategories;

        ////phương thức search được chạy khi click tìm kiếm nó sẽ tự gọi lại hàm getProductCategories để lấy dữ liệu về
        //$scope.search = search;
        //function search() {
        //    getProductCategories();
        //}
        //định nghĩa phương thức getProductCategories
        function getProductCategories(page) {

            //page = page khi page != null, page = 0 khi page = null
            page = page || 0;
            //Tạo biến config lưu 2 params cần truyền lên trên API productsCategoryController.cs
            var config = {
                params: {
                    //keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }

            //dùng phương thức get của apiService để gửi request lên API 
            //productCategoryController để lấy ra List ProductCategory theo ý muốn
            apiService.get('/api/productcategory/getall', config, function (result) {

                $scope.productCategories = result.data.Items;

                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log("Load ProductCategory failed.");
            });
        }
        //gọi hàm ra và sẽ được chạy khi controller được khởi tạo
        $scope.getProductCategories();
    }
})(angular.module('tedushop.product_categories'));




