using AutoMapper;
using InvoiceCloud.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.ObjectMapping
{
	public sealed class NullObjectMapper : IObjectMapper, ISingletonDependency
	{
		public static NullObjectMapper Instance => SingletonInstance;

		private static readonly NullObjectMapper SingletonInstance = new NullObjectMapper();
		public TDestination Map<TDestination>(object source)
		{
			throw new InvoiceCloudException("InvoiceCloud.ObjectMapping.ObjectMapper should be implemented in order to map objects");
		}

		public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			throw new InvoiceCloudException("InvoiceCloud.ObjectMapping.ObjectMapper should be implemented in order to map objects");
		}
	}
}
