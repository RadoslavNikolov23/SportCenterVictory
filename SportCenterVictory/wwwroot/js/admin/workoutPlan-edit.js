window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Id").value = "";
    document.getElementById("Title").value = "";
    document.getElementById("Type").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("ImageUrl").value = "";


    document.getElementById("loadWorkoutPlanBtn").addEventListener("click", function () {
        const input = document.getElementById("workoutPlanSearchInput").value;
        const selected = workoutPlans.find(wp => wp.Title === input);

        if (!selected) {
            toastr.error("Please select a valid Workout Plan name.");
            return;
        }

        fetch(`/Administration/Fitness/GetWorkoutPlan?id=${selected.Id}`)
            .then(res => res.json())
            .then(result => {
                if (!result.success) {
                    toastr.error(result.message); // Show server error
                    return;
                }

                const data = result.data;
                document.getElementById("Id").value = data.id;
                document.getElementById("Title").value = data.title;
                document.getElementById("Type").value = data.type.toString();
                document.getElementById("Description").value = data.description;
                document.getElementById("ImageUrl").value = data.imageUrl;

                document.getElementById("editWorkoutPlanForm").style.display = "block";
            })
            .catch(error => {
                console.error(error);
                toastr.error("An unexpected error occurred while loading Workout Plan info.");
            });
    });
});