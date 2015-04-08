namespace WhereIsMyColleague.API
{
  using System.Web.Http;
  using Owin;

  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();
      config.MapHttpAttributeRoutes();
      config.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}", new {id = RouteParameter.Optional});

      app.UseWebApi(config);
    }
  }
}