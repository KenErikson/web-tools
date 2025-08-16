// This function takes text and writes it to the user's clipboard.
window.copyTextToClipboard = (text) => {
    return navigator.clipboard.writeText(text);
};