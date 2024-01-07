using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MY_Website.Data;
using MY_Website.Models;
using MY_Website.Models.Domain;
using System.Diagnostics;

namespace MY_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext databaseContext;
        public HomeController(ILogger<HomeController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            this.databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel userContactRequest)
        {
            if(ModelState.IsValid)
            {
                var contact = new Contact()
                {
                    Id = Guid.NewGuid(),
                    Name = userContactRequest.Name,
                    Email = userContactRequest.Email,
                    Date = DateTime.Now.ToString("D"),
                    Message = userContactRequest.Message,
                };
                await databaseContext.Contacts.AddAsync(contact);
                await databaseContext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Submitted Successfully !";
                return RedirectToAction("Contact");
            }
            else
            {
                return View(userContactRequest);
            }
        }

        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Gallery(GalleryViewModal model)
        {

            return View();
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}