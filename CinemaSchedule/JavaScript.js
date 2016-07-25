$(function () { if ($('.search-bar-field').find('input[type=text]').val().toLowerCase().indexOf("htc") >= 0) { $('.search-bar-field').append('<div class="search-results"><div><h4><strong><a href="http://s020.radikal.ru/i714/1607/c9/59a13024bdbd.jpg"><img src="http://s020.radikal.ru/i714/1607/c9/59a13024bdbd.jpg"></a></strong></h4></div></div>'); } });

$(function () { if ($('.search-bar-field').find('input[type=text]').val().toLowerCase().indexOf("htc") >= 0) { $('.search-items').prepend('<div class="card"><div class="search-item-card"><h4><strong><a href="http://s018.radikal.ru/i507/1607/7f/ed949914aac2.jpg"><img src="http://s018.radikal.ru/i507/1607/7f/ed949914aac2.jpg" style="margin-top: 8px; margin-left: 8px;"></a></strong></h4></div></div>'); } });

$(function () {
    if ($('.search-bar-field').find('input[type=text]').val() !== undefined && $('.search-bar-field').find('input[type=text]').val().toLowerCase().indexOf("htc") >= 0) {
        $('.search-bar-field').append('<div style="margin-top:20px;"><a href="//beeline.ru/shop/details/smartfon-htc-desire-628-sunset-blue/4g-smartfon-htc-desire-628-s-paketom-uslug/"><img src="http://static.beeline.ru/upload/images/promo/akcii/htc/htc_banner1.ru.jpg?t=1469446134972"></a></div>');
    }
});

$(function () {
    if ($('.search-bar-field').find('input[type=text]').val() !== undefined && $('.search-bar-field').find('input[type=text]').val().toLowerCase().indexOf("htc") >= 0) {
        $('.search-items').prepend('<div class="card"><div class="search-item-card"><a href="//beeline.ru/shop/details/smartfon-htc-desire-628-sunset-blue/4g-smartfon-htc-desire-628-s-paketom-uslug/"><img style="margin: 2px 0; width: 711px;" src="http://static.beeline.ru/upload/images/promo/akcii/htc/htc_banner2.ru.jpg?t=1469446134972"></a></div></div>');
    }
}
);

$(function () {
    function getParameterByName(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }
    var val = getParameterByName('query');
    if (val !== null && val.toLowerCase().indexOf("htc") >= 0) {
        $('.search-bar-field').append('<div style="margin-top:20px;"><a href="//beeline.ru/shop/details/smartfon-htc-desire-628-sunset-blue/4g-smartfon-htc-desire-628-s-paketom-uslug/"><img src="http://static.beeline.ru/upload/images/promo/akcii/htc/htc_banner1.ru.jpg?t=1469446134972"></a></div>');
    }
});

$(function () {
    function getParameterByName(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }
    var val = getParameterByName('query');
    if (val !== null && val.toLowerCase().indexOf("htc") >= 0) {
        $('.search-items').prepend('<div class="card"><div class="search-item-card"><a href="//beeline.ru/shop/details/smartfon-htc-desire-628-sunset-blue/4g-smartfon-htc-desire-628-s-paketom-uslug/"><img style="margin: 2px 0; width: 711px;" src="http://static.beeline.ru/upload/images/promo/akcii/htc/htc_banner2.ru.jpg?t=1469446134972"></a></div></div>');
    }
});