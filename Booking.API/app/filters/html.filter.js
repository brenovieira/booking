(function () {
    'use strict';

    angular
        .module('Booking')
        .filter('html', html);

    html.$inject = ['$sce'];

    function html($sce) {
        return function (text) {
            return $sce.trustAsHtml(text);
        };
    }
})();