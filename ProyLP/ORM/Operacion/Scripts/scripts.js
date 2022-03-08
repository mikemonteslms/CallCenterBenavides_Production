(function (global, undefined) {
    function OnClientFileOpen(oExplorer, args) {
        var item = args.get_item();
        var fileExtension = item.get_extension();

        var fileDownloadMode = global.getDownloadCheckbox().checked;
        if ((fileDownloadMode == true) && (fileExtension == "jpg" || fileExtension == "gif")) {// Download the file 
            // File is a image document, do not open a new window
            args.set_cancel(true);

            // Tell browser to open file directly
            var requestImage = "Handler.ashx?path=" + item.get_url();
            document.location = requestImage;
        }
    }

    global.OnClientFileOpen = OnClientFileOpen;
})(window);