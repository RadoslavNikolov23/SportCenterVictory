window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Id").value = "";
    document.getElementById("Name").value = "";
    document.getElementById("TrainerName").value = "";
    document.getElementById("StartTime").value = "";
    document.getElementById("DayOfWeek").value = "";
    document.getElementById("Description").value = "";

    document.getElementById("loadClassBtn").addEventListener("click", function () {
        const input = document.getElementById("classSearchInput").value;
        const selected = classes.find(c => c.Name === input);

        if (!selected) {
            toastr.error("Please select a valid class name.");
            return;
        }

        fetch(`/Administration/Crossfit/GetClass?id=${selected.Id}`)
            .then(res => res.json())
            .then(result => {
                if (!result.success) {
                    toastr.error(result.message); // Show server error
                    return;
                }

                const data = result.data;
                document.getElementById("Id").value = data.id;
                document.getElementById("Name").value = data.name;
                document.getElementById("TrainerName").value = data.trainerName;
                document.getElementById("StartTime").value = data.startTime;
                document.getElementById("DayOfWeek").value = data.dayOfWeek.toString();
                document.getElementById("Description").value = data.description;

                document.getElementById("editClassForm").style.display = "block";
            })
            .catch(error => {
                console.error(error);
                toastr.error("An unexpected error occurred while loading crossfit class info.");
            });
    });
});