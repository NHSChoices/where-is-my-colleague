namespace WhereIsMyColleague.Web
{
  using Microsoft.Web.WebPages.OAuth;
  using System.Configuration;

  public static class AuthConfig
  {
    public static void RegisterAuth()
    {
      OAuthWebSecurity.RegisterMicrosoftClient(
          clientId: ConfigurationManager.AppSettings["MicrosoftClientSecret"],
          clientSecret: ConfigurationManager.AppSettings["MicrosoftClientSecret"]);

      OAuthWebSecurity.RegisterTwitterClient(
          consumerKey: ConfigurationManager.AppSettings["TwitterClientID"],
          consumerSecret: ConfigurationManager.AppSettings["TwitterClientSecret"]);
    }
  }
}