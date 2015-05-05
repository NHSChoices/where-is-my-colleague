namespace WhereIsMyColleague.Web.Models
{
  using System.ComponentModel.DataAnnotations;

  public class User
  {
    [Display(Name = "Please enter your full name")]
    [Required(ErrorMessage = "Please enter a name")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
      ErrorMessage = "You entered your name incorrectly. Please try again")]
    public string Name { get; set; }
    
    [Display(Name = "Choose your location")]
    [Required(ErrorMessage = "Please select a location")]
    public LocationEnum? Location { get; set; }

    [Display(Name = "When are you in this location")]
    [Required(ErrorMessage = "Please select a duration")]
    public DurationEnum? Duration { get; set; }

    [Display(Name = "Choose your location for the other half of the day")]
    [Required(ErrorMessage = "Please select a second location")]
    public LocationEnum? SecondLocation { get; set; }

    public string TimeStamp { get; set; }

    public bool IsHalfDay { get; set; }
  }
}