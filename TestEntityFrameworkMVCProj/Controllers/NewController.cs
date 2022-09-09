using Microsoft.AspNetCore.Mvc;
using TestEntityFrameworkMVCProj.Models;

namespace TestEntityFrameworkMVCProj.Controllers
{
    public class NewController : Controller
    {
        public static kltd_snm_devContext db = new kltd_snm_devContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}
