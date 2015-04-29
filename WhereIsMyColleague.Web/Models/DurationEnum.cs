namespace WhereIsMyColleague.Web.Models
{
  using System.ComponentModel.DataAnnotations;

  public enum DurationEnum
  {
    [Display(Name = "All Day")]
    AllDay,
    Morning,
    Afternoon
  }
}