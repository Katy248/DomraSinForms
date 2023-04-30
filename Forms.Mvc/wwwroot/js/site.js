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
var themeSwitch = new ThemeSwitch();
//# sourceMappingURL=site.js.map