using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Twitch.Utils.Twitch.Models;
using TwitchLib.Webhook;
using TwitchOverlays.Hubs;

namespace TwitchOverlays.Controllers
{
	public class WebhooksController : Controller
	{
		[TwitchWebHook(Id = "followers")]
		public async Task<IActionResult> Followers([FromServices] IHubContext<OverlayHub> hubContext, [FromBody] UserFollowsModel data)
		{
			await hubContext.Clients.All.SendAsync("newFollower", data.Followers.First().FromUser);
			return Ok();
		}
	}
}