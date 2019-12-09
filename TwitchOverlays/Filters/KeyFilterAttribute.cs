using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchOverlays.Filters
{
	public class KeyFilterAttribute : Attribute, IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!context.HttpContext.Request.Query.ContainsKey("key"))
			{
				context.Result = new ForbidResult();
				return;
			}
			if (context.HttpContext.Request.Query["key"] != "my_key")
			{
				context.Result = new ForbidResult();
				return;
			}
			await next();
		}
	}
}
