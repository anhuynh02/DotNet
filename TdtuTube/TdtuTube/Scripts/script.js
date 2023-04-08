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
if (userAvatar != null) {
    userAvatar.addEventListener("click", function (e) {
        if (userInfoDropdown.style.visibility == "visible") {
            userInfoDropdown.style.visibility = "hidden"
        } else {
            userInfoDropdown.style.visibility = "visible"
        }
    })
}

function closePlaylist(btn) {
    let items = document.getElementById("items");
    let titleclose = document.getElementById("pl-title-close");
    let titleopen = document.getElementById("pl-title-open");
    let pso = document.getElementById("ps-open");
    let psc = document.getElementById("ps-close");
    let pl_header = document.getElementById("pl-header")
    items.hidden = !items.hidden
    if (items.hidden === true) {
        pl_header.style.backgroundColor = "#122233f2"
    } else {
        pl_header.style.backgroundColor = "#212121"
    }
    pso.hidden = !pso.hidden
    psc.hidden = !psc.hidden
    titleclose.hidden = !titleclose.hidden
    titleopen.hidden = !titleopen.hidden

    closeBtn = btn.children[0]
    if (closeBtn.innerText != "expand_more") {
        closeBtn.innerText = "expand_more"
    } else {
        closeBtn.innerText = "close"
    }

}