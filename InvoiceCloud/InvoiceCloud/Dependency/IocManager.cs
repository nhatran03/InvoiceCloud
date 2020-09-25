﻿using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Dependency
{
	/// <summary>
	/// This class is used to directly perform dependency injection tasks.
	/// </summary>
	public class IocManager: IIocManager
	{
		public static IocManager Instance { get; private set; }

		public IWindsorContainer IocContainer { get; private set; }

		private readonly List<IConventionalDependencyRegistrar> conventionalRegistrars;

		static IocManager()
		{
			Instance = new IocManager();
		}

		public IocManager()
		{
			IocContainer = new WindsorContainer();
			conventionalRegistrars = new List<IConventionalDependencyRegistrar>();

			//Register self!
			IocContainer.Register(Component.For<IocManager, IIocManager, IIocRegistrar, IIocResolver>().UsingFactoryMethod(() => this));
		}

		/// <summary>
		/// Adds a denpendency registrar for coonventional registration.
		/// </summary>
		/// <param name="registrar">dependency registrar</param>
		public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
		{
			conventionalRegistrars.Add(registrar);
		}

		/// <summary>
		/// Registers types of given assembly by all conventional registrars. See <see cref="AddConventionalRegistrar"/> method.
		/// </summary>
		/// <param name="assembly">Assembly to register</param>
		public void RegisterAssemblyByConvention(Assembly assembly)
		{
			RegisterAssemblyByConvention(assembly, new ConventionalRegistrationConfig());
		}

		/// <summary>
		/// Registers types of given assembly by all conventional registrars. See <see cref="AddConventionalRegistrar"/> method.
		/// </summary>
		/// <param name="assembly">Assembly to register</param>
		/// <param name="config">Additional configuration</param>
		public void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config)
		{
			var context = new ConventionalRegistrationContext(assembly, this, config);

			foreach(var registerer in conventionalRegistrars)
			{
				registerer.RegisterAssembly(context);
			}

			if (config.InstallInstallers)
			{
				IocContainer.Install(FromAssembly.Instance(assembly));
			}
		}

		/// <summary>
		/// Registers a type as self registration.
		/// </summary>
		/// <typeparam name="TType">Type of the class</typeparam>
		/// <param name="lifeStyle">Lifestyle of the object of this type</param>
		public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
		{
			IocContainer.Register(ApplyLifestyle(Component.For<TType>(), lifeStyle));
		}

		/// <summary>
		/// Registers a type as self registration.
		/// </summary>
		/// <param name="type">Type of the class</param>
		/// <param name="lifeStyle">Lifestyle of the object of this type</param>
		public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
		{
			IocContainer.Register(ApplyLifestyle(Component.For(type), lifeStyle));
		}

		/// <summary>
		/// Registers a type with it's implementation.
		/// </summary>
		/// <typeparam name="TType">Registering type</typeparam>
		/// <typeparam name="TImpl">The type that implements <see cref="TType"/></typeparam>
		/// <param name="lifeStyle">Lifestyle of the object of this type</param>
		public void Register<TType,TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
			where TType: class
			where TImpl: class, TType
		{
			IocContainer.Register(ApplyLifestyle(Component.For<TType, TImpl>().ImplementedBy<TImpl>(), lifeStyle));
		}

		/// <summary>
		/// Registers a type with it's implementation.
		/// </summary>
		/// <param name="type">Type of the class</param>
		/// <param name="impl">The type that implements <see cref="type"/></param>
		/// <param name="lifeStyle">Lifestyle of the object of this type</param>
		public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
		{
			IocContainer.Register(ApplyLifestyle(Component.For(type, impl).ImplementedBy(impl), lifeStyle));
		}

		/// <summary>
		/// Checks whether given type is registered before.
		/// </summary>
		/// <param name="type">Type to check</param>
		/// <returns></returns>
		public bool IsRegistered(Type type)
		{
			return IocContainer.Kernel.HasComponent(type);
		}

		/// <summary>
		/// Checks whether given type is registered before.
		/// </summary>
		/// <typeparam name="TType">Type to check</typeparam>
		/// <returns></returns>
		public bool IsRegistered<TType>()
		{
			return IocContainer.Kernel.HasComponent(typeof(TType));
		}

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released( see <see cref="IIocResolver.Release"/> after usage.
		/// </summary>
		/// <typeparam name="T">Type of the object to get</typeparam>
		/// <returns>The instance object</returns>
		public T Resolve<T>()
		{
			return IocContainer.Resolve<T>();
		}

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released( see <see cref="IIocResolver.Release"/> after usage. 
		/// </summary>
		/// <typeparam name="T">Type of the object to cast</typeparam>
		/// <param name="type">Type of the object to resolve</param>
		/// <returns></returns>
		public T Resolve<T>(Type type)
		{
			return (T)IocContainer.Resolve(type);
		}

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released( see <see cref="IIocResolver.Release"/> after usage. 
		/// </summary>
		/// <typeparam name="T">Type of the object to get</typeparam>
		/// <param name="argumentsAsAnonymousType">Constructor arguments</param>
		/// <returns>The instance object</returns>
		public T Resolve<T>(object argumentsAsAnonymousType)
		{
			return IocContainer.Resolve<T>((Arguments)argumentsAsAnonymousType);
		}

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released( see <see cref="IIocResolver.Release"/> after usage. 
		/// </summary>
		/// <param name="type">Type of the object to get</param>
		/// <returns>The instance object</returns>
		public object Resolve(Type type)
		{
			return IocContainer.Resolve(type);
		}

		/// <summary>
		/// Gets an object from IOC container.
		/// Returning object must be Released( see <see cref="IIocResolver.Release"/> after usage.  
		/// </summary>
		/// <param name="type">Type of the object to get</param>
		/// <param name="argumentsAsAnonymousType">Constructor arguments</param>
		/// <returns>The instance object</returns>
		public object Resolve(Type type, object argumentsAsAnonymousType)
		{
			return IocContainer.Resolve(type, (Arguments)argumentsAsAnonymousType);
		}

		public T[] ResolveAll<T>()
		{
			return IocContainer.ResolveAll<T>();
		}

		public T[] ResolveAll<T>(object argumentsAsAnonymousType)
		{
			return IocContainer.ResolveAll<T>((Arguments)argumentsAsAnonymousType);
		}

		public object[] ResolveAll(Type type)
		{
			return IocContainer.ResolveAll(type).Cast<object>().ToArray();
		}

		public object[] ResolveAll(Type type, object argumentsAsAnonymousType)
		{
			return IocContainer.ResolveAll(type, (Arguments)argumentsAsAnonymousType).Cast<object>().ToArray();
		}

		/// <summary>
		/// Release a pre-resolved object. See Resolve methods.
		/// </summary>
		/// <param name="obj">Object to be released</param>
		public void Release(object obj)
		{
			IocContainer.Release(obj);
		}

		public void Dispose()
		{
			IocContainer.Dispose();
		}
		private static ComponentRegistration<T> ApplyLifestyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle)
		where T: class
		{
			switch (lifeStyle)
			{
				case DependencyLifeStyle.Transient:
					return registration.LifestyleTransient();
				case DependencyLifeStyle.Singleton:
					return registration.LifestyleSingleton();
				default:
					return registration;

			}
		}
		
	}
}