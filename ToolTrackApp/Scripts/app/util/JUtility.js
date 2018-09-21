// Funcíon para leer un archivo de mensajes JSON y obtener el objeto deserializado, para que funcione debe estar ubicado en la carpeta "Scripts/Json
// nameFile: nombre del archivo json a leer sin la extención
// loadLanguages es una variable booleana que indica si es para cargar el json de mensajes de idioma, si es false es para cualquier otro JSON
function lee_json(nameFile, loadLanguages) {
    

    var data = {};

    var _json = readJson(nameFile, data)

    //Si se estan cargando los mensajes del idioma es decir el JSON para los mensajes generales de idioma si la respuesta de la primera lectura es facil leemos obligatoriamente el archivo de español colombia
    if (loadLanguages && _json.status != 200)
        readJson("Scripts/JsonMsg/mensajes-es-CO", data);

    return data;

    //Función para leer el json se crea interna por si es necesario hacer el segundo llamado, el cual llama a un archivo de mensajes que existe.
    function readJson(pathFile, data) {
        $.ajaxSetup({ async: false });
        var json = $.getJSON(window.pathToActionJson + pathFile + ".json", function (datos) {
            $.extend(data, datos);
        });
        return json;
    }
}

//Función para realizar una peticíon ajax 
function AjaxAction(actionName, controllerName, arrayData, fnDelegate, fnParameters) {
    var ajax = $.Obd2Ajax(actionName, controllerName, arrayData, fnDelegate, fnParameters);
}

(function ($) {
    /*******************************************************************************    
    Autor: Bryan Felipe Garcia Collazos    
    Fecha: 01/07/2016    
    Descripción: Realiza una petición Ajax

    Como parámetros recibe:
    actionName: Acción del controlador asociado a la solicitud Ajax desde el cliente.
    controllerName: Controlador al que esta asociado la solicitud Ajax.
    arrayData: Datos que recibe la acción al que se esta dirigiendo la solicitud Ajax.
    fnDelegate: Función que se ejecutara una vez llegue de realizar la solicitud y su ejecución en servidor haya sido exitosa.
    fnParameters: Parametros adicionales que se pueden enviar a la fnDelegate por si es requerido pasar algun parámetro a la función
    fnError: Función que se ejecutara si el proceso llegase a fallar en algún momento.
    ********************************************************************************/
    $.Obd2Ajax = function (actionName, controllerName, arrayData, fnDelegate, fnParameters, fnError) {
        var ajaxRequest = $.ajax({
            url: GetUrl(actionName, controllerName),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            type: "POST",
            data: JSON.stringify(arrayData),
            beforeSend: function (xhr) {
                xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
                return xhr;
            },
            success: function (data, qXHR, p2) {
                if (p2.getResponseHeader("error")) {
                    alert(data);
                    return;
                }
                if (data.ErrorHandler) {
                    alert(data.ErrorHandler);
                    return;
                }
                fnDelegate && fnDelegate(data, fnParameters);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (fnError == undefined || fnError == null) {
                    alert(errorThrown);
                }
                else {
                    fnError();
                }
            },
            async: true
        });
        return ajaxRequest;
    }
})(jQuery);