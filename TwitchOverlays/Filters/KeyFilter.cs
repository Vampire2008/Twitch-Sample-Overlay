using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchOverlays.Filters
{
	public class KeyFilter : IAsyncActionFilter
	{
		private string _key;

		public KeyFilter(IConfiguration configuration)
		{
			_key = configuration["KeyFilter"];
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!context.HttpContext.Request.Query.ContainsKey("key"))
			{
				context.Result = new ForbidResult();
				return;
			}
			if (context.HttpContext.Request.Query["key"] != _key)
			{
				context.Result = new ForbidResult();
				return;
			}
			await next();
		}
	}
}
