window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Id").value = "";
    document.getElementById("Title").value = "";
    document.getElementById("ProductCategory").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("Quantity").value = "";
    document.getElementById("Price").value = "";
    document.getElementById("ImageUrl").value = "";


    document.getElementById("loadProductBtn").addEventListener("click", function () {
        const input = document.getElementById("productSearchInput").value;
        const selected = products.find(e => e.Title === input);

        if (!selected) {
            toastr.error("Please select a valid product name.");
            return;
        }

        fetch(`/Administration/Store/GetProduct?id=${selected.Id}`)
            .then(res => res.json())
            .then(result => {
                if (!result.success) {
                    toastr.error(result.message); // Show server error
                    return;
                }

                const data = result.data;
                document.getElementById("Id").value = data.id;
                document.getElementById("Title").value = data.title;
                document.getElementById("ProductCategory").value = data.productCategory.toString();
                document.getElementById("Description").value = data.description;
                document.getElementById("Quantity").value = data.quantity;
                document.getElementById("Price").value = data.price;
                document.getElementById("ImageUrl").value = data.imageUrl;

                document.getElementById("editProductForm").style.display = "block";
            })
            .catch(error => {
                console.error(error);
                toastr.error("An unexpected error occurred while loading product info.");
            });
    });
});