(function(app) {
    app.controller("personalMusicListController", personalMusicListController);

    personalMusicListController.$inject = ["$scope"];

    function personalMusicListController($scope) {
        $scope.testing = "Ok!";
    }
})(angular.module("musicStore"));