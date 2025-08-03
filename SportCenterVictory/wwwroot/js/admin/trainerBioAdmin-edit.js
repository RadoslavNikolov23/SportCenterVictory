
document.getElementById("loadTrainerBtn").addEventListener("click", function () {
    const input = document.getElementById("trainerSearchInput").value;
    const selected = trainers.find(t => t.Email === input);

    if (!selected) {
        toastr.error("Please select a valid trainer email.");
        return;
    }

    fetch(`/Administration/Trainer/GetTrainer?id=${selected.Id}`)
        .then(res => res.json())
        .then(result => {
            if (!result.success) {
                toastr.error(result.message); // Show server error
                return;
            }

            const data = result.data;

            document.getElementById("Id").value = data.id;
            document.getElementById("FirstName").value = data.firstName;
            document.getElementById("LastName").value = data.lastName;
            document.getElementById("Email").value = data.email;
            document.getElementById("PhoneNumber").value = data.phoneNumber;
            document.getElementById("TrainerSpecialty").value = data.trainerSpecialty;
            document.getElementById("ImageUrl").value = data.imageUrl;
            document.getElementById("Bio").value = data.bio;

            document.getElementById("editTrainerForm").style.display = "block";
        })
        .catch(err => {
            console.error(error);
            toastr.error("An unexpected error occurred while loading trainer info.");
        });
});