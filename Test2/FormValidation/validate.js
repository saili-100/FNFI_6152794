
function validateForm() {
    let username = document.getElementById("username").value;
    let pin = document.getElementById("pin").value;
    let state = document.getElementById("state").value;
    let validatePin = document.getElementById("validatePin").checked;
    let result = document.getElementById("result");
    let radios = document.getElementsByName("product");

    let messages = [];

    
    if (username.length < 6 || username.length > 8) {
        messages.push("Username should be between 6 and 8 characters");
    }

     
    if (validatePin) {
        let alphaNum = /^[a-zA-Z0-9]+$/;
        if (!alphaNum.test(pin)) {
            messages.push("Pin should be alphanumeric");
        }
    }

    if (state === "") {
        messages.push("State should be selected");
    }

   
    let radioSelected = false;
    for (let i = 0; i < radios.length; i++) {
        if (radios[i].checked) {
            radioSelected = true;
        }
    }
    if (!radioSelected) {
        messages.push("Please select a product");
    }

    if (messages.length > 0) {
        result.innerHTML = messages.join("<br>");
    } else {
        result.innerHTML = "Form validated successfully!";
        result.style.color = "green";
    }
}

