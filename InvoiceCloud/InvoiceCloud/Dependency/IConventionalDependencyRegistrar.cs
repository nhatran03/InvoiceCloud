using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Dependency
{
	public interface IConventionalDependencyRegistrar
	{
		/// <summary>
		/// Registers types of given assembly by convention.
		/// </summary>
		/// <param name="context"></param>
		void RegisterAssembly(IConventionalRegistrationContext context);
	}
}
