(function (app) {
    app.controller("personalMusicListController", personalMusicListController);

    personalMusicListController.$inject = ["$scope", "apiService"];

    function personalMusicListController($scope, apiService) {
        $scope.PLAYING_STATUS = {
            normal: 0,
            loopSingle: 1,
            loopAll: 2
        }

        $scope.mainAudio = {
            control: document.getElementById("main-audio"),
            playingStatus: $scope.PLAYING_STATUS.normal,
            isPlaying: false
        };

        $scope.songs = [];

        $scope.getSongs = getSongs;

        $scope.getSongs();        

        $scope.mainAudio.control.onended = onAudioEndEvent;
        
        $scope.rotatePlayingStatus = rotatePlayingStatus;        

        $scope.getBtnPlayModeClass = getBtnPlayModeClass;
                    
        $scope.playSong = playSong;
        
        $scope.pauseSong = pauseSong;

        function pauseSong() {
            $($scope.mainAudio.control).trigger("pause");

            $scope.mainAudio.isPlaying = false;
        }

        function playSong(song) {
            if (song !== $scope.currentPlayingSong) {
                $($scope.mainAudio.control).first("source").attr("src", song.fileUrl);

                $scope.currentPlayingSong = song;
            }

            $($scope.mainAudio.control).trigger("play");

            $scope.mainAudio.isPlaying = true;
        }

        function getSongs() {
            apiService.get("/Api/Songs/GetSongs", doneGetSongs, failedGetSongs);

            function doneGetSongs(returnedSongs) {
                $scope.songs = returnedSongs;
            }

            function failedGetSongs(returnedError) {
                console.log(returnedError);
            }
        }

        function getBtnPlayModeClass() {
            switch ($scope.mainAudio.playingStatus) {
            case $scope.PLAYING_STATUS.normal:
                return "btn-default";

            case $scope.PLAYING_STATUS.loopSingle:
                return "btn-primary";

            case $scope.PLAYING_STATUS.loopAll:
                return "btn-warning";
            }
        }

        function rotatePlayingStatus() {
            switch ($scope.mainAudio.playingStatus) {
            case $scope.PLAYING_STATUS.normal:
                $scope.mainAudio.playingStatus = $scope.PLAYING_STATUS.loopSingle;
                break;

            case $scope.PLAYING_STATUS.loopSingle:
                $scope.mainAudio.playingStatus = $scope.PLAYING_STATUS.loopAll;
                break;

            case $scope.PLAYING_STATUS.loopAll:
                $scope.mainAudio.playingStatus = $scope.PLAYING_STATUS.normal;
                break;
            }
        }

        function onAudioEndEvent() {
            $scope.mainAudio.isPlaying = false;

            var songIndex = $scope.songs.indexOf($scope.currentPlayingSong);

            switch ($scope.mainAudio.playingStatus) {
            case $scope.PLAYING_STATUS.normal:
                if (songIndex < $scope.songs.length - 1)
                    playSong($scope.songs[songIndex + 1]);

                break;

            case $scope.PLAYING_STATUS.loopSingle:
                playSong($scope.currentPlayingSong);
                break;

            case $scope.PLAYING_STATUS.loopAll:
                if (songIndex < $scope.songs.length - 1)
                    playSong($scope.songs[songIndex + 1]);
                else
                    playSong($scope.songs[0]);

                break;
            }

            $scope.$apply();
        }
    }
})(angular.module("musicStore"));