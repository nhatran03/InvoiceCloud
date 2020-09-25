using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Configuration
{
	public interface ISettingManager
	{
		Task<string> GetSettingValueAsync(string name);

		Task<string> GetSettingValueForApplicationAsync(string name);
		Task<string> GetSettingValueForUserAsync(string name, long userId);
		Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync();
		Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync(SettingScope scopes);
		Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesForApplicationAsync();
		Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesForUserAsync(UserIdentifier user);
		Task ChangeSettingForApplicationAsync(string name, string value);
		Task ChangeSettingForUserAsync(UserIdentifier user, string name, string value);
	}
}
