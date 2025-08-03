const attachBtn = document.getElementById("attachExerciseBtn");
const select = document.getElementById("exerciseSelect");
const list = document.getElementById("attachedExercisesList");

attachBtn.addEventListener("click", function () {
    const selectedId = select.value;
    const selectedText = select.options[select.selectedIndex].text;

    if (!selectedId || document.getElementById("li_" + selectedId)) return;

    const li = document.createElement("li");
    li.id = "li_" + selectedId;
    li.classList.add("list-group-item", "d-flex", "justify-content-between", "align-items-center");
    li.innerHTML = `${selectedText}
                <button type="button" class="btn btn-sm btn-danger" onclick="removeExercise('${selectedId}')">Remove</button>
                <input type="hidden" name="SelectedExerciseIds" value="${selectedId}" id="input_${selectedId}" />`;

    list.appendChild(li);
});

function removeExercise(id) {
    document.getElementById("li_" + id)?.remove();
    document.getElementById("input_" + id)?.remove();
}

// document.getElementById("exerciseSearch").addEventListener("input", function () {
//     const search = this.value.toLowerCase();
//     Array.from(select.options).forEach(option => {
//         if (!option.value) return;
//         option.style.display = option.text.toLowerCase().includes(search) ? "block" : "none";
//     });
// });