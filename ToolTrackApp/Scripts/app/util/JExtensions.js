Object.defineProperty(Array.prototype, "find", {
    enumerable: false,
    writable: false,
    configurable: false,
    value: function (callback) {
        'use strict';
        var T, k;

        //Se verifica que el this no sea null;
        if (this == null) {
            throw new TypeError("this is null or not defined");
        }

        //Se verifica que el parametro callback sea una función
        if ({
        }.toString.call(callback) !== "[object Function]") {
            throw new TypeError(callback + " is not a function");
        }


        var kValue,
            O = Object(this),
            len = O.length >>> 0;

        k = 0;
        var _elem = null;

        while (k < len) {
            kValue = O[k];
            var elem = callback.call(T, kValue, k);
            if (elem) {
                _elem = kValue;
                break;
            }
            k++;
        }
        return _elem;
    }
})