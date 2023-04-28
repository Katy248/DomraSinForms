var _a, _b;
var scheme = window.matchMedia("(prefers-color-scheme: dark)");
var themeSwitcher = document.getElementById("themeSwitcher");
var lightLabel = (_a = document.getElementById("onLightThemeSwitchLabel")) !== null && _a !== void 0 ? _a : new HTMLElement();
var darkLabel = (_b = document.getElementById("onDarkThemeSwitchLabel")) !== null && _b !== void 0 ? _b : new HTMLElement();
var setTheme = function (theme) {
    document.body.setAttribute("data-bs-theme", theme);
    if (theme == "dark") {
        lightLabel.hidden = true;
        darkLabel.hidden = false;
    }
    else {
        lightLabel.hidden = false;
        darkLabel.hidden = true;
    }
    console.log("Set ".concat(theme, " theme"));
};
var changeSchemeEventListener = function (event) {
    setTheme(event.matches ? "dark" : "light");
};
var checkTheme = function () {
    var _a;
    if (localStorage.getItem("theme")) {
        var theme = (_a = localStorage.getItem("theme")) !== null && _a !== void 0 ? _a : "";
        setTheme(theme);
        themeSwitcher.checked = theme == "dark";
        scheme.removeEventListener('change', changeSchemeEventListener, true);
        console.log("Set ".concat(theme, " theme from storage"));
    }
    else {
        setTheme(scheme.matches ? "dark" : "light");
        scheme.addEventListener("change", changeSchemeEventListener, true);
    }
};
themeSwitcher.addEventListener("click", function (event) {
    localStorage.setItem("theme", themeSwitcher.checked ? "dark" : "light");
    checkTheme();
});
checkTheme();
//# sourceMappingURL=site.js.map