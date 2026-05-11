Contributor: Jisoo Yoon

using Microsoft.AspNetCore.Mvc;

namespace FitnessAndCalorieTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult About() => View();

        public IActionResult Help() => View();
    }
}
