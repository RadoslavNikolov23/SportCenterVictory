window.addEventListener("DOMContentLoaded", () => {
    document.getElementById("Id").value = "";
    document.getElementById("Name").value = "";
    document.getElementById("Force").value = "";
    document.getElementById("Mechanic").value = "";
    document.getElementById("Equipment").value = "";
    document.getElementById("PrimaryMuscles").value = "";
    document.getElementById("SecondaryMuscles").value = "";
    document.getElementById("Instructions").value = "";
    document.getElementById("Category").value = "";
    document.getElementById("ImageUrlOne").value = "";
    document.getElementById("ImageUrlTwo").value = "";


    document.getElementById("loadExerciseBtn").addEventListener("click", function () {
        const input = document.getElementById("exerciseSearchInput").value;
        const selected = exercises.find(e => e.Name === input);

        if (!selected) {
            toastr.error("Please select a valid exercise name.");
            return;
        }

        fetch(`/Administration/Fitness/GetExercise?id=${selected.Id}`)
            .then(res => res.json())
            .then(result => {
                if (!result.success) {
                    toastr.error(result.message); // Show server error
                    return;
                }

                const data = result.data;
                document.getElementById("Id").value = data.id;
                document.getElementById("Name").value = data.name;
                document.getElementById("Force").value = data.force;
                document.getElementById("Mechanic").value = data.mechanic;
                document.getElementById("Equipment").value = data.equipment;
                document.getElementById("PrimaryMuscles").value = data.primaryMuscles;
                document.getElementById("SecondaryMuscles").value = data.secondaryMuscles;
                document.getElementById("Instructions").value = data.instructions;
                document.getElementById("Category").value = data.category;
                document.getElementById("ImageUrlOne").value = data.imageUrlOne;
                document.getElementById("ImageUrlTwo").value = data.imageUrlTwo;

                document.getElementById("editExerciseForm").style.display = "block";
            })
            .catch(error => {
                console.error(error);
                toastr.error("An unexpected error occurred while loading exercise info.");
            });
    });
});