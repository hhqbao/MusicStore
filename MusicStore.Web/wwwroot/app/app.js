(function () {
    angular.module("musicStore", [
        "musicStore.common"
    ]).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/personal-music");

        $stateProvider.state("personal-music", {
            url: "/personal-music",
            templateUrl: "/app/views/personal/personalMusicListView.html",
            controller: "personalMusicListController"
        }).state("upload-music", {
            url: "/upload-music",
            templateUrl: "/app/views/personal/uploadMusicFormView.html",
            controller: "uploadMusicFormController"
        });
    }
})();