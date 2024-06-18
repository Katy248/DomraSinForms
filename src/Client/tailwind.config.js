/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./Components/*/**.razor"],
    theme: {
        extend: {
            colors:{
                "fg": "#101212",
                "primary": "#e3faf6",
                "secondary": "#8d08b1",
                "success": "#95d214",
                "warning": "#e7cd36",
                "danger": "#d87f54",
                "info": "#2babdd"
            }
        },
    },
    plugins: [],
}

