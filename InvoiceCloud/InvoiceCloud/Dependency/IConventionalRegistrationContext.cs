using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Dependency
{
	public interface IConventionalRegistrationContext
	{
		/// <summary>
		/// Gets the registering Assembly
		/// </summary>
		Assembly Assembly { get; }

		/// <summary>
		/// Reference to the IOC Container to register types
		/// </summary>
		IIocManager IocManager { get; }

		ConventionalRegistrationConfig Config { get; }
	}
}
