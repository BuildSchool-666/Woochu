
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

window.onload = () => {
    var localhost = window.location.href;
    //alert(window.location.pathname )
    if (window.location.pathname == '/home/abc') {
        document.getElementById("homePage").classList.add('active');
        document.getElementById("roomList").classList.remove('active');
        document.getElementById("roomType").classList.remove('active');
    }
    else if (window.location.pathname == '/Rooms/roomType') {
        document.getElementById("homePage").classList.remove('active');
        document.getElementById("roomList").classList.remove('active');
        document.getElementById("roomType").classList.add('active');
    }
    else if (window.location.pathname == '/Rooms/roomList') {
        document.getElementById("homePage").classList.remove('active');
        document.getElementById("roomList").classList.add('active');
        document.getElementById("roomType").classList.remove('active');
    }
}