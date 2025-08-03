// Attach to all forms with class quantity-buy
document.querySelectorAll('form.quantity-buy').forEach(form => {
    form.addEventListener('submit', async function (e) {
        e.preventDefault(); // stop normal form submission

        const formData = new FormData(this);
        const token = formData.get('__RequestVerificationToken');

        try {
            const response = await fetch(this.action, {
                method: 'POST',
                headers: {
                    'RequestVerificationToken': token
                },
                body: formData
            });

            if (response.ok) {
                toastr.success('Product added to cart!');
                // Optionally reset quantity input
                this.querySelector('input[name="quantity"]').value = 1;
            } else {
                toastr.error('Failed to add product to cart.');
            }
        } catch (error) {
            toastr.error('An error occurred.');
            console.error(error);
        }
    });
});