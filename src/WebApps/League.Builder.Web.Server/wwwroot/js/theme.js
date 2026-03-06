export function getSystemDarkMode() {
    return window.matchMedia("(prefers-color-scheme: dark)").matches;
}