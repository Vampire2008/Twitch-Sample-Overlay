using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitchOverlays.Filters;

namespace TwitchOverlays.Controllers
{
	[KeyFilter]
	public class OverlayController : Controller
	{
		public IActionResult Follower()
		{
			return View();
		}
	}
}