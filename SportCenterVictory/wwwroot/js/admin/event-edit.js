window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Id").value = "";
    document.getElementById("Title").value = "";
    document.getElementById("EventType").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("StartDate").value = "";
    document.getElementById("Location").value = "";
    document.getElementById("ImageUrl").value = "";


    document.getElementById("loadEventBtn").addEventListener("click", function () {
        const input = document.getElementById("eventSearchInput").value;
        const selected = events.find(e => e.Title === input);

        if (!selected) {
            toastr.error("Please select a valid event title.");
            return;
        }

        fetch(`/Administration/Event/GetEvent?id=${selected.Id}`)
            .then(res => res.json())
            .then(result => {
                if (!result.success) {
                    toastr.error(result.message); // Show server error
                    return;
                }

                const data = result.data;
                document.getElementById("Id").value = data.id;
                document.getElementById("Title").value = data.title;
                document.getElementById("EventType").value = data.eventType.toString();
                document.getElementById("Location").value = data.location;
                document.getElementById("StartDate").value = data.startDate;
                document.getElementById("Description").value = data.description;
                document.getElementById("ImageUrl").value = data.imageUrl;

                document.getElementById("editEventForm").style.display = "block";
            })
            .catch(error => {
                console.error(error);
                toastr.error("An unexpected error occurred while loading event info.");
            });
    });
});