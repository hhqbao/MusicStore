(function (app) {
    app.service("apiService", apiService);

    apiService.$inject = ["$http"];

    function apiService($http) {
        return {
            uploadSingleFile: uploadSingleFile,
            deleteSingleFile: deleteSingleFile,
            get: get,
            post: post            
        };

        function uploadSingleFile(fileToUpload, progress, finish, cancel, fail) {
            var formData = new FormData();
            formData.append("file", fileToUpload);

            var reqObj = new XMLHttpRequest();
            reqObj.upload.addEventListener("progress", innerProcess, false);
            reqObj.addEventListener("load", innerComplete, false);
            reqObj.addEventListener("error", fail, false);
            reqObj.addEventListener("abort", cancel, false);
            reqObj.open("POST", "/Api/Files/UploadSingleFile", true);
            reqObj.send(formData);

            function innerProcess(evt) {
                if (evt.lengthComputable) {
                    var uploadProgressCount = Math.round(evt.loaded * 100 / evt.total);

                    progress(uploadProgressCount);
                } else
                    progress(-1);
            }

            function innerComplete(evt) {
                var fileUrl = evt.currentTarget.response;

                fileUrl = fileUrl.replace('"', '');
                fileUrl = fileUrl.replace('"', '');

                finish(fileUrl);
            }
        }

        function deleteSingleFile(fileUrl, done, failed) {
            var formData = new FormData();

            formData.append("fileUrl", fileUrl);

            post("/Api/Files/DeleteSingleFile", formData, done, failed);
        }

        function get(apiUrl, done, failed) {
            $http.get(apiUrl).then(function (success) {
                done(success.data);
            }, function (failure) {
                failed(failure.data);
            });
        }

        function post(apiUrl, formData, done, fail) {
            $http.post(apiUrl, formData, {
                transformRequest: angular.identity,
                headers: { "Content-Type": undefined }
            }).then(function (success) {
                done(success.data);
            }, function (failed) {
                fail(failed.data);
            });
        }        
    }
})(angular.module("musicStore.common"));