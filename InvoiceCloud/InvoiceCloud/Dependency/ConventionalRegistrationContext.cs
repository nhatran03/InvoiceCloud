﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Dependency
{
	/// <summary>
	/// This class is used to pass needed objects on conventional registration process
	/// </summary>
	class ConventionalRegistrationContext : IConventionalRegistrationContext
	{
		/// <summary>
		/// Gets the registering Assembly
		/// </summary>
		public Assembly Assembly { get; private set; }

		/// <summary>
		/// Reference to the IOC Container to register types
		/// </summary>
		public IIocManager IocManager { get; private set; }

		/// <summary>
		/// Registration configuration
		/// </summary>
		public ConventionalRegistrationConfig Config { get; private set; }

		internal ConventionalRegistrationContext(Assembly assembly, IIocManager iocManager, ConventionalRegistrationConfig config)
		{
			Assembly = assembly;
			IocManager = IocManager;
			Config = config;
		}
	}
}
