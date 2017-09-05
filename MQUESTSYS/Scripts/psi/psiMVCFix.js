/* 
* for better user experience
* all javascript plugins should be placed below html and css code
* all javascript should be placed inside document ready below html and css code
**/
/*PLUGINS AND INIT*/
function pluginInitDatePicker() {
    /*CALENDAR*/
    window.initDatePicker = function () {
        $("input.datepicker").datepicker({
            dateFormat: 'mm/dd/yy', showOn: 'both', buttonImage: '/Content/Icons/calendar.png',
            buttonImageOnly: true
        });
        $('img.ui-datepicker-trigger').css({ 'margin-left': '2px' });
    }
}
function thousandSeparator(value) {
    return value.replace(/(\d)(?=(\d{3})+\.)/g, "$1,");
}
function pluginInitDecimal() {
    /*INIT DECIMAL*/
    window.initDecimal = function () {
        $(".decimalNumeric").numeric({
            decimal: "."
        });
        $(".decimalNumeric").focus(function () {
            var temp = $(this);
            setTimeout(function () {
                temp.select();
            }, 100);
        });
        $(".integerNumeric").numeric({}, function () { this.value = ""; this.focus(); });
    }
    /*INIT NUMERIC*/
    window.initNumeric = function () {
        $(".decimalNumeric").numeric({
            decimal: "."
        });
        $(".decimalNumeric").focus(function () {
            var temp = $(this);
            setTimeout(function () {
                temp.select();
            }, 100);
        });
        $(".integerNumeric").numeric({}, function () { this.value = ""; this.focus(); });
    }
}
function plugininit() {
    pluginInitDatePicker();
    pluginInitDecimal();
    window.initDatePicker();
    window.initDecimal();
    window.initNumeric();
}

/*LIBRARY*/
function dayRangeCalculate(dateFrom, dateTo) {
    return Math.floor((new Date(dateTo) - new Date(dateFrom)) / (1000 * 60 * 60 * 24));
}
function gridDatePickerRetemplate() {
    $("input[type='hidden'][name$='Template']").each(function (index, obj) {
        $(obj).val($(this).val().replaceAll("style='width:99%;text-align:right;' class='datepicker'", "style='width:70%;text-align:right;' class='datepicker'"));
        var gridName = $(obj).attr('id').replace('Template', '');
        $('table#' + gridName + ' .datepicker').attr('style', 'width: 70%;text-align:right;');
    });
    $('.displayGrid .datepicker').each(function (index, obj) {
        $(obj).attr('style', 'width: 70%; text-align: right;');
    });
}
function objDelayTextAnimation(obj, offset, delay, finishingText, waitingclass, href) {
	obj.removeAttr('href');
	obj.text('Wait ' + (offset / delay) + 's...');
	offset -= delay;
	setTimeout(function () {
		if (offset > 0) {
			obj.fadeOut(100).fadeIn(500);
			objDelayTextAnimation(obj, offset, delay, finishingText, waitingclass, href);
		} else {
			obj.fadeOut(100).fadeIn(500);
			obj.text(finishingText);
			obj.removeClass('disabled');
			obj.attr('href', href);
		}
	}, delay);
}
function setBtnCreateShadow() {
	btnCreate = $('#btnCreate');
	$('#btnCreateShadow').attr('onclick', btnCreate.attr('onclick'));
	btnCreate.removeAttr('onclick');
}
function getListOfDetailItemNo(objIDToSearch){
	objItemNo = [];
	$('[id^=' + objIDToSearch + ']').each(function () {
		obj = $(this);
		ItemNo = obj.attr('id').split('_')[1];
		ItemNoExist = false;
		for (i = 0; i < objItemNo.length; i++)
			if (objItemNo[i] == ItemNo)
				ItemNoExist = true;
		if (!ItemNoExist)
			objItemNo.push(ItemNo);
	});
	return objItemNo;
}
function hideDetailsColumn(objPreText, objPostText, affectedValues, affectedObjPostText) {
    affectedValues = (affectedValues == null) ? [] : affectedValues;
    var listItemNo = getListOfDetailItemNo(objPreText);
    for (var i = 0; i < listItemNo.length; i++) {
        var obj = $('#' + objPreText + listItemNo[i] + objPostText);
        for (var j = 0; j < affectedValues.length; j++)
            if (affectedValues[j].length > 0) {
                if (obj.text() == affectedValues[j] || obj.val() == affectedValues[j])
                    $('#' + objPreText + listItemNo[i] + affectedObjPostText).hide();
            } else {
                if (obj.text().length == 0 && obj.text().length == 0)
                    $('#' + objPreText + listItemNo[i] + affectedObjPostText).hide();
            }
    }
}
function validateDetailsReference(objIDToSearch, preText, postText, emptyText, errorPostText) {
	objItemNo = getListOfDetailItemNo(objIDToSearch);
	validation = true;
	for (i = 0; i < objItemNo.length; i++) {
		obj = $('#' + preText + objItemNo[i] + postText);
		var objError = $('#' + preText + objItemNo[i] + errorPostText);
		if (obj.val() == emptyText) {
			validation = false;
			objError.css('border-color', 'red');
			objError.css('background-color', 'yellow');
		} else {
			objError.css('border-color', '');
			objError.css('background-color', '');
		}
	}
	return validation;
}

/*DOCUMENT READY*/
$(document).ready(function () {
    console.log("%cStop!", "color:red; font-size:60px;");
    console.log("%cThis is a browser feature intended for developers.", "color:black; font-size:30px;");
    plugininit();
    /* CREATING SHADOW BUTTON */
	setBtnCreateShadow();
	/* prevent submitForm twice */
	$("#btnCreate").click(function () {
		var btnCreate = $(this);
		var anyEmptyDetails = false;
		detailsValidatorMember = (detailsValidatorMember instanceof Array) ? detailsValidatorMember : [];
		for (var i = 0; i < detailsValidatorMember.length; i++) {
		    var detailsValidator = detailsValidatorMember[i].split('|');
		    var objSearchText = detailsValidator[0]; /*searchable text*/
		    var preText = detailsValidator[1]; /*id pretext*/
		    var postText = detailsValidator[2]; /*id posttext*/
		    var emptyText = detailsValidator[3]; /*object default value*/
		    var errorPostText = detailsValidator[4]; /*posttext of object to show error*/
		    if (!validateDetailsReference(objSearchText, preText, postText, emptyText, errorPostText)) {
		        anyEmptyDetails = true;
		    }
		}
		if (!anyEmptyDetails) {
			if (!btnCreate.hasClass('disabled')) {
				btnCreate.addClass('disabled');
				objDelayTextAnimation(btnCreate, 10000, 1000, btnCreate.text(), 'disabled', btnCreate.attr('href'));
				$('#btnCreateShadow').click();
			}
		} else {
			alert("yellow column boxes should not be empty.");
		}
	});
    /*PLUGINS*/
	gridDatePickerRetemplate();
});