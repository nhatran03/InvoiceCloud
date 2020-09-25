using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Uow
{
	public interface IUnitOfWorkFilterExecuter
	{
		void ApplyDisableFilter(IUnitOfWork unitOfWork, string filterName);
		void ApplyEnableFilter(IUnitOfWork unitOfWork, string filterName);
		void ApplyFilterParameterValue(IUnitOfWork unitOfWork, string filterName, string parameterName, object value);
	}
}
