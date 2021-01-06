using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicForms.Factories
{
	public interface IKeyValueFactory
	{
		Task<Dictionary<string, string>> GetValues(Dictionary<string, object> parameterValues);
	}
}
