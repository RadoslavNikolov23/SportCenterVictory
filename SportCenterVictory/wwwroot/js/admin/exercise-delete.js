document.addEventListener("DOMContentLoaded", function () {
    const container = document.getElementById("exerciseTableContainer");
    const searchInput = document.getElementById("searchInput");
    const searchBtn = document.getElementById("searchBtn");

    function loadData(page = 1, searchTerm = "") {
        const url = `?page=${page}&searchTerm=${encodeURIComponent(searchTerm)}`;
        fetch(url, { headers: { "X-Requested-With": "XMLHttpRequest" } })
            .then(res => res.text())
            .then(html => {
                container.innerHTML = html;
                attachPaginationLinks();
            })
            .catch(console.error);
    }

    function attachPaginationLinks() {
        container.querySelectorAll(".pagination a").forEach(link => {
            link.addEventListener("click", e => {
                e.preventDefault();
                const urlParams = new URL(link.href).searchParams;
                const page = urlParams.get("page") || 1;
                loadData(page, searchInput.value.trim());
            });
        });
    }

    searchBtn.addEventListener("click", () => {
        loadData(1, searchInput.value.trim());
    });

    searchInput.addEventListener("keyup", (e) => {
        if (e.key === "Enter") {
            searchBtn.click();
        }
    });

    attachPaginationLinks();
});