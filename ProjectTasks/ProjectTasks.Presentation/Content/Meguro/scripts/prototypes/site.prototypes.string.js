String.prototype.format = function () {
    var s = this;
    for (var i = 0; i < arguments.length; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i]);
    }

    return s;
};

String.prototype.toDate = function () {
    if (!(this && this.length > 6)) {
        return '';
    }
    return new Date(parseInt(this.substr(6)));
};