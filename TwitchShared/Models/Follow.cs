using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Twitch.Utils.Twitch.Models
{
	public class Follow
	{
		[JsonPropertyName("from_id")]
		[BindProperty(Name = "from_id")]
		public string FromUserId { get; set; }
		[JsonPropertyName("from_name")]
		[BindProperty(Name = "from_name")]
		public string FromUser { get; set; }
		[JsonPropertyName("to_id")]
		[BindProperty(Name = "to_id")]
		public string ToUserId { get; set; }
		[JsonPropertyName("to_name")]
		[BindProperty(Name = "to_name")]
		public string ToUser { get; set; }
		[JsonPropertyName("followed_at")]
		[BindProperty(Name = "followed_at")]
		public DateTime FollowerAt { get; set; }
	}
}
