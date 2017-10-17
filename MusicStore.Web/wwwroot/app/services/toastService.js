(function (app) {
    app.service("toastService", toastService);

    function toastService() {        
        const TOAST_TIME_OUT = 4000;

        function warning(message, title) {
            toastr.warning(message, title, { timeOut: TOAST_TIME_OUT });
        }

        function success(message, title) {
            toastr.success(message, title, { timeOut: TOAST_TIME_OUT });
        }

        function error(message, title) {
            toastr.error(message, title, { timeOut: TOAST_TIME_OUT });
        }

        function remove() {
            toastr.remove();
        }

        function clear() {
            toastr.clear();
        }

        return {
            success: success,
            warning: warning,
            error: error,
            remove: remove,
            clear: clear
        };
    }
})(angular.module("musicStore.common"));