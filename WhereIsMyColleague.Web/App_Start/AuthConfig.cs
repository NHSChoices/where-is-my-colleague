namespace WhereIsMyColleague.Web
{
  using Microsoft.Web.WebPages.OAuth;
  using System.Configuration;

  public static class AuthConfig
  {
    public static void RegisterAuth()
    {
      OAuthWebSecurity.RegisterMicrosoftClient(
          clientId: ConfigurationManager.AppSettings["MicrosoftClientId"],
          clientSecret: ConfigurationManager.AppSettings["MicrosoftClientSecret"]);

      OAuthWebSecurity.RegisterTwitterClient(
          consumerKey: ConfigurationManager.AppSettings["TwitterClientId"],
          consumerSecret: ConfigurationManager.AppSettings["TwitterClientSecret"]);
    }
  }
}