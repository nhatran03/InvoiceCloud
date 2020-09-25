using AutoMapper;
using Castle.Core.Logging;
using InvoiceCloud.Configuration;
using InvoiceCloud.Domain.Uow;
using InvoiceCloud.Localization;
using InvoiceCloud.Localization.Source;
using InvoiceCloud.ObjectMapping;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud
{
	public abstract class InvoiceCloudServiceBase
	{
		public ISettingManager settingManager { get; set; }

		public IUnitOfWorkManager UnitOfWorkManager
		{
			get
			{
				if(unitOfWorkManager == null)
				{
					throw new InvoiceCloudException("Must set UnitOfWorkManager before use it.");
				}
				return unitOfWorkManager;
			}
			set
			{
				unitOfWorkManager = value;
			}
		}

		private IUnitOfWorkManager unitOfWorkManager;

		protected IActiveUnitOfWork CurrentUnitOfWork => unitOfWorkManager.Current;

		public ILocalizationManager LocalizationManager { get; set; }
		protected string LocalizationSourceName { get; set; }

		protected ILocalizationSource LocalizationSource { 
			get { 
				if(LocalizationSourceName == null)
					{
						throw new InvoiceCloudException("Must set LocalizationSourceName before, in order to get LocalizationSource");
					}
				if(localizationSource == null || localizationSource.Name != LocalizationSourceName)
					{
						localizationSource = LocalizationManager.GetSource(LocalizationSourceName);
					}
				return localizationSource;
			}}

		private ILocalizationSource localizationSource;

		public ILogger Logger { protected get; set; }
		public ObjectMapping.IObjectMapper ObjectMapper { get; set; }
		protected InvoiceCloudServiceBase()
		{
			Logger = NullLogger.Instance;
			ObjectMapper = NullObjectMapper.Instance;
			LocalizationManager = NullLocaizationManager.Instance;
		}

		protected string L(string name, params object[] args)
		{
			return LocalizationSource.GetString(name, args);
		}

		protected string L(string name, CultureInfo cultureInfo)
		{
			return LocalizationSource.GetString(name, cultureInfo);
		}

		protected string L(string name, CultureInfo cultureInfo, params object[] args)
		{
			return LocalizationSource.GetString(name, cultureInfo,args);
		}
	}
}
