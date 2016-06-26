(function () {
    'use strict';

    angular
        .module('Booking')
        .service('orderService', orderService);

    orderService.$inject = ['serviceFactory', 'constants'];

    function orderService(serviceFactory, constants) {
        return serviceFactory.createService(constants.base, constants.api.order);
    }
})();