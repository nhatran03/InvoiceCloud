using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud
{
	[Serializable]
	public class InvoiceCloudException: Exception
	{
		public InvoiceCloudException()
		{

		}

		public InvoiceCloudException(SerializationInfo serializationInfo, StreamingContext context)
			:base(serializationInfo,context)
		{

		}

		public InvoiceCloudException(string message)
			: base(message)
		{

		}

		public InvoiceCloudException(string message, Exception innerException)
			:base(message, innerException)
		{

		}
	}
}
