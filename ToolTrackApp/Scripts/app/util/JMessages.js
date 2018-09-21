function obd2Alert(title, message, type) {
    swal({
        title: title,
        text: message,
        type: type || "warning",
        confirmButtonText: window.languageMessages.Region.msjNoDataPaths.ok
    })
}
