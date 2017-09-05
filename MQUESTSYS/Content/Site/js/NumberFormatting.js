$(document).ready(function () {
    window.initDatePicker = function () {
        $("input.datepicker").datepicker({
            dateFormat: 'mm/dd/yy', showOn: 'both', buttonImage: '/Content/Icons/calendar.png',
            buttonImageOnly: true
        });
        $('img.ui-datepicker-trigger').css({ 'margin-left': '2px' });
    }
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
        $(".integerNumeric").numeric(false, function () { this.value = ""; this.focus(); });
    }
});