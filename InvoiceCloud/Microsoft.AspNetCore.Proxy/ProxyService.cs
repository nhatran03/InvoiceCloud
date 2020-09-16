using Microsoft.Extensions.Options;
using System;
using System.Net.Http;


namespace Microsoft.AspNetCore.Proxy
{
	public class ProxyService
	{
		public ProxyService(IOptions<SharedProxyOptions> options)
		{
			if (options == null)
			{
				throw new ArgumentOutOfRangeException(nameof(options));
			}

			Options = options.Value;
			Client = new HttpClient(Options.MessageHandler ?? new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false });
		}

		public SharedProxyOptions Options { get; private set; }

		internal HttpClient Client { get; private set; }
	}
}
