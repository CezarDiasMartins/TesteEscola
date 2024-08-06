// Modal Exclusão
var deleteModal = document.getElementById('deleteModal');
deleteModal.addEventListener('show.bs.modal', function (event) {
    var button = event.relatedTarget;
    var itemId = button.getAttribute('data-id');
    var controller = button.getAttribute('data-controller');
    var deleteForm = deleteModal.querySelector('#deleteForm');
    deleteForm.action = '/' + controller + '/Delete';
    deleteModal.querySelector('#itemId').value = itemId;
});


// Validação nos campos de notas - Aceitar somente nº 0 à 10
function validateInput(input) {
    const value = input.value;
    if (!/^(\d{1,2})(\.\d{0,2})?$/.test(value) || parseFloat(value) > 10) {
        input.value = value.slice(0, -1);
    }
}