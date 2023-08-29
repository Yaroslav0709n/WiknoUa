document.addEventListener("DOMContentLoaded", function () {
    const images = document.querySelectorAll(".webfun_win-calc_type-list img");
    const enlargedOverlay = document.querySelector(".enlarged-image-overlay");
    const enlargedImage = document.querySelector(".enlarged-image");

    images.forEach(image => {
        image.addEventListener("click", function () {
            const largeSrc = this.getAttribute("data-large-src");
            enlargedImage.setAttribute("src", largeSrc);
            enlargedOverlay.style.display = "flex";
        });
    });

    enlargedOverlay.addEventListener("click", function () {
        enlargedOverlay.style.display = "none";
    });
});

function openFullscreen(imageUrl) {
    var fullscreenImg = document.getElementById("fullscreen-img");

    fullscreenImg.src = imageUrl;
}