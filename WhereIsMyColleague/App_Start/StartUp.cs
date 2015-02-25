namespace WhereIsMyColleague
{
  using Owin;

  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      app.Run(
        context =>
          {
            context.Response.ContentType = "text/plain";
            return
              context.Response.WriteAsync("Move along, nothing to see here ....");
          });
    }
  }
}