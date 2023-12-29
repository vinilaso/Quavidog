//SLIDESHOW
let slideIndex = 1;
showSlide(slideIndex);

// Next/Previous controls
function plusSlides(n) {
    showSlide(slideIndex += n);
    stopLoop();
}

// Thumbnail image controls
function currentSlide(n) {
    showSlide(slideIndex = n);
}

function showSlide(n) {
    let i;
    let slides = document.getElementsByClassName("slide");

    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }

    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slides[slideIndex - 1].style.display = "block";
}

//BANANA DOG
const bush = document.getElementById("bush");
const bananaDog = document.getElementById("banana-dog");

bush.addEventListener('mouseenter', () => {
    bananaDog.style.bottom = '18vh';
});

bush.addEventListener('mouseleave', () => {
    bananaDog.style.bottom = '0';
})