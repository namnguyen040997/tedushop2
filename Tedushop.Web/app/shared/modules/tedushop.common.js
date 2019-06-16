//Muc đích : thêm các engine bên ngoài
(function () {
    //add reference ui.router vào teđushop.common
    //Sau này ai sử dụng common thì có thể sử dụng router
    angular.module('tedushop.common', ['ui.router'])
    //=> sang app.js , đặt nó vào ['tedushop.common'] là có thể sử dụng ui.router
})();