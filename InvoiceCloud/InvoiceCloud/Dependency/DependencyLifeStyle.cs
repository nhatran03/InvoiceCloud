using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Dependency
{
	public enum DependencyLifeStyle
	{
		/// <summary>
		/// Singleton object. Created a single object on first resolving
		/// and same instance is used for subsequent resolves
		/// </summary>
		Singleton,
		
		/// <summary>
		/// Transient object. Created one object for every resolving
		/// </summary>
		Transient
	}
}
