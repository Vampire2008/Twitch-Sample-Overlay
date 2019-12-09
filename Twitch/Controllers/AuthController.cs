using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Twitch.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Auth()
        {
            return View();
        }

		public IActionResult Callback()
		{
			return Ok();
		}
    }
}