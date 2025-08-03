document.addEventListener('DOMContentLoaded', function () {
    // Delegate click to all links with class 'exercise-link'
    document.querySelectorAll('.exercise-link').forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();

            const exerciseId = this.getAttribute('data-id');

            fetch(`/Fitness/ExerciseDetails?id=${exerciseId}`)
                .then(res => {
                    if (!res.ok) {
                        throw new Error("Failed to fetch exercise.");
                    }
                    return res.text();
                })
                .then(html => {
                    document.getElementById('exerciseModalBody').innerHTML = html;
                    const modal = new bootstrap.Modal(document.getElementById('exerciseModal'));
                    modal.show();
                })
                .catch(err => console.error('Error loading exercise:', err));
        });
    });
});  