(function (app) {
    app.controller("uploadMusicFormController", uploadMusicFormController);

    uploadMusicFormController.$inject = ["$scope", "apiService"];

    function uploadMusicFormController($scope, apiService) {
        $scope.categories = [];
        $scope.authors = [];
        $scope.isUploading = {
            status: false,
            uploadProgressCount: 0
        };
        $scope.song = {
            fileUrl: null
        };

        initializeForm();

        $scope.fileChanged = fileChanged;

        $scope.removeFile = removeFile;

        function fileChanged(element) {
            var file = element.files[0];

            $scope.isUploading.status = true;

            apiService.uploadSingleFile(file, progress, finish, cancel, fail);

            function progress(uploadProgressCount) {
                $scope.isUploading.uploadProgressCount = uploadProgressCount;
                $scope.$apply();
            }

            function finish(fileUrl) {
                $scope.isUploading.status = false;
                $scope.song.fileUrl = fileUrl;
                $scope.$apply();
            }

            function cancel() { }

            function fail() {}
        }

        function initializeForm() {
            apiService.get("/Api/Categories/GetCategories", doneGetCategories, failedGetCategories);

            apiService.get("/Api/Authors/GetAuthors", doneGetAuthors, failedGetAuthors);

            function doneGetCategories(returnedCategories) {
                $scope.categories = returnedCategories;
            }

            function failedGetCategories(returnedError) {
                console.log(returnedError);
            }

            function doneGetAuthors(returnedAuthors) {
                $scope.authors = returnedAuthors;
            }

            function failedGetAuthors(returnedError) {
                console.log(returnedError);
            }
        }

        function removeFile() {
            apiService.deleteSingleFile($scope.song.fileUrl, doneRemoveFile, failedRemoveFile);

            function doneRemoveFile() {
                $scope.song.fileUrl = null;
            }

            function failedRemoveFile(errorMessage) {
                console.log(errorMessage);
            }
        }
    }
})(angular.module("musicStore"));