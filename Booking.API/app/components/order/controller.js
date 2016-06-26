(function () {
    'use strict';

    angular
        .module('Booking')
        .controller('orderController', OrderController);

    OrderController.$inject = ['$routeParams', '$location', 'orderService', 'constants'];

    function OrderController($routeParams, $location, orderService, constants) {
        var vm = this;

        vm.order = {
            Id: 0,
            EventId: 0,
            Confirmation: $routeParams.id,
            People: [],
            Event: null
        };

        activate();

        ///////////
        function activate() {
            getOrder();
        }

        function getOrder() {
            orderService.getById(vm.order.Confirmation).then(function (results) {
                vm.order = results;
            });
        }
    }
})();