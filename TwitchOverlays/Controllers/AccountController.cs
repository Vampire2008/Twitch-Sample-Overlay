using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitchOverlays.Controllers
{
	public class AccountController : Controller
	{

		[HttpGet]
		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		private bool ValidateLogin(string userName, string password)
		{
			return userName == "Kain_Stropov" && password == "MyLittleTwitch";
		}

		[HttpPost]
		public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			// Normally Identity handles sign in, but you can do it directly
			if (ValidateLogin(userName, password))
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, userName)
				};

				await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies")));

				if (Url.IsLocalUrl(returnUrl))
				{
					return Redirect(returnUrl);
				}
				else
				{
					return Redirect("/");
				}
			}

			return View();
		}

		public IActionResult AccessDenied(string returnUrl = null)
		{
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return Redirect("/");
		}
	}
}