'use strict';
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

    isDarkTheme = () =>
        this.themeSwitcher.checked;
}

class AutoSaveForm {
    form: HTMLFormElement;
    formInputs: NodeListOf<Element>;
    constructor() {
        this.form = document.querySelector(
            "[data-dsf-form]"
        ) as HTMLFormElement;
        this.formInputs = document.querySelectorAll("[data-dsf-forminput]");
        this.formInputs.forEach((input) => {
            input.addEventListener("blur", this.onSubmitOrBlurEventListener, true);
            input.addEventListener("submit", this.onSubmitOrBlurEventListener, true);
        });
    }
    onSubmitOrBlurEventListener = (event: Event) => {
        console.log(`[data-dsf-forminput] lost focus.`);
     
        this.sendForm();
    };
    sendForm = () => {
        console.log(`Start sending form ${this.form.id}`)
        if (this.form.checkValidity)
            document.forms.namedItem(this.form.id).submit();
    }
}

class CookieAlerter {
    cookieStorageKey: string;
    constructor(cookieAlertId: string, allowCookieButtonId: string, cookieStorageKey: string) {
        this.cookieStorageKey = cookieStorageKey;
        document.getElementById(allowCookieButtonId)?.addEventListener('click', this.allowCookieButtonClickEventListener);
    }
    allowCookieButtonClickEventListener: EventListener = (event: Event) => {
        this.setCookie(true);
    }
    setCookie(cookieAccepted: Boolean) {
        localStorage.setItem(this.cookieStorageKey, cookieAccepted ? "true" : "false");
    }
}

const themeSwitch = new ThemeSwitch();
let autoSaveForm = new AutoSaveForm();
