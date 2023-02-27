let videosContainer = document.getElementById('videos-container');
let videoCard = "";
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
//fetch("./Content/JSON/videos.json")
//.then(response => response.json())
//.then(videos => {
//    console.log(videos);

//    videos.forEach(video => {
//        videoCard += `
//        <div class="flex flex-col space-y-3 cursor-pointer">
//        <!-- thumbnail -->
//        <a href="${video.videoURL}">
//            <div class="relative h-52 sm:h-36 w-full">
//            <img class="relative h-full w-full object-cover" src="${video.thumbnail}" alt="" draggable="false">
//            <span class="absolute right-1 bottom-1 p-0.5 px-1 rounded-sm bg-black text-white text-xs bg-opacity-70">${video.duration}</span>
//            </div>
//        </a>
//        <!-- video details -->
//        <div class="flex flex-col flex-auto space-y-1.5 mb-3">

//        <div class="flex items-center space-x-3">
//            <!-- channel logo -->
//            <img class="w-12 h-12 rounded-full object-cover" src="${video.desc.channelLogo}" alt="" draggable="false">
//            <div class="flex items-start">
//            <a href="${video.videoURL}" class="text-sm text-bold text-white pr-1">${video.desc.title}</a>
//            <i class="material-icons text-white md-21">more_vert</i>
//            </div>
//        </div>

//        <!-- channel link and meta data -->
//        <div class="flex flex-col pl-1 sm:pl-0 ml-14">
//            <a href="${video.desc.channelURL}" class="text-gray-400 text-sm hover:text-white">${video.desc.channelName}</a>
//            <div class="flex space-x-1">
//                <span class="text-sm text-gray-400">${video.desc.views} views</span>
//                <span class="text-sm text-gray-400">• ${video.desc.published} ago</span>
//            </div>
//        </div>
//        </div>
//    </div>`
//    });
//    videosContainer.innerHTML = videoCard;
//})