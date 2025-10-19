export function initialize(dotNetReference, tableHtmlId, idFieldClass) {
    const selector = `#${tableHtmlId}`;

    document.querySelector(selector).addEventListener("click", function (event) {
        const row = event.target.closest("tr");
        if (row) {
            const td = row.querySelector(`.${idFieldClass}`);
                const value = td.textContent.trim();
            dotNetReference.invokeMethodAsync("HandleRowClickedAsync", value);
            }
    });
}