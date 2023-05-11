'use strict';
var ThemeSwitch = (function () {
    function ThemeSwitch() {
        var _this = this;
        var _a, _b;
        this.scheme = window.matchMedia("(prefers-color-scheme: dark)");
        this.themeSwitcher = document.getElementById("themeSwitcher");
        this.lightLabel = (_a = document.getElementById("onLightThemeSwitchLabel")) !== null && _a !== void 0 ? _a : new HTMLElement();
        this.darkLabel = (_b = document.getElementById("onDarkThemeSwitchLabel")) !== null && _b !== void 0 ? _b : new HTMLElement();
        this.setTheme = function (theme) {
            document.body.setAttribute("data-bs-theme", theme);
            _this.switchLabels(theme == "dark");
            console.log("Set ".concat(theme, " theme"));
        };
        this.switchLabels = function (isDarkTheme) {
            _this.lightLabel.hidden = isDarkTheme;
            _this.darkLabel.hidden = !isDarkTheme;
        };
        this.changeSchemeEventListener = function (event) {
            _this.setTheme(event.matches ? "dark" : "light");
        };
        this.checkTheme = function () {
            var _a;
            if (localStorage.getItem("theme")) {
                var theme = (_a = localStorage.getItem("theme")) !== null && _a !== void 0 ? _a : "";
                _this.setTheme(theme);
                _this.themeSwitcher.checked = theme == "dark";
                _this.scheme.removeEventListener("change", _this.changeSchemeEventListener, true);
                console.log("Set ".concat(theme, " theme from storage"));
            }
            else {
                _this.setTheme(_this.scheme.matches ? "dark" : "light");
                _this.scheme.addEventListener("change", _this.changeSchemeEventListener, true);
            }
        };
        this.themeSwitcher.addEventListener("click", function (event) {
            localStorage.setItem("theme", _this.themeSwitcher.checked ? "dark" : "light");
            _this.checkTheme();
        });
        this.checkTheme();
    }
    return ThemeSwitch;
}());
var AutoSaveForm = (function () {
    function AutoSaveForm() {
        var _this = this;
        this.onSubmitOrBlurEventListener = function (event) {
            console.log("[data-dsf-forminput] lost focus.");
            _this.sendForm();
        };
        this.sendForm = function () {
            console.log("Start sending form ".concat(_this.form.id));
            if (_this.form.checkValidity)
                document.forms.namedItem(_this.form.id).submit();
        };
        this.form = document.querySelector("[data-dsf-form]");
        this.formInputs = document.querySelectorAll("[data-dsf-forminput]");
        this.formInputs.forEach(function (input) {
            input.addEventListener("blur", _this.onSubmitOrBlurEventListener, true);
            input.addEventListener("submit", _this.onSubmitOrBlurEventListener, true);
        });
    }
    return AutoSaveForm;
}());
var CookieAlerter = (function () {
    function CookieAlerter(cookieAlertId, allowCookieButtonId, cookieStorageKey) {
        var _this = this;
        var _a;
        this.allowCookieButtonClickEventListener = function (event) {
            _this.setCookie(true);
        };
        this.cookieStorageKey = cookieStorageKey;
        (_a = document.getElementById(allowCookieButtonId)) === null || _a === void 0 ? void 0 : _a.addEventListener('click', this.allowCookieButtonClickEventListener);
    }
    CookieAlerter.prototype.setCookie = function (cookieAccepted) {
        localStorage.setItem(this.cookieStorageKey, cookieAccepted ? "true" : "false");
    };
    return CookieAlerter;
}());
var themeSwitch = new ThemeSwitch();
var autoSaveForm = new AutoSaveForm();
//# sourceMappingURL=site.js.map