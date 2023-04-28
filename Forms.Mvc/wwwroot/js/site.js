
const setTheme = (theme) => {
    document.body.setAttribute("data-bs-theme", theme);

    if (theme == 'dark') {
        document.getElementById('onLightThemeSwitchLabel').hidden = true;
        document.getElementById('onDarkThemeSwitchLabel').hidden = false;
    } else {
        document.getElementById('onLightThemeSwitchLabel').hidden = false;
        document.getElementById('onDarkThemeSwitchLabel').hidden = true;
    }

    console.log(`Set ${theme} theme`);
}

const scheme = window.matchMedia('(prefers-color-scheme: dark)');
const themeSwitcher = document.getElementById('themeSwitcher');

themeSwitcher.addEventListener('click', event => {
    localStorage.setItem('theme', themeSwitcher.checked ? 'dark' : 'light');
    checkTheme();
});

checkTheme = () => {
    if (localStorage.getItem('theme')) {
        const theme = localStorage.getItem('theme')
        setTheme(theme);
        themeSwitcher.checked = theme == 'dark';
        console.log(`Set ${theme} theme from storage`);
    } else {
        setTheme(scheme.matches ? 'dark' : 'light');

        scheme.addEventListener('change', event => {
            setTheme(event.matches ? 'dark' : 'light');
        });
    }
}

checkTheme();