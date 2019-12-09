using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Twitch.Utils.Twitch.Models
{
	public class SubscribeWebhookModel
	{
		[JsonPropertyName("hub.callback")]
		public string Callback { get; set; }

		[JsonPropertyName("hub.mode")]
		public string Mode { get; set; }

		[JsonPropertyName("hub.topic")]
		public string Topic { get; set; }

		[JsonPropertyName("hub.lease_seconds")]
		public int LeaseSeconds { get; set; }
	}
}
