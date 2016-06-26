(function () {
    'use strict';

    angular
        .module('Booking')
        .controller('eventController', EventController);

    EventController.$inject = ['$routeParams', '$location', 'availabilityService',
        'healthIssueService', 'orderService', 'eventService', 'constants'];

    function EventController($routeParams, $location, availabilityService,
        healthIssueService, orderService, eventService, constants) {
        var vm = this;
        var _availability = [];

        vm.price = 0;
        vm.healthIssues = [];
        vm.dateOptions = {
            minDate: new Date(),
            showWeeks: false,
            dateDisabled: dateDisabled
        };
        vm.event = {
            Id: parseInt($routeParams.id) || 0,
            Title: null,
            Description: null,
            ThumbnailUrl: null
        };
        vm.form = {
            EventId: vm.event.Id,
            Quantity: null,
            Date: null,
            People: []
        };

        vm.book = book;
        vm.changeQuantity = changeQuantity;
        vm.changeDate = changeDate;
        vm.changeHealthIssue = changeHealthIssue;

        activate();

        ///////////
        function activate() {
            getEvent();
            getHealthIssues();
        }

        function getEvent() {
            eventService.getById(vm.event.Id).then(function (results) {
                vm.event = results;
            });
        }

        function getHealthIssues() {
            healthIssueService.get().then(function (results) {
                vm.healthIssues = results;
            });
        }

        function book() {
            orderService.save(0, vm.form).then(function (results) {
                var path = constants.api.order.route.replace(':id', results.Confirmation);
                $location.path(path)
            });
        }

        function changeQuantity() {
            if (vm.form.Quantity < 1) return;

            var data = { EventId: vm.event.Id, Quantity: vm.form.Quantity };

            availabilityService.get(data).then(function (results) {
                _availability = results;
            });

            var diff = data.Quantity - vm.form.People.length;
            for (var i = 0; i < diff; i++) {
                vm.form.People.push({
                    Id: 0,
                    Name: null,
                    Age: null,
                    Gender: null,
                    Weight: null,
                    HealthIssues: []
                });
            }

            for (var i = 0; i < -1 * diff; i++) {
                vm.form.People.pop();
            }
        }

        function changeDate() {
            var index = _availability.map(function (a) { return a.Date }).indexOf(date);
            if (index === -1) {
                vm.price = 0;
            }
            else {
                vm.price = _availability[index].Price;
            }
        }

        function changeHealthIssue(person, healthIssue) {
            var index = person.HealthIssues.map(function (a) { return a.Id; }).indexOf(healthIssue.Id);

            if (index === -1) {
                person.HealthIssues.push(healthIssue);
            }
            else {
                person.HealthIssues.splice(index, 1);
            }
        }

        function dateDisabled(data) {
            var date = data.date, mode = data.mode;
            return mode === 'day' && _availability.map(function (a) { return a.Date }).indexOf(date) === -1;
        }
    }
})();