(function () {
    'use strict';

    angular
        .module('Booking')
        .service('availabilityService', availabilityService);

    availabilityService.$inject = ['serviceFactory', 'constants'];

    function availabilityService(serviceFactory, constants) {
        return serviceFactory.createService(constants.base, constants.api.availability);
    }
})();