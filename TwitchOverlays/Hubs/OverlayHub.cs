using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchOverlays.Filters;

namespace TwitchOverlays.Hubs
{
	[KeyFilter]
	public class OverlayHub : Hub
	{
		public async Task NewFollower(string name)
		{
			await Clients.All.SendAsync("newFollower", name);
		}
	}
}
