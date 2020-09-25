using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Dependency
{
	public interface IIocResolver
	{
		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage.
		/// </summary>
		/// <typeparam name="T">Type of the object to get</typeparam>
		/// <returns>The object intance</returns>
		T Resolve<T>();

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage.
		/// </summary>
		/// <typeparam name="T">Type of the object to get</typeparam>
		/// <param name="type">Type of the object to resolve</param>
		/// <returns>The object intance</returns>
		T Resolve<T>(Type type);

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage.
		/// </summary>
		/// <typeparam name="T">Type of the object to get</typeparam>
		/// <param name="argumentsAsAnonymousType">Constructor arguments</param>
		/// <returns>The object intance</returns>
		T Resolve<T>(object argumentsAsAnonymousType);

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage.
		/// </summary>
		/// <param name="type">Type of the object to get</param>
		/// <returns>The object intance</returns>
		object Resolve(Type type);

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage.
		/// </summary>
		/// <param name="type">Type of the object to get</param>
		/// <param name="argumentsAsAnonymousType">Constructor arguments</param>
		/// <returns>The object intance</returns>
		object Resolve(Type type, object argumentsAsAnonymousType);

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage. 
		/// </summary>
		/// <typeparam name="T">Type of the object to resolve</typeparam>
		/// <returns>The object intance</returns>
		T[] ResolveAll<T>();

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage.  
		/// </summary>
		/// <typeparam name="T">Type of the object to resolve</typeparam>
		/// <param name="argumentsAsAnonymousType">Constructor arguments</param>
		/// <returns>The object intance</returns>
		T[] ResolveAll<T>(object argumentsAsAnonymousType);

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage. 
		/// </summary>
		/// <param name="type">Type of the object to resolve</param>
		/// <returns>The object intance</returns>
		object[] ResolveAll(Type type);

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released (see <see cref="Release"/>) after usage.  
		/// </summary>
		/// <param name="type">Type of the object to resolve</param>
		/// <param name="argumentsAsAnonymousType">Constructor arguments</param>
		/// <returns>The object intance</returns>
		object[] ResolveAll(Type type, object argumentsAsAnonymousType);

		/// <summary>
		/// Releases a pre-resolved object. See Resolve methods.
		/// </summary>
		/// <param name="obj">Object to be released</param>
		void Release(object obj);

		/// <summary>
		/// Checks whether given type is registered before.
		/// </summary>
		/// <param name="type">Type of check</param>
		/// <returns></returns>
		bool IsRegistered(Type type);

		/// <summary>
		/// Checks whether given type is registered before.
		/// </summary>
		/// <typeparam name="T">Type of check</typeparam>
		/// <returns></returns>
		bool IsRegistered<T>();
	}
}
