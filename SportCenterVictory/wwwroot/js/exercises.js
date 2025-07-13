document.addEventListener('DOMContentLoaded', async () => {

    // Toggle instructions link
    document.querySelectorAll('.toggle-instructions-link').forEach(link => {
        link.addEventListener('click', async (e) => {
            e.preventDefault();

            const section = link.closest('section.instructions-section');
            const isCollapsed = section.classList.contains('collapsed');

            if (isCollapsed) {
                section.classList.remove('collapsed');
                link.textContent = 'Collapse';
            } else {
                section.classList.add('collapsed');
                link.textContent = 'More';
            }
        });
    });

    // Image toggle
    document.querySelectorAll('.toggle-image').forEach(img => {
        let toggled = false;
        img.addEventListener('click', async () => {
            const first = img.getAttribute('data-first');
            const second = img.getAttribute('data-second');
            img.src = toggled ? first : second;
            toggled = !toggled;
        });
    });

    // Search filter
    document.getElementById('search')?.addEventListener('input', async (e) => {
        const query = e.target.value.toLowerCase();
        document.querySelectorAll('.exercise-card').forEach(card => {
            const name = card.dataset.name;
            card.parentElement.style.display = name.includes(query) ? 'block' : 'none';
        });
    });

});