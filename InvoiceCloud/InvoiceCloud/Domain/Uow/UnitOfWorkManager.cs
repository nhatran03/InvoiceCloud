using InvoiceCloud.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InvoiceCloud.Domain.Uow
{
	internal class UnitOfWorkManager : IUnitOfWorkManager, ITransientDependency
	{

		private readonly IIocResolver iocResolver;
		private readonly ICurrentUnitOfWorkProvider currentUnitOfWorkProvider;
		private readonly IUnitOfWorkDefaultOptions defaultOptions;
		public IActiveUnitOfWork Current => currentUnitOfWorkProvider.Current;

		public UnitOfWorkManager(IIocResolver iocResolver,
			ICurrentUnitOfWorkProvider currentUnitOfWorkProvider,
			IUnitOfWorkDefaultOptions defaultOptions)
		{
			this.iocResolver = iocResolver;
			this.currentUnitOfWorkProvider = currentUnitOfWorkProvider;
			this.defaultOptions = defaultOptions;
		}
		public IUnitOfWorkCompleteHandle Begin()
		{
			return Begin(new UnitOfWorkOptions());
		}

		public IUnitOfWorkCompleteHandle Begin(TransactionScopeOption scope)
		{
			return Begin(new UnitOfWorkOptions { Scope = scope });
		}

		public IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options)
		{
			options.FillDefaultsForNonProvidedOptions(defaultOptions);

			if(options.Scope == TransactionScopeOption.Required && currentUnitOfWorkProvider.Current != null)
			{
				return new InnerUnitOfWorkCompleteHandle();
			}

			var uow = iocResolver.Resolve<IUnitOfWork>();
			uow.Completed += (sender, args) =>
			{
				currentUnitOfWorkProvider.Current = null;
			};

			uow.Failed += (sender, args) => {
				currentUnitOfWorkProvider.Current = null;
			};

			uow.Disposed += (sender, args) =>
			{
				iocResolver.Release(uow);
			};

			uow.Begin(options);

			currentUnitOfWorkProvider.Current = uow;

			return uow;
		}
	}
}
