using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestProject_For_CoralTeam.Models;
using TestProject_For_CoralTeam.Services;
using TestProject_For_CoralTeam.ViewModels;

namespace TestProject_For_CoralTeam.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRecaptchaService _recaptcha;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, IRecaptchaService recaptcha)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _recaptcha = recaptcha;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var captchaResponse = await _recaptcha.Validate(Request.Form);
                if (!captchaResponse.Success)
                {
                    ModelState.AddModelError("", "CAPTCHA error occured. Please try again.");
                    Response.StatusCode = 400;
                    return View(model);
                }
                User user = new User { UserName = model.Email, FirstName = model.FirstName, MiddleName = model.MiddleName, LastName = model.LastName
                , Salutation = model.Salutation, Phone = model.Phone,Fax = model.Fax, Company = model.Company, Mobile = model.Mobile,
                Title = model.Title, Finance = model.Finance,Operations = model.Operations,IT = model.IT,
                Sales = model.Sales, Administrative = model.Administrative,Legal = model.Legal,Marketing = model.Marketing,
                Comments= model.Comments, Country = model.Country,OfficeName = model.OfficeName,Address = model.Address,
                PostalCode = model.PostalCode,City = model.City, State = model.State};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    // await _signInManager.SignInAsync(user, false);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Home",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);
                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(model.Email, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");
                    Response.StatusCode = 200;
                    return View(model);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                Response.StatusCode = 400;
                return View(model);
            }
            Response.StatusCode = 200;
            return View(model);
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return Content("OK");
            else
                return NotFound();
        }








    }
}
