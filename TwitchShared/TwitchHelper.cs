
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Utils.Twitch.Models;

namespace Twitch.Utils.Twitch
{
	public class TwitchHelper
	{
		public string BaseUriForWebHooks { get; set; }
		private readonly HttpClient _httpClient;
		public TwitchHelper(string clientId)
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://api.twitch.tv/helix/");
			_httpClient.DefaultRequestHeaders.Add("Client-ID", clientId);
		}

		public async Task<UserFollowsModel> GetUserFollows(string toId)
		{
			var response = await _httpClient.GetAsync($"users/follows?to_id={toId}");
			return JsonSerializer.Deserialize<UserFollowsModel>(await response.Content.ReadAsStringAsync());
		}

		public async Task SubscribeToFollowers(string toId)
		{
			if (string.IsNullOrWhiteSpace(BaseUriForWebHooks))
				throw new ArgumentException("Set BaseUriForWebHooks on helper instance.");
			var model = new SubscribeWebhookModel();
			model.Callback = $"{BaseUriForWebHooks}/api/webhooks/incoming/twitch/followers";
			model.Mode = "subscribe";
			model.Topic = $"https://api.twitch.tv/helix/users/follows?first=1&to_id={toId}";
			model.LeaseSeconds = 86400; //24 часа

			var content = new StringContent(JsonSerializer.Serialize(model));
			content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
			var response = await _httpClient.PostAsync("webhooks/hub", content);
			response.EnsureSuccessStatusCode();
		}
	}
}
