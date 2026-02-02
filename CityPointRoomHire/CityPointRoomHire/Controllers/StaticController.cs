using Microsoft.AspNetCore.Mvc;

namespace CityPointRoomHire.Controllers
{
    public class StaticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
