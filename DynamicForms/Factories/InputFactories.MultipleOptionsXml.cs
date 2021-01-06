using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public partial class InputFactory
	{
		public class MultipleOptionsXml : IInputFactory
		{
			const string _defaultKeysKey = "defaultKeys";

			private readonly Dictionary<string, IKeyValueFactory> _sourceFactories;

			public MultipleOptionsXml(IEnumerable<KeyValueFactorySet> sourceFactories)
			{
				_sourceFactories = sourceFactories.ToDictionary(set => set.Name, set => set.Factory);
			}

			public async Task<IInput> Create(Dictionary<string, object> parameterValues)
			{
				AdaptDefaultKeys(parameterValues);
				await AdaptKeyValues(parameterValues);

				return TypeActivator.CreateInstance<Input.MultipleOptions>(parameterValues);
			}

			private void AdaptDefaultKeys(Dictionary<string, object> parameterValues)
			{
				if (parameterValues.TryGetValue(_defaultKeysKey, out object value))
				{
					var valueStr = value.ToString();
					var defaultKeys = valueStr.Split(',');
					parameterValues[_defaultKeysKey] = defaultKeys;
				}
			}

			private async Task AdaptKeyValues(Dictionary<string, object> parameterValues)
			{
				var factoryName = parameterValues["source"].ToString();
				var factory = _sourceFactories[factoryName];
				var keyValues = await factory.GetValues(parameterValues);
				parameterValues["keyValues"] = keyValues;
			}
		}
	}
}
