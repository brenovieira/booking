(function () {
    'use strict';

    angular
        .module('Booking')
        .run(run);

    run.$inject = ['$rootScope', 'constants'];

    function run($rootScope, constants) {
        $rootScope.constants = constants;
    }
})();