using Microsoft.AspNetCore.Mvc;
using MY_Website.Data;
using MY_Website.Models;
using MY_Website.Models.Domain;

namespace MY_Website.Controllers
{
    public class UserContactController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public UserContactController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }


        [HttpGet]
        public IActionResult Contact()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Contact(UserContactViewModel userContactRequest)
        {
            var contact = new UserContact()
            {
                Id = Guid.NewGuid(),
                Name = userContactRequest.Name,
                Email = userContactRequest.Email,
                Date = DateTime.Now.ToString("D"),
                Message = userContactRequest.Message,
            };
            await databaseContext.Contacts.AddAsync(contact);
            await databaseContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
