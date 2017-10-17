(function (app) {
    app.controller("uploadMusicFormController", uploadMusicFormController);

    uploadMusicFormController.$inject = ["$scope", "apiService", "$location", "toastService"];

    function uploadMusicFormController($scope, apiService, $location, toastService) {
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

        $scope.submitForm = submitForm;

        $scope.cancelForm = cancelForm;

        function submitForm() {
            var formData = new FormData();

            formData.append("title", $scope.song.title);
            formData.append("categoryId", $scope.song.categoryId);
            formData.append("authorId", $scope.song.authorId);
            formData.append("fileUrl", $scope.song.fileUrl);
            formData.append("lyric", $scope.song.lyric);

            apiService.post("/Api/Songs/CreateSong", formData, submitSuccess, submitFailed);

            function submitSuccess() {
                toastService.success("Create New Song Successfully!", "Dialog Box");
                $location.path("/personal-music");
            }

            function submitFailed() {
                toastService.error("Failed To Create New Song!", "Dialog Box");
            }
        }

        function cancelForm() {
            if ($scope.song.fileUrl !== null)
                $scope.removeFile();

            $location.path("/personal-music");
        }

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