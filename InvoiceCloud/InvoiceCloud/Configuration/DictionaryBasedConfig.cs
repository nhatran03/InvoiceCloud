using InvoiceCloud.Collections.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Configuration
{
	public class DictionaryBasedConfig : IDictionaryBasedConfig
	{
		/// <summary>
		/// Dictionary of custom configuration
		/// </summary>
		protected Dictionary<string, object> CustomSettings { get; private set; }

		/// <summary>
		/// Gets/sets a config value
		/// Returns null if no config with given name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public object this[string name]
		{
			get { return CustomSettings.GetOrDefault(name); }
			set { CustomSettings[name] = value; }
		}

		protected DictionaryBasedConfig()
		{
			CustomSettings = new Dictionary<string, object>();
		}
		public object Get(string name)
		{
			return Get(name, null);
		}

		public T Get<T>(string name)
		{
			var value = this[name];
			return value == null ?
				default(T) :
				(T)Convert.ChangeType(value, typeof(T));
		}
		public object Get(string name, object defaultValue)
		{
			var value = this[name];
			if(value == null)
			{
				return defaultValue;
			}

			return this[name];
		}

		public T Get<T>(string name, T defaultValue)
		{
			return (T)Get(name, defaultValue);
		}

		public T GetOrCreate<T>(string name, Func<T> creator)
		{
			var value = Get(name);
			if(value == null)
			{
				value = creator();
				Set(name, value);
			}

			return (T)value;
		}

		public void Set<T>(string name, T value)
		{
			this[name] = value;
		}
	}
}
