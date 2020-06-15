using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSD480Group3Capstone001.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private IPasswordHasher<IdentityUser> passwordHasher;
        private IPasswordValidator<IdentityUser> passwordValidator;
        private IUserValidator<IdentityUser> userValidator;

        public AdminController(UserManager<IdentityUser> usrMgr, IPasswordHasher<IdentityUser> passwordHash, IPasswordValidator<IdentityUser> passwordVal, IUserValidator<IdentityUser> userValid)
        {
            userManager = usrMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordVal;
            userValidator = userValid;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }


        /* public IActionResult Index()
         {
             return View(userManager.Users);
         }

         public ViewResult Create() => View();

         [HttpPost]
         public async Task<IActionResult> Create(IdentityUser user)
         {
             if (ModelState.IsValid)
             {
                 IdentityUser appUser = new IdentityUser
                 {
                     UserName = user.Email,


                 };

                 IdentityResult result = await userManager.CreateAsync(appUser, Model.Password);
                 if (result.Succeeded)
                     return RedirectToAction("Index");
                 else
                 {
                     foreach (IdentityError error in result.Errors)
                         ModelState.AddModelError("", error.Description);
                 }
             }
             return View(user);
         }

         public async Task<IActionResult> Update(string id)
         {
             AppUser user = await userManager.FindByIdAsync(id);
             if (user != null)
                 return View(user);
             else
                 return RedirectToAction("Index");
         }

         [HttpPost]
         public async Task<IActionResult> Update(string id, string email, string password, int age, string country, string salary)
         {
             AppUser user = await userManager.FindByIdAsync(id);
             if (user != null)
             {
                 IdentityResult validEmail = null;
                 if (!string.IsNullOrEmpty(email))
                 {
                     validEmail = await userValidator.ValidateAsync(userManager, user);
                     if (validEmail.Succeeded)
                         user.Email = email;
                     else
                         Errors(validEmail);
                 }
                 else
                     ModelState.AddModelError("", "Email cannot be empty");

                 IdentityResult validPass = null;
                 if (!string.IsNullOrEmpty(password))
                 {
                     validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                     if (validPass.Succeeded)
                         user.PasswordHash = passwordHasher.HashPassword(user, password);
                     else
                         Errors(validPass);
                 }
                 else
                     ModelState.AddModelError("", "Password cannot be empty");

                 user.Age = age;

                 Enum.TryParse(country, out myCountry);
                 user.Country = myCountry;

                 if (!string.IsNullOrEmpty(salary))
                     user.Salary = salary;
                 else
                     ModelState.AddModelError("", "Salary cannot be empty");

                 if (validEmail != null && validPass != null && validEmail.Succeeded && validPass.Succeeded && !string.IsNullOrEmpty(salary))
                 {
                     IdentityResult result = await userManager.UpdateAsync(user);
                     if (result.Succeeded)
                         return RedirectToAction("Index");
                     else
                         Errors(result);
                 }
             }
             else
                 ModelState.AddModelError("", "User Not Found");

             return View(user);
         }

         [HttpPost]
         public async Task<IActionResult> Update(string id, string email, string password)
         {
             AppUser user = await userManager.FindByIdAsync(id);
             if (user != null)
             {
                 if (!string.IsNullOrEmpty(email))
                     user.Email = email;
                 else
                     ModelState.AddModelError("", "Email cannot be empty");

                 if (!string.IsNullOrEmpty(password))
                     user.PasswordHash = passwordHasher.HashPassword(user, password);
                 else
                     ModelState.AddModelError("", "Password cannot be empty");

                 if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                 {
                     IdentityResult result = await userManager.UpdateAsync(user);
                     if (result.Succeeded)
                         return RedirectToAction("Index");
                     else
                         Errors(result);
                 }
             }
             else
                 ModelState.AddModelError("", "User Not Found");
             return View(user);
         }*/

        /*[HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult validEmail = null;
                if (!string.IsNullOrEmpty(email))
                {
                    validEmail = await userValidator.ValidateAsync(userManager, user);
                    if (validEmail.Succeeded)
                        user.Email = email;
                    else
                        Errors(validEmail);
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    else
                        Errors(validPass);
                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (validEmail != null && validPass != null && validEmail.Succeeded && validPass.Succeeded)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");

            return View(user);
        }*/

        void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }
    }
}