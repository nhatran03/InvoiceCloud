using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Dependency
{
	public interface IIocRegistrar
	{
		/// <summary>
		/// Adds a dependency registrar for conventional registration.
		/// </summary>
		/// <param name="registrar">dependency registrar</param>
		void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar);
		
		/// <summary>
		/// Registers types of given assembly by all conventional registrar. See <see cref="IIocManager.AddConventionalRegistrar"/> method.
		/// </summary>
		/// <param name="assembly">Assembly to registrar</param>
		void RegisterAssemblyByConvention(Assembly assembly);

		/// <summary>
		/// Registers types of given assembly by all conventional registrar. See <see cref="IIocManager.AddConventionalRegistrar"/> method.
		/// </summary>
		/// <param name="assembly">Assembly to registrar</param>
		/// <param name="config">Additional configuration</param>
		void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config);

		/// <summary>
		/// Registers a type as self registration.
		/// </summary>
		/// <typeparam name="T">Type of the class</typeparam>
		/// <param name="lifeStyle">LifeStyle of the objects of this type</param>
		void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
			where T : class;

		/// <summary>
		/// Registers a type of self registration
		/// </summary>
		/// <param name="type">Type of the class</param>
		/// <param name="lifeStyle">LifeStyle of the objects of this type</param>
		void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

		/// <summary>
		/// Registers a type with it's implementation.
		/// </summary>
		/// <typeparam name="TType">Register type</typeparam>
		/// <typeparam name="TIml">The type that implement <see cref="TType"/></typeparam>
		/// <param name="lifeStyle">LifeStyle of the objects of this type</param>
		void Register<TType, TIml>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
			where TType : class
			where TIml : class, TType;

		/// <summary>
		/// Registers a type with it's implementation.
		/// </summary>
		/// <param name="type">Type of the class</param>
		/// <param name="Impl">The type that implements <paramref name="type"/></param>
		/// <param name="lifeStyle">LifeStyle of the objects of this type</param>
		void Register(Type type, Type Impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

		/// <summary>
		/// Checks whether given type is registered before.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		bool IsRegistered(Type type);

		/// <summary>
		/// Checks whether given type is registered before.
		/// </summary>
		/// <typeparam name="TType"></typeparam>
		/// <returns></returns>
		bool IsRegistered<TType>();
	}
}
