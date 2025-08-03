document.getElementById("searchInput").addEventListener("keyup", function () {
    var filter = this.value.toUpperCase();
    var cards = document.querySelectorAll(".client-card-item");

    cards.forEach(card => {
        let text = card.innerText.toUpperCase();
        card.style.display = text.includes(filter) ? "" : "none";
    });
});