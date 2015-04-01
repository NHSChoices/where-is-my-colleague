namespace WhereIsMyColleague.Web.Models
{
    public class UserDto
    {
        public string Name { get; set; }
        public LocationEnum? Location { get; set; }
        public DurationEnum? Duration { get; set; }
        public virtual LocationEnum? SecondLocation { get; set; }
    }
}