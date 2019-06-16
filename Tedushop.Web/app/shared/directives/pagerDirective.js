(function (app) {
    'use strict';

    app.directive('pagerDirective', pagerDirective);

    function pagerDirective() {
        return {
            scope: {
                page: '@',//trang truyền lên là page bao nhiêu
                pagesCount: '@',//Tổng số page
                totalCount: '@',//Tổng số phần tử trên tất cả page
                searchFunc: '&',/*Lấy giá trị của page được click gửi lên controller > gửi lên api xử 
                                  lý trả về controller > client page tương ứng với giá trị page gửi lên*/
                customPath: '@'//đường dẫn tùy chỉnh
            },
            replace: true,
            restrict: 'E',
            templateUrl: '/app/shared/directives/pagerDirective.html',
            controller: [
                //phương thức trả về page tương ứng với giá trị truyền vào
                '$scope', function ($scope) {
                    $scope.search = function (i) {
                        if ($scope.searchFunc) {
                            $scope.searchFunc({ page: i });
                        }
                    };
                    //phương thức tra về khoảng các page sẽ được hiển thị(hàm này trả ra 4)
                    //ví dụ: << < 1 2 3 4 > >> ; << < 2 3 4 5 > >> thì 1 2 3 4 là range
                    $scope.range = function () {
                        if (!$scope.pagesCount) { return []; }
                        var step = 2;
                        var doubleStep = step * 2;
                        var start = Math.max(0, $scope.page - step);
                        var end = start + 1 + doubleStep;
                        if (end > $scope.pagesCount) { end = $scope.pagesCount; }

                        var ret = [];
                        for (var i = start; i != end; ++i) {
                            ret.push(i);
                        }

                        return ret;
                    };
                    //phương thức chuyển page sang một page khác lớn hơn giá trị count truyền vào
                    $scope.pagePlus = function (count) {
                        return +$scope.page + count;
                    }

                }]
        }
    }

})(angular.module('tedushop.common'));