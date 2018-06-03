var str = location.href.toLowerCase();
$(".nav-link").each(function () {
    if (str.indexOf($(this).attr("href").toLowerCase()) > -1) {
        $(".nav-link").removeClass("active");
        $(this).addClass("active");
    }
});

var ingredients = [];

function addIngredient() {
    ingredients.push({ "ingredient": $("#sel_ingredient").val(), "amount": $("#amount").val(), "unit": $("#sel_unit").val() });
    $("#ingredients").append('<li class="list-group-item"><i class="far fa-dot-circle"></i> ' + $("#amount").val() + " " + $("#sel_unit").val() + " of " + $("#sel_ingredient").val() + '</li>');
    $('#hidden_ingredients').val(JSON.stringify(ingredients));
    console.log($('#hidden_ingredients').val());
}

function uploadImage() {
    $("#hidden_image").trigger('click');
}

function submitForm() {
    $("#hidden_name").val($("#recipe_name").val());
    $("#hidden_short_desc").val($("#short_description").val());
    $("#hidden_long_desc").val($("#long_description").val());

    /*
    console.log($("#hidden_name").val());
    console.log($("#hidden_short_desc").val());
    console.log($("#hidden_long_desc").val());
    */
    
    console.log($("#hidden_form")[0].checkValidity());
    $("#hidden_form").submit();

}