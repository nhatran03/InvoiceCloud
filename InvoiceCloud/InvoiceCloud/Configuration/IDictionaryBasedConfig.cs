﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Configuration
{
	interface IDictionaryBasedConfig
	{
		/// <summary>
		/// Used to set a string named configuration.
		/// If there is already a configuration with same <paramref name="name"/>, It's overwriten
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">Unique name of the configuration</param>
		/// <param name="value">Value of the configuration</param>
		/// <return>Returns the passed <paramref name="value"/></return>
		void Set<T>(string name, T value);

		/// <summary>
		/// Gets a configuration object with given name.
		/// </summary>
		/// <param name="name">Unique name of the configuration</param>
		/// <returns>Value of the configuration or null if not found</returns>
		object Get(string name);

		/// <summary>
		/// Gets a configuration object with given name.
		/// </summary>
		/// <typeparam name="T">Type of the object</typeparam>
		/// <param name="name">Unique name of the configuration</param>
		/// <returns>Value of configuration or null if not found</returns>
		T Get<T>(string name);

		/// <summary>
		/// Gets a configuration object with given name
		/// </summary>
		/// <param name="name">Unique name of the configuration</param>
		/// <param name="defaultValue">Default value of the object if can not found given configuration</param>
		/// <returns>Value of the configuration or null if not found</returns>
		object Get(string name, object defaultValue);

		/// <summary>
		/// Gets a configuration object with given name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">Unique name of the configuration</param>
		/// <param name="defaultValue">Default value of the object if can not found given configuration</param>
		/// <returns>Value of the configuration or null if not found</returns>
		T Get<T>(string name, T defaultValue);

		/// <summary>
		/// Gets a configuration object with given name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">Unique name of the configuration</param>
		/// <param name="creator">The function that will be called to create if given configuration is not found</param>
		/// <returns>Value of the configuration or null if not found</returns>
		T GetOrCreate<T>(string name, Func<T> creator);
	}
}
