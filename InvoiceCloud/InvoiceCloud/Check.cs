using Castle.Core.Internal;
using InvoiceCloud.Extensions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud
{
	[DebuggerStepThrough]
	public static class Check
	{
		[ContractAnnotation("value:null => halt")]
		public static T NotNull<T>(T value,[InvokerParameterName][NotNull] string parameterName)
		{
			if(value == null)
			{
				throw new ArgumentNullException(parameterName);
			}

			return value;
		}

		public static string NotNullOrWhiteSpace(string value, [InvokerParameterName][NotNull] string parameterName)
		{
			if (value.IsNullOrWhiteSpace())
			{
				throw new ArgumentNullException($"{parameterName} can not be null, empty or white space!", parameterName);
			}

			return value;
		}

		public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> value, [InvokerParameterName][NotNull] string parameterName)
		{
			if (value.IsNullOrEmpty())
			{
				throw new ArgumentException(parameterName + " can not be null or empty!", parameterName);
			}

			return value;
		}
	}
}
