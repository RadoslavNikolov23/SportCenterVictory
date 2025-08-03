window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Id").value = "";
    document.getElementById("Name").value = "";
    document.getElementById("MembershipType").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("Price").value = "";
    document.getElementById("Duration").value = "";


    document.getElementById("loadMembershipBtn").addEventListener("click", function () {
        const input = document.getElementById("membershipSearchInput").value;
        const selected = memberships.find(e => e.Name === input);

        if (!selected) {
            toastr.error("Please select a valid membership name.");
            return;
        }

        fetch(`/Administration/Store/GetMembership?id=${selected.Id}`)
            .then(res => res.json())
            .then(result => {
                if (!result.success) {
                    toastr.error(result.message); // Show server error
                    return;
                }

                const data = result.data;
                document.getElementById("Id").value = data.id;
                document.getElementById("Name").value = data.name;
                document.getElementById("MembershipType").value = data.membershipType.toString();
                document.getElementById("Description").value = data.description;
                document.getElementById("Price").value = data.price;
                document.getElementById("Duration").value = data.duration;

                document.getElementById("editMembershipForm").style.display = "block";
            })
            .catch(error => {
                console.error(error);
                toastr.error("An unexpected error occurred while loading membership info.");
            });
    });
});