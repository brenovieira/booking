(function () {
    'use strict';

    angular
        .module('Booking')
        .config(routesConfig);

    routesConfig.$inject = ['$routeProvider', 'constants'];

    function routesConfig($routeProvider, c) {
        $routeProvider
            .when(c.routes.home.route, { controller: c.routes.home.controller, templateUrl: c.routes.home.view, controllerAs: 'vm' })
            .when(c.routes.account.route, { controller: c.routes.account.controller, templateUrl: c.routes.account.view, controllerAs: 'vm' })
            .when(c.routes.event.route, { controller: c.routes.event.controller, templateUrl: c.routes.event.view, controllerAs: 'vm' })
            .when(c.routes.order.route, { controller: c.routes.order.controller, templateUrl: c.routes.order.view, controllerAs: 'vm' })
            .otherwise({ redirectTo: c.routes.home.route });
    }
})();