var str = location.href.toLowerCase();
$(".nav-link").each(function () {
    if (str.indexOf($(this).attr("href").toLowerCase()) > -1) {
        $(".nav-link").removeClass("active");
        $(this).addClass("active");
    }
});


function addIngredient() {
    $("#ingredients").append('<li data-ingredient="' + $("#sel_ingredient").val() +
        '" data-amount="' + $("#amount").val() +
        '" data-unit="' + $("#sel_unit").val() +
        '" class="list-group-item"><i class="far fa-dot-circle"></i> ' + $("#amount").val() + " " + $("#sel_unit").val() + " of " + $("#sel_ingredient").val() +
        '<span class="remove-ingredient float-right"><i class="fas fa-times-circle"></i></span></li>');
}

$("#ingredients").on("click", ".remove-ingredient", function () {
    this.parentElement.remove();
});

function uploadImage() {
    $("#hidden_image").trigger('click');
}

function readURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#recipe_image').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#hidden_image").change(function () {
    readURL(this);
});

function submitForm() {

    var ingredients = [];

    $("#ingredients li").each(function () {
        ingredients.push({ "ingredient": $(this).attr("data-ingredient"), "amount": $(this).attr("data-amount"), "unit": $(this).attr("data-unit") });
    });

    $('#hidden_ingredients').val(JSON.stringify(ingredients));
    $("#hidden_name").val($("#recipe_name").val());
    $("#hidden_short_desc").val($("#short_description").val());
    $("#hidden_long_desc").val($("#long_description").val());
    
    if($("#hidden_form")[0].checkValidity());
        $("#hidden_form").submit();

}