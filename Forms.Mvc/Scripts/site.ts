class ThemeSwitch {
    constructor() {
        this.themeSwitcher.addEventListener("click", (event) => {
            localStorage.setItem(
                "theme",
                this.themeSwitcher.checked ? "dark" : "light"
            );
            this.checkTheme();
        });
        this.checkTheme();
    }

    /** Color scheme that browser prefer. */
    scheme = window.matchMedia("(prefers-color-scheme: dark)");
    /** Element at layout that id used to switch themes. */
    themeSwitcher = document.getElementById(
        "themeSwitcher"
    ) as HTMLInputElement;
    /** Label that represents the text of themeSwitcher while there is light theme turned on. */
    lightLabel =
        document.getElementById("onLightThemeSwitchLabel") ?? new HTMLElement();
    /** Label that represents the text of themeSwitcher while there is dark theme turned on. */
    darkLabel =
        document.getElementById("onDarkThemeSwitchLabel") ?? new HTMLElement();

    /**
     * Sets current theme.
     * @param theme Name of new theme.
     */
    setTheme = (theme: string) => {
        document.body.setAttribute("data-bs-theme", theme);

        this.switchLabels(theme == "dark");

        console.log(`Set ${theme} theme`);
    };
    switchLabels = (isDarkTheme: boolean) => {
        this.lightLabel.hidden = isDarkTheme;
        this.darkLabel.hidden = !isDarkTheme;
    };
    changeSchemeEventListener = (event: MediaQueryListEvent) => {
        this.setTheme(event.matches ? "dark" : "light");
    };
    /**
     * Checks and sets current theme.
     */
    checkTheme = () => {
        if (localStorage.getItem("theme")) {
            const theme = localStorage.getItem("theme") ?? "";
            this.setTheme(theme);
            this.themeSwitcher.checked = theme == "dark";

            this.scheme.removeEventListener(
                "change",
                this.changeSchemeEventListener,
                true
            );

            console.log(`Set ${theme} theme from storage`);
        } else {
            this.setTheme(this.scheme.matches ? "dark" : "light");

            this.scheme.addEventListener(
                "change",
                this.changeSchemeEventListener,
                true
            );
        }
    };
}

let themeSwitch = new ThemeSwitch();
