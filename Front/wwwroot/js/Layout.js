﻿
var navBar = document.getElementById("navBar");

function togglebtn() {
    navBar.classList.toggle("hidemenu");
    
}
var swiper = new Swiper(".mySwiper", {
    slidesPerView: 2,
    spaceBetween: 30,
    slidesPerGroup: 2,
    loop: true,
    loopFillGroupWithBlank: true,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    breakpoints: {
        990: {
            slidesPerView: 5,
            spaceBetween: 50,
            slidesPerGroup: 5,
        },
    },

});

var startDate = new Date();
var endDate = new Date();
endDate.setDate(endDate.getDate() + 5);

var sy = startDate.getFullYear();
let sm = String(startDate.getMonth() + 1).padStart(2, '0');
let sd = String(startDate.getDate()).padStart(2, '0');
var ey = endDate.getFullYear();
let em = String(endDate.getMonth() + 1).padStart(2, '0');
let ed = String(endDate.getDate()).padStart(2, '0');

var h = Today.getHours();
var min = Today.getMinutes();

var CheckInTime = sy + "-" + sm + "-" + sd + "T" + h + ":" + min;
var CheckOutTime = ey + "-" + em + "-" + ed + "T" + h + ":" + min;

document.querySelector('#checkin-time').setAttribute('value', CheckInTime)
document.querySelector('#checkout-time').setAttribute('value', CheckOutTime)

function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}



//var swiper = new Swiper(".mySwiper", {
//    slidesPerView: 3,
//    spaceBetween: 30,
//    slidesPerGroup: 3,
//    loop: true,
//    loopFillGroupWithBlank: true,
//    pagination: {
//        el: ".swiper-pagination",
//        clickable: true,
//    },
//    navigation: {
//        nextEl: ".swiper-button-next",
//        prevEl: ".swiper-button-prev",





//window.onload = () => {
//    alert(window.location.pathname )
//    if (window.location.pathname == '/') {
//        document.getElementById("homePage").classList.add('active');
//        document.getElementById("roomList").classList.remove('active');
//        document.getElementById("roomType").classList.remove('active');
//    }
//    else if (window.location.pathname == '/Rooms/roomtype') {
//        document.getElementById("homePage").classList.remove('active');
//        document.getElementById("roomList").classList.remove('active');
//        document.getElementById("roomType").classList.add('active');
//    }
//    else if (window.location.pathname == '/Rooms/roomlist') {
//        document.getElementById("homePage").classList.remove('active');
//        document.getElementById("roomList").classList.add('active');
//        document.getElementById("roomType").classList.remove('active');
//    }
//}