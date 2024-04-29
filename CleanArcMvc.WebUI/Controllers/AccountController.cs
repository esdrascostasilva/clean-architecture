using CleanArcMvc.Domain.Account;
using CleanArcMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcMvc.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly IAuthenticate _authenticate;

    public AccountController(IAuthenticate authenticate)
    {
        _authenticate = authenticate;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginModel)
    {
        var result = await _authenticate.Authenticate(loginModel.Email, loginModel.Password);

        if(result)
        {
            if(string.IsNullOrEmpty(loginModel.ReturnUrl))
                return RedirectToAction("Index", "Home");
            return Redirect(loginModel.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt: Password must be strong");
            return View(loginModel);
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerModel)
    {
        var result = await _authenticate.RegisterUser(registerModel.Email, registerModel.Password);

        if(result)
            return Redirect("/");
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt: Password must be strong");
            return View(registerModel);
        }
    }

    public async Task<IActionResult> Logout()
    {
        await _authenticate.Logout();
        return Redirect("/Account/Login");
    }
}
