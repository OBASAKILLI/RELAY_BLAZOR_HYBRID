
function getDeviceCategory() {
    const width = window.innerWidth;

    if (width <= 767) {
        return "Mobile";
    } else if (width <= 1024) {
        return "Tablet";
    } else {
        return "Desktop";
    }
}

function registerResizeHandler(dotNetHelper) {
    window.addEventListener("resize", () => {
        dotNetHelper.invokeMethodAsync("OnResizeHandler");
    });
}
