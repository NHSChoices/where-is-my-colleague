namespace WhereIsMyColleague.Web.Models
{
  using System.ComponentModel.DataAnnotations;

  public enum LocationEnum
  {
    [Display(Name = "Annual Leave")]
    AnnualLeave = 1,
    [Display(Name = "Bridgewater Place")]
    BridgeWaterPlace = 2,
    Home = 3,
    Ill = 4,
    [Display(Name = "Off-Site")]
    Offsite = 5,
    Other = 6,
    [Display(Name = "Skipton House")]
    SkiptonHouse = 7,
    Training = 8
  }
}