
export function showSavedModal() {
    //document.getElementById('modalSaved').style.visibility = "visible";
    $('#modalSaved').show();
}

export function hideSaveModal() {
    $('#modalSaved').hide();
}

export function showErrorModal() {
    $('#modalError').show();
}

export function hideErrorModal() {
    $('#modalError').hide();
}

export function showResponse(response) {
    alert(response);
}

export function showRefModal() {
    $('#modalRefBook').show();
}

export function hideRefModal() {
    $('#modalRefBook').hide();
}