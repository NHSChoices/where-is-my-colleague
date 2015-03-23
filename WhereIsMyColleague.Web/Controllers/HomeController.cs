namespace WhereIsMyColleague.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            return View();
        }
    }
}