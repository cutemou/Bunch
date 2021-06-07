function onInput(event) {
    let value = parseFloat(event.value);
    if (Number.isNaN(value)) {
        document.getElementById('inputemail').value = "0.0";
    } else {
        document.getElementById('inputemail').value = value.toFixed(1);
    }
}