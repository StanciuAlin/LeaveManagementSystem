using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel
            {
                Name = "Alin Marian",
                DateOfBirth = new DateTime(1998, 09, 06)
            };
            return View(data);
        }
    }
}
