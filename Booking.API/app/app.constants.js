(function () {
    'use strict';

    angular
        .module('Booking')
        .constant('constants', {
            base: '',
            api: {
                account: {
                    get: '/api/account',
                    getById: '/api/account/{id}',
                    save: '/api/account/{id}',
                    delete: '/api/account/{id}',
                },
                availability: {
                    get: '/api/availability',
                    getById: '/api/availability/{id}',
                    save: '/api/availability/{id}',
                    delete: '/api/availability/{id}',
                },
                event: {
                    get: '/api/event',
                    getById: '/api/event/{id}',
                    save: '/api/event/{id}',
                    delete: '/api/event/{id}',
                },
                healthIssue: {
                    get: '/api/healthIssue',
                    getById: '/api/healthIssue/{id}',
                    save: '/api/healthIssue/{id}',
                    delete: '/api/healthIssue/{id}',
                },
                order: {
                    get: '/api/order',
                    getById: '/api/order/{id}',
                    save: '/api/order/{id}',
                    delete: '/api/order/{id}',
                },
            },
            routes: {
                home: { route: '/home', view: '/app/components/home/index.html', controller: 'homeController' },
                account: { route: '/account', view: '/app/components/account/index.html', controller: 'accountController' },
                event: { route: '/event', view: '/app/components/event/index.html', controller: 'eventController' },
                order: { route: '/order', view: '/app/components/order/index.html', controller: 'orderController' },
            }
        });
})();