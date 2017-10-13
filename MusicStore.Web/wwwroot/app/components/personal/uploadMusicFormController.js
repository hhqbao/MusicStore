(function(app) {
    app.controller("uploadMusicFormController", uploadMusicFormController);

    uploadMusicFormController.$inject = ["$scope"];

    function uploadMusicFormController($scope) {
        $scope.testing = "OK Nha!";
    }
})(angular.module("musicStore"));