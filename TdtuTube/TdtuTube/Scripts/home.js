let isClick = false;

const scrollContainer = document.getElementById("tagContainer")
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