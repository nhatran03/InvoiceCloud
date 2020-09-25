using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Dependency
{
	public interface IIocManager : IIocRegistrar, IIocResolver, IDisposable
	{
		/// <summary>
		/// Reference to the Castle Windsor Container.
		/// </summary>
		IWindsorContainer IocContainer {get;}

		/// <summary>
		/// Checks whether given type is registered before.
		/// </summary>
		/// <param name="type">Type of check</param>
		/// <returns></returns>
		new bool IsRegistered(Type type);

		/// <summary>
		/// Checks whether given type is registered before.
		/// </summary>
		/// <typeparam name="T">Type of check</typeparam>
		/// <returns></returns>
		new bool IsRegistered<T>();
	}
}
