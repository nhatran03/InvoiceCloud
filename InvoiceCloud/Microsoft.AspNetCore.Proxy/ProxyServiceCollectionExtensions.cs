﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Proxy
{
	public static class ProxyServiceCollectionExtensions
	{
		public static IServiceCollection AddProxy(this IServiceCollection services)
		{
			if(services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			return services.AddSingleton<ProxyService>();
		}

		public static IServiceCollection AddProxy(this IServiceCollection services, Action<SharedProxyOptions> configureOptions)
		{
			if(services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			if(configureOptions == null)
			{
				throw new ArgumentNullException(nameof(configureOptions));
			}

			services.Configure(configureOptions);

			return services.AddSingleton<ProxyService>();
		}
	}
}
