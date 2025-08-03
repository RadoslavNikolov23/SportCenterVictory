let currentIndex = 0;
let wodList = [];

async function loadWodList() {
    const response = await fetch('/Crossfit/CrossFitWODList');
    wodList = await response.json();

    // Find current index by comparing title
    currentIndex = wodList.findIndex(w => w.name === currentWodName);

    updateButtons();
}

async function loadWodByIndex(index) {
    const wod = wodList[index];
    const res = await fetch(`/Crossfit/CrossFitWODById?id=${wod.id}`);
    const data = await res.json();

    document.getElementById('wodTitle').textContent = data.name;
    document.getElementById('wodContent').innerHTML = data.descriptionHTML;
    currentIndex = index;

    updateButtons();
}

function updateButtons() {
    document.getElementById('prevBtn').disabled = currentIndex <= 0;
    document.getElementById('nextBtn').disabled = currentIndex >= wodList.length - 1;
}

document.addEventListener('DOMContentLoaded', function () {
    loadWodList();

    document.getElementById('prevBtn').addEventListener('click', function () {
        if (currentIndex > 0) {
            loadWodByIndex(currentIndex - 1);
        }
    });

    document.getElementById('nextBtn').addEventListener('click', function () {
        if (currentIndex < wodList.length - 1) {
            loadWodByIndex(currentIndex + 1);
        }
    });
});