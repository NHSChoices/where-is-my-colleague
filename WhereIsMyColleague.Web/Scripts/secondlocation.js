$(function () {

  $('#SecondLocationID').hide();
  $('#SecondLocation').hide();

  $(window).load(function () {
    if ($('#Duration').val() == 0 || $('#Duration').val() == null) {
      $('#SecondLocationID').hide();
      $('#SecondLocation').hide();
    } else {
      $('#SecondLocationID').show();
      $('#SecondLocation').show();
    }
  });

  $('#Duration').change(function () {
    if ($('#Duration').val() != 0) {
      $('#SecondLocationID').show();
      $('#SecondLocation').show();
    } else {
      $('#SecondLocationID').hide();
      $('#SecondLocation').hide();
      $('#SecondLocationErrorMsg').hide();
    }
  });
});
