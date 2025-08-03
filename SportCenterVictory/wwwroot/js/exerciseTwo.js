

let searchQuery = "";
const loadMoreBtn = document.getElementById('load-more-btn');
const exerciseList = document.getElementById('exercise-list');

async function loadExercises() {
    currentPage++;
    const response = await fetch(`/Fitness/Exercises?page=${currentPage}&pageSize=${pageSize}&query=${encodeURIComponent(searchQuery)}`, {
        headers: { 'X-Requested-With': 'XMLHttpRequest' }
    });
    const html = await response.text();
    const temp = document.createElement('div');
    temp.innerHTML = html;

    // Append new cards
    while (temp.firstChild) {
        exerciseList.appendChild(temp.firstChild);
    }

    attachEvents(); // reattach event listeners to new elements

    if (!html.trim()) {
        loadMoreBtn.style.display = 'none'; // Hide button if no more
    }
}

function attachEvents() {
    // Toggle instructions link
    document.querySelectorAll('.toggle-instructions-link').forEach(link => {
        link.addEventListener('click', (e) => {
            e.preventDefault();
            const section = link.closest('section.instructions-section');
            const isCollapsed = section.classList.contains('collapsed');
            section.classList.toggle('collapsed');
            link.textContent = isCollapsed ? 'Collapse' : 'More';
        });
    });

    // Image toggle
    document.querySelectorAll('.toggle-image').forEach(img => {
        if (!img.dataset.toggleAttached) {
            let toggled = false;
            img.dataset.toggleAttached = true;
            img.addEventListener('click', () => {
                const first = img.getAttribute('data-first');
                const second = img.getAttribute('data-second');
                img.src = toggled ? first : second;
                toggled = !toggled;
            });
        }
    });
}

// Initial attach
attachEvents();

// Load more click
loadMoreBtn?.addEventListener('click', loadExercises);

// Search input handler
document.getElementById('search')?.addEventListener('input', async (e) => {
    searchQuery = e.target.value.toLowerCase();
    currentPage = 1;

    // Fetch matching exercises from the server
    const response = await fetch(`/Fitness/Exercises?page=${currentPage}&pageSize=${pageSize}&query=${encodeURIComponent(searchQuery)}`, {
        headers: { 'X-Requested-With': 'XMLHttpRequest' }
    });

    const html = await response.text();
    exerciseList.innerHTML = html;

    attachEvents();

    // Show/hide Load More based on query
    loadMoreBtn.style.display = searchQuery ? 'none' : 'block';
});