namespace WhereIsMyColleague.Web.Models
{
  public class UserDto
  {
    public string Name { get; set; }

    public LocationEnum? Location { get; set; }

    public DurationEnum? Duration { get; set; }

    public LocationEnum? SecondLocation { get; set; }

    public string TimeStamp { get; set; }

    public bool IsHalfDay { get; set; }
  }
}