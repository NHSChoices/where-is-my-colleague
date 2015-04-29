namespace WhereIsMyColleague.Web.Models
{
  using System.ComponentModel.DataAnnotations;

  public enum LocationEnum
  {
    [Display(Name = "Annual Leave")]
    AnnualLeave,
    [Display(Name = "Bridgewater Place")]
    BridgeWaterPlace,
    Home,
    Ill,
    [Display(Name = "Off-Site")]
    Offsite,
    Other,
    [Display(Name = "Skipton House")]
    SkiptonHouse,
    Training
  }
}