/** Color scheme that browser prefer. */
const scheme = window.matchMedia("(prefers-color-scheme: dark)");
/** Element at layout that id used to switch themes. */
const themeSwitcher = document.getElementById("themeSwitcher") as HTMLInputElement;
/** Label that represents the text of themeSwitcher while there is light theme turned on. */
const lightLabel = document.getElementById("onLightThemeSwitchLabel") ?? new HTMLElement();
/** Label that represents the text of themeSwitcher while there is dark theme turned on. */
const darkLabel = document.getElementById("onDarkThemeSwitchLabel") ?? new HTMLElement();

/**
 * Sets current theme.
 * @param theme Name of new theme.
 */
let setTheme = (theme: string) => {
    document.body.setAttribute("data-bs-theme", theme);

    if (theme == "dark") {
        lightLabel.hidden = true;
        darkLabel.hidden = false;
    } else {
        lightLabel.hidden = false;
        darkLabel.hidden = true;
    }

    console.log(`Set ${theme} theme`);
};
let changeSchemeEventListener = (event: MediaQueryListEvent) => {
    setTheme(event.matches ? "dark" : "light");
}
/**
 * Checks and sets current theme.
 */
let checkTheme = () => {
    if (localStorage.getItem("theme")) {
        const theme = localStorage.getItem("theme") ?? "";
        setTheme(theme);
        themeSwitcher.checked = theme == "dark";
        
        scheme.removeEventListener('change', changeSchemeEventListener, true);

        console.log(`Set ${theme} theme from storage`);
    } else {
        setTheme(scheme.matches ? "dark" : "light");

        scheme.addEventListener("change", changeSchemeEventListener, true);
    }
}

themeSwitcher.addEventListener("click", (event) => {
    localStorage.setItem("theme", themeSwitcher.checked ? "dark" : "light");
    checkTheme();
});



checkTheme();
