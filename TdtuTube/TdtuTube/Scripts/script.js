let mainContainer = document.getElementById("videoMainContainer");
let menuBtn = document.getElementById('menu');
menuBtn.addEventListener("click", display_sidebar);
function display_sidebar() {
    isShow = document.getElementById("sideBar");
    if (isShow.style.display === "none") {
        isShow.style.display = "block"
        mainContainer.classList.add("lg:ml-60");
        mainContainer.classList.add("lg:w-4/5");
        mainContainer.classList.add("xl:w-5/6");
        mainContainer.classList.remove("lg:w-5/5")
    } else {
        isShow.style.display = "none"
        mainContainer.classList.remove("lg:ml-60");
        mainContainer.classList.remove("lg:w-4/5");
        mainContainer.classList.remove("xl:w-5/6");
        mainContainer.classList.add("lg:w-5/5")
    }
}

let isClick = false;

let scrollContainer = document.getElementById("tagContainer")
scrollContainer.addEventListener('mousedown', function (e) {
    isClick = true;
});
scrollContainer.addEventListener('mouseup', function (e) {
    isClick = false;
});
scrollContainer.addEventListener('mouseleave', function (e) {
    isClick = false;
});
scrollContainer.addEventListener('mousemove', function (e) {
    if (isClick == true) {
        e.preventDefault();
        scrollContainer.scrollLeft -= e.movementX;
    }
});