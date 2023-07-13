using Microsoft.AspNetCore.Mvc;
using MY_Website.Data;

namespace MY_Website.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        private readonly DatabaseContext context;

        public AjaxController(DatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult UserList()
        {
            var data=context.Users.ToList();
            return new JsonResult(data);
        }
    }
}
