// Toggle image logic
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