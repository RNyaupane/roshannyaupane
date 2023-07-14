using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MY_Website.Data;
using MY_Website.Models;
using MY_Website.Models.Domain;
using System.Security.Claims;

namespace MY_Website.Controllers
{
    public class UsersController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public UsersController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [AcceptVerbs("Post","Get")]
        public IActionResult IsEmailExit(string email)
        {
            var data = databaseContext.Users.Where(e => e.Email == email).SingleOrDefault();
            if (data != null)
            {
                return Json($"{email} already in use!");
            }
            else
            {
                return Json(true);
            }
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Signup(AuthUserViewModel addUserRequest)
        {
            if (ModelState.IsValid)
            {
                var data = new Users()
                {
                    Name = addUserRequest.Name,
                    Email = addUserRequest.Email,
                    Password = addUserRequest.Password,
                    IsActive = addUserRequest.IsActive,
                };
                databaseContext.Users.Add(data);
                databaseContext.SaveChanges();
                TempData["succcessMessage"] = "Registered Successfully, You Can Login Now";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["ErrorMessage"] = "Empty Form cannot be submitted";
                return View(addUserRequest);
            }
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUserViewModel addUserRequest)
        {
            if (ModelState.IsValid)
            {
                var data = databaseContext.Users.FirstOrDefault(e => e.Email == addUserRequest.Email);

                if (data != null)
                {
                    bool isValid = (data.Email == addUserRequest.Email && data.Password == addUserRequest.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[]
                             {
                                new Claim(ClaimTypes.Name, data.Name),
                                new Claim(ClaimTypes.Email, data.Email)
                            }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                        HttpContext.Session.SetString("Email", addUserRequest.Email);

                        // Set the name as User.Identity.Name
                        var nameClaim = new Claim(ClaimTypes.Name, data.Name);
                        HttpContext.User.AddIdentity(new ClaimsIdentity(new[] { nameClaim }));

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errPassword"] = "Invalid Password";
                        return View(addUserRequest);
                    }
                }
                else
                {
                    TempData["errorUser"] = "User Not Found!";
                    return View(addUserRequest);
                }
            }
            else
            {
                return View(addUserRequest);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach(var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login", "Users");
        }


    }
}
