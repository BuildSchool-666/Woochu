function openCity(evt, cityName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}

const btn_name = document.querySelector('#btn_name')
const name = document.querySelector('#name')
const firstname = document.querySelector('#FirstName')
const lastname = document.querySelector('#LastName')

btn_name.onclick = () => {
    name.innerText = firstname.value + lastname.value
}

const btn_gender = document.querySelector('#btn_gender')
const gender = document.querySelector('#gender')
const selectGender = document.querySelector('#selectGender')

btn_gender.onclick = () => {
    if (selectGender.value == '')
        gender.innerText = '未指定'
    else
        gender.innerText = selectGender.Text

}

const btn_DOB = document.querySelector('#btn_DOB')
const DOB = document.querySelector('#DOB')
const selectDOB = document.querySelector('#selectDOB')

btn_DOB.onclick = () => {
    DOB.innerText = selectDOB.value
}

const btn_email = document.querySelector('#btn_Email')
const email = document.querySelector('#email')
const emailAdress = document.querySelector('#emailAddress')

btn_email.onclick = () => {
    email.innerText = emailAdress.value
}

const btn_Contact = document.querySelector('#btn_Contact')
const contact = document.querySelector('#contact')
const phoneNumber = document.querySelector('#phoneNumber')

btn_Contact.onclick = () => {
    contact.innerText = phoneNumber.value
}

function CheckINT() {
    if (isNaN(phoneNumber.value)) {
        alert("Must input numbers");
        return false;
    }
}