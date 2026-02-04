using Microsoft.AspNetCore.Mvc;

namespace CityPoint_RoomHire.Controllers
{
    public class StaticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
