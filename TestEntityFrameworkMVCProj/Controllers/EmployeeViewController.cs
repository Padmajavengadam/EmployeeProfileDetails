using Microsoft.AspNetCore.Mvc;

namespace TestEntityFrameworkMVCProj.Controllers
{
    public class EmployeeViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
