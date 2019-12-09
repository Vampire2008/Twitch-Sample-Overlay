﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebHooks.Filters;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using TwitchLib.Webhook.Filters;
using TwitchLib.Webhook.Metadata;

namespace TwitchLib.Webhook.Internal
{
	public static class TwitchServiceCollectionSetup
	{
		public static void AddTwitchServices(IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, MvcOptionsSetup>());

			services.TryAddEnumerable(ServiceDescriptor.Singleton<IWebHookMetadata, TwitchMetadata>());
			services.TryAddEnumerable(ServiceDescriptor.Singleton<IWebHookGetHeadRequestMetadata, TwitchMetadata>());
			services.TryAddEnumerable(ServiceDescriptor.Singleton<IWebHookBodyTypeMetadataService, TwitchMetadata>());

			services.TryAddSingleton<TwitchGetHeadRequestFilter>();
			services.TryAddSingleton<TwitchVerifySignatureFilter>();
		}


		private class MvcOptionsSetup : IConfigureOptions<MvcOptions>
		{
			public void Configure(MvcOptions options)
			{
				if (options == null)
				{
					throw new ArgumentNullException(nameof(options));
				}

				options.Filters.AddService<TwitchGetHeadRequestFilter>(WebHookSecurityFilter.Order);
				options.Filters.AddService<TwitchVerifySignatureFilter>(WebHookSecurityFilter.Order);
			}
		}
	}


}
