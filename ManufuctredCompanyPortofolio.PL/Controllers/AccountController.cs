using AutoMapper;
using ManufuctredCompanyPortofolio.DAL.Entities;
using ManufuctredCompanyPortofolio.DAL.Entities.Account;
using ManufuctredCompanyPortofolio.PL.Helper;
using ManufuctredCompanyPortofolio.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManufuctredCompanyPortofolio.PL.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public IMapper Mapper { get; }

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IMapper mapper)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Mapper = mapper;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var UserData = Mapper.Map<RegisterViewModel, ApplicationUser>(model);
                UserData.UserName =  UserData.Email.Split('@')[0];
                var Result = await UserManager.CreateAsync(UserData, model.Password);
                if(Result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        #endregion
        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var UserData =await UserManager.FindByEmailAsync(model.Email);
                if(UserData != null)
                {
                    var Password = await UserManager.CheckPasswordAsync(UserData, model.Password);
                    if(Password)
                    {
                      var Result =  await SignInManager.PasswordSignInAsync(UserData, model.Password, model.RememberMe, false);
                        if (Result.Succeeded)
                            return Redirect("/ManufctredCompany/Index");                        
                    }
                    else
                        ModelState.AddModelError("PassowrodOrEmailIsInvaid", "Passowrd Or Email Is Invalid");
                }
                
            }
            return View(model);
        }

        #endregion
        #region SignOut
        public async Task<IActionResult> SiginOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion
        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UserData = await UserManager.FindByEmailAsync(model.Email);
                if (UserData != null)
                {
                    var token =await UserManager.GeneratePasswordResetTokenAsync(UserData);//This Token Is Valid For This User Only
                    var ResetPasssowrdLink = Url.Action("ResetPassword", "Account", new { Email = model.Email,Token=token },Request.Scheme);
                    var email = new Email()
                    {
                        Title = "ResetPassowrd",
                        To = model.Email,
                        Body = ResetPasssowrdLink
					};
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CompleteForgetPassword));
                }
                ModelState.AddModelError(string.Empty, "Email Is Not Exist");
            }
            return View(model);
        }
        public IActionResult CompleteForgetPassword()
        {
            return View();
        }
		#endregion
		#region ResetPassword
        public IActionResult ResetPassword(string email,string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userData = await UserManager.FindByEmailAsync(model.Email);
                if(userData != null)
                {
                    var result = await UserManager.ResetPasswordAsync(userData, model.Token, model.NewPassword);
                    if(result.Succeeded)
                    {
                        return RedirectToAction(nameof(ResetPasswordDone));
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,error.Description);
                    }
                    return View(model);
                }
                ModelState.AddModelError(string.Empty, "This Email is Not Found");
            }
            return View(model);
        }
        public IActionResult ResetPasswordDone()
        {
            return View();
        }
        #endregion
    }
}
