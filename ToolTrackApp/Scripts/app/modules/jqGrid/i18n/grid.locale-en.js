/**
 * jqGrid English Translation
 * Tony Tomov tony@trirand.com
 * http://trirand.com/blog/ 
 * Dual licensed under the MIT and GPL licenses:
 * http://www.opensource.org/licenses/mit-license.php
 * http://www.gnu.org/licenses/gpl.html
**/
/*global jQuery, define */
(function( factory ) {
	"use strict";
	if ( typeof define === "function" && define.amd ) {
		// AMD. Register as an anonymous module.
		define([
			"jquery",
			"../grid.base"
		], factory );
	} else {
		// Browser globals
		factory( jQuery );
	}
}(function( $ ) {

$.jgrid = $.jgrid || {};
if(!$.jgrid.hasOwnProperty("Regional")) {
	$.jgrid.Regional = [];
}
$.jgrid.Regional["en"] = {
	defaults : {
		recordtext: "View {0} - {1} of {2}",
		emptyrecords: "No records to view",
		loadtext: "Loading...",
		savetext: "Saving...",
		pgtext : "Page {0} of {1}",
		pgfirst : "First Page",
		pglast : "Last Page",
		pgnext : "Next Page",
		pgprev : "Previous Page",
		pgrecs : "Records per Page",
		showhide: "Toggle Expand Collapse Grid",
		// mobile
		pagerCaption : "Grid::Page Settings",
		pageText : "Page:",
		recordPage : "Records per Page",
		nomorerecs : "No more records...",
		scrollPullup: "Pull up to load more...",
		scrollPulldown : "Pull down to refresh...",
		scrollRefresh : "Release to refresh..."
	},
	search : {
		caption: "Search...",
		Find: "Find",
		Reset: "Reset",
		odata: [{ oper:'eq', text:'equal'},{ oper:'ne', text:'not equal'},{ oper:'lt', text:'less'},{ oper:'le', text:'less or equal'},{ oper:'gt', text:'greater'},{ oper:'ge', text:'greater or equal'},{ oper:'bw', text:'begins with'},{ oper:'bn', text:'does not begin with'},{ oper:'in', text:'is in'},{ oper:'ni', text:'is not in'},{ oper:'ew', text:'ends with'},{ oper:'en', text:'does not end with'},{ oper:'cn', text:'contains'},{ oper:'nc', text:'does not contain'},{ oper:'nu', text:'is null'},{ oper:'nn', text:'is not null'}],
		groupOps: [{ op: "AND", text: "all" },{ op: "OR",  text: "any" }],
		operandTitle : "Click to select search operation.",
		resetTitle : "Reset Search Value"
	},
	edit : {
		addCaption: "Add Record",
		editCaption: "Edit Record",
		bSubmit: "Submit",
		bCancel: "Cancel",
		bClose: "Close",
		saveData: "Data has been changed! Save changes?",
		bYes : "Yes",
		bNo : "No",
		bExit : "Cancel",
		msg: {
			required:"Field is required",
			number:"Please, enter valid number",
			minValue:"value must be greater than or equal to ",
			maxValue:"value must be less than or equal to",
			email: "is not a valid e-mail",
			integer: "Please, enter valid integer value",
			date: "Please, enter valid date value",
			url: "is not a valid URL. Prefix required ('http://' or 'https://')",
			nodefined : " is not defined!",
			novalue : " return value is required!",
			customarray : "Custom function should return array!",
			customfcheck : "Custom function should be present in case of custom checking!"
			
		}
	},
	view : {
		caption: "View Record",
		bClose: "Close"
	},
	del : {
		caption: "Delete",
		msg: "Delete selected record(s)?",
		bSubmit: "Delete",
		bCancel: "Cancel"
	},
	nav : {
		edittext: "",
		edittitle: "Edit selected row",
		addtext:"",
		addtitle: "Add new row",
		deltext: "",
		deltitle: "Delete selected row",
		searchtext: "",
		searchtitle: "Find records",
		refreshtext: "",
		refreshtitle: "Reload Grid",
		alertcap: "Warning",
		alerttext: "Please, select row",
		viewtext: "",
		viewtitle: "View selected row",
		savetext: "",
		savetitle: "Save row",
		canceltext: "",
		canceltitle : "Cancel row editing",
		selectcaption : "Actions..."
	},
	col : {
		caption: "Select columns",
		bSubmit: "Ok",
		bCancel: "Cancel"
	},
	errors : {
		errcap : "Error",
		nourl : "No url is set",
		norecords: "No records to process",
		model : "Length of colNames <> colModel!"
	},
	formatter : {
		integer : {thousandsSeparator: ",", defaultValue: '0'},
		number : {decimalSeparator:".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00'},
		currency : {decimalSeparator:".", thousandsSeparator: ",", decimalPlaces: 2, prefix: "", suffix:"", defaultValue: '0.00'},
		date : {
			dayNames:   [
				"Sun", "Mon", "Tue", "Wed", "Thr", "Fri", "Sat",
				"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
			],
			monthNames: [
				"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
				"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
			],
			AmPm : ["am","pm","AM","PM"],
			S: function (j) {return j < 11 || j > 13 ? ['st', 'nd', 'rd', 'th'][Math.min((j - 1) % 10, 3)] : 'th';},
			srcformat: 'Y-m-d',
			newformat: 'n/j/Y',
			parseRe : /[#%\\\/:_;.,\t\s-]/,
			masks : {
				// see http://php.net/manual/en/function.date.php for PHP format used in jqGrid
				// and see http://docs.jquery.com/UI/Datepicker/formatDate
				// and https://github.com/jquery/globalize#dates for alternative formats used frequently
				// one can find on https://github.com/jquery/globalize/tree/master/lib/cultures many
				// information about date, time, numbers and currency formats used in different countries
				// one should just convert the information in PHP format
				ISO8601Long:"Y-m-d H:i:s",
				ISO8601Short:"Y-m-d",
				// short date:
				//    n - Numeric representation of a month, without leading zeros
				//    j - Day of the month without leading zeros
				//    Y - A full numeric representation of a year, 4 digits
				// example: 3/1/2012 which means 1 March 2012
				ShortDate: "n/j/Y", // in jQuery UI Datepicker: "M/d/yyyy"
				// long date:
				//    l - A full textual representation of the day of the week
				//    F - A full textual representation of a month
				//    d - Day of the month, 2 digits with leading zeros
				//    Y - A full numeric representation of a year, 4 digits
				LongDate: "l, F d, Y", // in jQuery UI Datepicker: "dddd, MMMM dd, yyyy"
				// long date with long time:
				//    l - A full textual representation of the day of the week
				//    F - A full textual representation of a month
				//    d - Day of the month, 2 digits with leading zeros
				//    Y - A full numeric representation of a year, 4 digits
				//    g - 12-hour format of an hour without leading zeros
				//    i - Minutes with leading zeros
				//    s - Seconds, with leading zeros
				//    A - Uppercase Ante meridiem and Post meridiem (AM or PM)
				FullDateTime: "l, F d, Y g:i:s A", // in jQuery UI Datepicker: "dddd, MMMM dd, yyyy h:mm:ss tt"
				// month day:
				//    F - A full textual representation of a month
				//    d - Day of the month, 2 digits with leading zeros
				MonthDay: "F d", // in jQuery UI Datepicker: "MMMM dd"
				// short time (without seconds)
				//    g - 12-hour format of an hour without leading zeros
				//    i - Minutes with leading zeros
				//    A - Uppercase Ante meridiem and Post meridiem (AM or PM)
				ShortTime: "g:i A", // in jQuery UI Datepicker: "h:mm tt"
				// long time (with seconds)
				//    g - 12-hour format of an hour without leading zeros
				//    i - Minutes with leading zeros
				//    s - Seconds, with leading zeros
				//    A - Uppercase Ante meridiem and Post meridiem (AM or PM)
				LongTime: "g:i:s A", // in jQuery UI Datepicker: "h:mm:ss tt"
				SortableDateTime: "Y-m-d\\TH:i:s",
				UniversalSortableDateTime: "Y-m-d H:i:sO",
				// month with year
				//    Y - A full numeric representation of a year, 4 digits
				//    F - A full textual representation of a month
				YearMonth: "F, Y" // in jQuery UI Datepicker: "MMMM, yyyy"
			},
			reformatAfterEdit : false,
			userLocalTime : false
		},
		baseLinkUrl: '',
		showAction: '',
		target: '',
		checkbox : {disabled:true},
		idName : 'id'
	}
};
$.jgrid.Regional["es"] = {
    defaults: {
        recordtext: "Mostrando {0} - {1} de {2}",
        emptyrecords: "Sin registros que mostrar",
        loadtext: "Cargando...",
        savetext: "Guardando...",
        pgtext: "P\u00e1gina {0} de {1}",
        pgfirst: "Primera P\u00e1gina",
        pglast: "Última P\u00e1gina",
        pgnext: "Siguiente P\u00e1gina",
        pgprev: "Anterior P\u00e1gina",
        pgrecs: "Registros por P\u00e1gina",
        showhide: "Alternar Contraer Expandir Grid",
        // mobile
        pagerCaption: "Grid::Configurar P\u00e1gina",
        pageText: "P\u00e1gina:",
        recordPage: "Registros por P\u00e1gina",
        nomorerecs: "No m\u00e1s registros...",
        scrollPullup: "Arrastrar arriba para cargar m\u00e1s...",
        scrollPulldown: "Arrastrar arriba para refrescar...",
        scrollRefresh: "Soltar para refrescar..."
    },
    search: {
        caption: "Búsqueda...",
        Find: "Buscar",
        Reset: "Limpiar",
        odata: [{ oper: 'eq', text: "igual " }, { oper: 'ne', text: "no igual a" }, { oper: 'lt', text: "menor que" }, { oper: 'le', text: "menor o igual que" }, { oper: 'gt', text: "mayor que" }, { oper: 'ge', text: "mayor o igual a" }, { oper: 'bw', text: "empiece por" }, { oper: 'bn', text: "no empiece por" }, { oper: 'in', text: "est\u00e1 en" }, { oper: 'ni', text: "no est\u00e1 en" }, { oper: 'ew', text: "termina por" }, { oper: 'en', text: "no termina por" }, { oper: 'cn', text: "contiene" }, { oper: 'nc', text: "no contiene" }, { oper: 'nu', text: 'is null' }, { oper: 'nn', text: 'is not null' }, { oper: 'bt', text: 'between' }],
        groupOps: [{ op: "AND", text: "todo" }, { op: "OR", text: "cualquier" }],
        operandTitle: "Click para seleccionar la operación de búsqueda.",
        resetTitle: "Resetear valor de Búsqueda",
        addsubgrup: "Add subgroup",
        addrule: "Add rule",
        delgroup: "Delete group",
        delrule: "Delete rule"
    },
    edit: {
        addCaption: "Agregar registro",
        editCaption: "Modificar registro",
        bSubmit: "Guardar",
        bCancel: "Cancelar",
        bClose: "Cerrar",
        saveData: "Se han modificado los datos, ¿guardar cambios?",
        bYes: "Si",
        bNo: "No",
        bExit: "Cancelar",
        msg: {
            required: "Campo obligatorio",
            number: "Introduzca un número",
            minValue: "El valor debe ser mayor o igual a ",
            maxValue: "El valor debe ser menor o igual a ",
            email: "no es una dirección de correo v\u00e1lida",
            integer: "Introduzca un valor entero",
            date: "Introduza una fecha correcta ",
            url: "no es una URL v\u00e1lida. Prefijo requerido ('http://' or 'https://')",
            nodefined: " no est\u00e1 definido.",
            novalue: " valor de retorno es requerido.",
            customarray: "La función personalizada debe devolver un array.",
            customfcheck: "La función personalizada debe estar presente en el caso de validación personalizada."
        }
    },
    view: {
        caption: "Consultar registro",
        bClose: "Cerrar"
    },
    del: {
        caption: "Eliminar",
        msg: "¿Desea eliminar los registros seleccionados?",
        bSubmit: "Eliminar",
        bCancel: "Cancelar"
    },
    nav: {
        edittext: " ",
        edittitle: "Modificar fila seleccionada",
        addtext: " ",
        addtitle: "Agregar nueva fila",
        deltext: " ",
        deltitle: "Eliminar fila seleccionada",
        searchtext: " ",
        searchtitle: "Buscar información",
        refreshtext: "",
        refreshtitle: "Recargar datos",
        alertcap: "Aviso",
        alerttext: "Seleccione una fila",
        viewtext: "",
        viewtitle: "Ver fila seleccionada",
        savetext: "",
        savetitle: "Guardar fila",
        canceltext: "",
        canceltitle: "Cancelar edición de fila",
        selectcaption: "Actions..."
    },
    col: {
        caption: "Mostrar/ocultar columnas",
        bSubmit: "Enviar",
        bCancel: "Cancelar"
    },
    errors: {
        errcap: "Error",
        nourl: "No se ha especificado una URL",
        norecords: "No hay datos para procesar",
        model: "Las columnas de nombres son diferentes de las columnas de modelo"
    },
    formatter: {
        integer: { thousandsSeparator: ".", defaultValue: '0' },
        number: { decimalSeparator: ",", thousandsSeparator: ".", decimalPlaces: 2, defaultValue: '0,00' },
        currency: { decimalSeparator: ",", thousandsSeparator: ".", decimalPlaces: 2, prefix: "", suffix: "", defaultValue: '0,00' },
        date: {
            dayNames: [
				"Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa",
				"Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"
            ],
            monthNames: [
				"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic",
				"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            ],
            AmPm: ["am", "pm", "AM", "PM"],
            S: function (j) { return j < 11 || j > 13 ? ['st', 'nd', 'rd', 'th'][Math.min((j - 1) % 10, 3)] : 'th' },
            srcformat: 'Y-m-d',
            newformat: 'd-m-Y',
            parseRe: /[#%\\\/:_;.,\t\s-]/,
            masks: {
                ISO8601Long: "Y-m-d H:i:s",
                ISO8601Short: "Y-m-d",
                ShortDate: "n/j/Y",
                LongDate: "l, F d, Y",
                FullDateTime: "l, F d, Y g:i:s A",
                MonthDay: "F d",
                ShortTime: "g:i A",
                LongTime: "g:i:s A",
                SortableDateTime: "Y-m-d\\TH:i:s",
                UniversalSortableDateTime: "Y-m-d H:i:sO",
                YearMonth: "F, Y"
            },
            reformatAfterEdit: false,
            userLocalTime: false
        },
        baseLinkUrl: '',
        showAction: '',
        target: '',
        checkbox: { disabled: true },
        idName: 'id'
    },
    colmenu: {
        sortasc: "Sort Ascending",
        sortdesc: "Sort Descending",
        columns: "Columns",
        filter: "Filter",
        grouping: "Group By",
        ungrouping: "Ungroup",
        searchTitle: "Get items with value that:",
        freeze: "Freeze",
        unfreeze: "Unfreeze",
        reorder: "Move to reorder"
    }
};
}));
