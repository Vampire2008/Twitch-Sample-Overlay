using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Twitch.Utils.Twitch.Models
{
	public class UserFollowsModel
	{
		[JsonPropertyName("data")]
		[BindProperty(Name ="data")]
		public IEnumerable<Follow> Followers { get; set; }
	}
}
