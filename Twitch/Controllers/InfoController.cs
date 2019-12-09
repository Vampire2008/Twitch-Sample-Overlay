using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twitch.Utils.Twitch;

namespace Twitch.Controllers
{
	public class InfoController : Controller
	{
		private readonly TwitchHelper _helper;

		public InfoController(TwitchHelper helper)
		{
			_helper = helper;
		}

		public async Task<IActionResult> Followers()
		{
			return View(await _helper.GetUserFollows("52963431"));
		}
	}
}