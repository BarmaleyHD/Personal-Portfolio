$(document).ready(function(){
    $(".dropdown-toggle").dropdown();
});

function xTransition(x) {
    x.classList.toggle("change");
}

$( "#about" ).click(function() {
    $( "#myLogo:hidden:first" ).fadeIn( "slow" );
  });