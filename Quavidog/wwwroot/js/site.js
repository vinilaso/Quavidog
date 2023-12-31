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
});

// IMAGES
function getPictureData(table, field, id) {
    var fileModel = {
        Table: table,
        Column: field,
        Id: id,
    };

    $.ajax({
        url: '/Files/GetPictureData',
        type: 'GET',
        data: fileModel,
        success: function (data) {
            document.getElementById('fotoDisplay').src = data.data;
        }
    });
}

function previewFoto() {
    var input = document.getElementById('uploadFoto');
    var preview = document.getElementById('fotoDisplay');
    var file = input.files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    };

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "/img/upload-picture.svg"; // Imagem padrão se nenhum arquivo for selecionado
    }
}



