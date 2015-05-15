using System.ComponentModel.DataAnnotations;

namespace WhereIsMyColleague.Web.Models
{
  using System.Collections.Generic;

  public class UsersViewModel
  {
    public IEnumerable<User> User { get; set; }

    [Display(Name = "Location")]
    public LocationEnum? LocationFilter { get; set; }
  }
}