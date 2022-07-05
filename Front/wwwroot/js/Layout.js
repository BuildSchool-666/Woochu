
var navBar = document.getElementById("navBar");

function togglebtn() {
    navBar.classList.toggle("hidemenu");
}

var Today = new Date();
var t2 = new Date();
t2.setHours(t2.getHours() + 2);
var y = Today.getFullYear();
let m = String(Today.getMonth() + 1).padStart(2, '0');
let d = String(Today.getDate()).padStart(2, '0');
var h = Today.getHours();
var h1 = t2.getHours();
var min = Today.getMinutes();
var CheckInTime = y + "-" + m + "-" + d + "T" + h + ":" + min;
var CheckOutTime = y + "-" + m + "-" + d + "T" + h1 + ":" + min;

document.querySelector('#checkin-time').setAttribute('value', CheckInTime)
document.querySelector('#checkout-time').setAttribute('value', CheckOutTime)

function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}
