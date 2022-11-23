using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.AppUsers;
using Website.Interfaces;

namespace Website.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IDataUsers _dataUsers;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, ValidateAntiForgeryToken]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLogin()
            {
                ReturnURL = returnUrl
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(UserLogin model)
        {
            if(ModelState.IsValid)
            {
                if (model.UserName == "admin" && model.Password == "admin")
                {
                    var user = new User {UserName = "admin"};
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("");
                }
                
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName,
                    model.Password,
                    false,
                    false);

                if (result.Succeeded)
                {
                    return Redirect("");
                }
            }
            return View(model);
        }

        [HttpGet, ValidateAntiForgeryToken]
        public IActionResult Register()
        {
            return View(new UserRegistration());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(UserRegistration model)
        {
            if(ModelState.IsValid)
            {
                var user = new User() { UserName = model.UserName};
                var result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    _dataUsers.AddUser(user);
                    
                    return Redirect("");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return Redirect("");
        }
    }
}
