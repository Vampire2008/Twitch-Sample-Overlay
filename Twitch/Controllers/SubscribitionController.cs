using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twitch.Utils.Twitch;

namespace Twitch.Controllers
{
	public class SubscribitionController : Controller
	{
		private readonly TwitchHelper _helper;

		public SubscribitionController(TwitchHelper helper)
		{
			_helper = helper;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Followers()
		{
			ViewBag.WasException = false;
			try
			{
				await _helper.SubscribeToFollowers("52963431");
			}
			catch (Exception e)
			{
				ViewBag.WasException = true;
			}
			return View();
		}
	}
}