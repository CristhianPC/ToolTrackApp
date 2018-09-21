//Si posee el atributo NoPoint en 1 no permite digitar el punto (.)
$(document).ready(function () {
    $(".numericOnly").on("keypress", function () {
        var tecla = window.event.keyCode;
        if ((tecla >= 48 && tecla <= 57) || tecla == 46) {
            if ($(this).attr("nopoint") == "1" && tecla == 46) {
                return false;
            }
            var splitXPunto = $(this).val().split(".");
            if (tecla == 46 && splitXPunto[1] != undefined) {
                return false;
            }
        }
        else {
            tecla = String.fromCharCode(tecla);
            if (!((tecla >= "0") && (tecla <= "9"))) {
                if ($(this).attr("negativo") == "1" && tecla == "-") {
                    if ($(this).val() != "") {
                        split = $(this).val().split("-");
                        if (split[1] != undefined) {
                            return false;
                        }
                    }
                }
                else {
                    return false
                }
            }
        }
    });
});