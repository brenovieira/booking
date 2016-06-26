(function () {
    'use strict';

    angular
        .module('Booking')
        .controller('homeController', HomeController);

    HomeController.$inject = ['$location', 'eventService', 'constants'];

    function HomeController($location, eventService, constants) {
        var vm = this;

        vm.events = [];
        vm.openEvent = openEvent;

        activate();

        ///////////
        function activate() {
            getEvents();
        }

        function getEvents() {
            eventService.get().then(function (results) {
                vm.events = results;
            });
        }

        function openEvent(id) {
            var path = constants.routes.event.route.replace(':id', id);
            $location.path(path);
        }
    }
})();