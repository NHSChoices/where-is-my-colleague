namespace WhereIsMyColleague.Web.Models
{
  using System.ComponentModel.DataAnnotations;

  public class User
  {
    [Required(ErrorMessage = "Please enter a name")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
      ErrorMessage = "You entered your name incorrectly. Please try again")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please select a location")]
    public LocationEnum? Location { get; set; }

    [Required(ErrorMessage = "Please select a duration")]
    public DurationEnum? Duration { get; set; }

    public string TimeStamp { get; set; }
  }
}