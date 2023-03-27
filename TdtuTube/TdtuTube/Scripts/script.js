const mainContainer = document.getElementById("mainContainer");
const menuBtn = document.getElementById('menu');
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

const search = document.getElementById("search");
const searchBtn = document.getElementById("searchBtn");
searchBtn.addEventListener("click", function (e) {
    if (search.value != "")
        window.location.href = "/search?searchQuery=" + search.value;



})

search.addEventListener("keypress", function (e) {
    if (e.key === "Enter") {
        if (search.value != "")
            window.location.href = "/search?searchQuery=" + search.value;

    }
})

const userAvatar = document.getElementById("userAvatar");
const userInfoDropdown = document.getElementById("userInfoDropdown");
userAvatar.addEventListener("click", function (e) {
    if (userInfoDropdown.style.visibility == "visible") {
        userInfoDropdown.style.visibility = "hidden";
    } else {
        userInfoDropdown.style.visibility = "visible";
    }
})