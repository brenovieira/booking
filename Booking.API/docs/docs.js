$(function () {
    var version = window.location.href.match(/v\d+(\.\d+)*/); //any v1, v1.2, v1.2.3 ...
    version = version && version[0] ? version[0] : 'v1';
    var url = '/docs/' + version;

    if (window.SwaggerTranslator) {
        window.SwaggerTranslator.translate();
    }

    window.swaggerUi = new SwaggerUi({
        url: url,
        dom_id: "swagger-ui-container",
        validatorUrl: null,
        supportedSubmitMethods: ['get', 'post', 'put', 'delete'],
        onComplete: function (swaggerApi, swaggerUi) {
            console.log("Loaded SwaggerUI");

            if (window.SwaggerTranslator) {
                window.SwaggerTranslator.translate();
            }

            $('pre code').each(function (i, e) {
                hljs.highlightBlock(e)
            });

            $('#api_info').addClass('container');
            $('input[name=grant_type]').val('password');
        },
        onFailure: function (data) {
            console.log("Unable to Load SwaggerUI");
        },
        docExpansion: "none",
        apisSorter: "alpha",
        showRequestHeaders: true,
        //operationsSorter: "alpha"
    });

    window.swaggerUi.load();
});