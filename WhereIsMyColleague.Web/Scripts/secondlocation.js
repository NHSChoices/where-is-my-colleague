$(function () {

  var savedSelection = null;
  $(window).load(function () {
    if ($('#Duration').val() == 0 || $('#Duration').val() == null) {
      $('#SecondLocationID').hide();
      $('#SecondLocation').hide();
    } else {
      $('#SecondLocationID').show();
      $('#SecondLocation').show();
    }

    var selectedValue = $('#Location option:selected');
    if (selectedValue != "") {
      $('#SecondLocation option[value=' + selectedValue.val() + ']').remove();
    }

    if (savedSelection != null) {
      $('#SecondLocation').append($('<option>', { value: savedSelection.val() }).text(savedSelection.text()));
    }

    savedSelection = selectedValue;
  });

  $('#Location').change(function () {
    var selectedValue = $('#Location option:selected');
    if (selectedValue != "") {
      $('#SecondLocation option[value=' + selectedValue.val() + ']').remove();
    }

    if (savedSelection != null) {
      $('#SecondLocation').append($('<option>', { value: savedSelection.val() }).text(savedSelection.text()));
    }

    savedSelection = selectedValue;
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
