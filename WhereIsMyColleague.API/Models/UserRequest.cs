namespace WhereIsMyColleague.API.Models
{
  using System.ComponentModel.DataAnnotations;

  public class UserRequest
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public LocationEnum? Location { get; set; }
    [Required]
    public DurationEnum? Duration { get; set; }
  }
}