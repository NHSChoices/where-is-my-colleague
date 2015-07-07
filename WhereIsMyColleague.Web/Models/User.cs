using System.Web.Mvc;

namespace WhereIsMyColleague.Web.Models
{
  using System.ComponentModel.DataAnnotations;

  public class User
  {
    [Display(Name = "Name")]
    [Required(ErrorMessage = "Please enter a name")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
      ErrorMessage = "You entered your name incorrectly. Please try again")]
    public string Name { get; set; }
    
    [Display(Name = "Location")]
    [Required(ErrorMessage = "Please select a location")]
    public LocationEnum? Location { get; set; }

    [Display(Name = "Duration")]
    [Required(ErrorMessage = "Please select a duration")]
    public DurationEnum? Duration { get; set; }

    [Display(Name = "Second Location")]
    [Required(ErrorMessage = "Please select a second location")]
    public LocationEnum? SecondLocation { get; set; }

    private bool _isHalfDay;
    public bool IsHalfDay
    {
      get
      {
        if (Duration != 0)
        {
          _isHalfDay = true;
        }

        return _isHalfDay;
      }
      set { _isHalfDay = value; }
    }
  }
}