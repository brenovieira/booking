(function () {
    'use strict';

    angular
        .module('Booking')
        .service('eventService', eventService);

    eventService.$inject = ['serviceFactory', 'constants'];

    function eventService(serviceFactory, constants) {
        return serviceFactory.createService(constants.base, constants.api.event);
    }
})();