using System.Collections.Generic;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public partial class InputFactory
	{
		public class MultipleOptionsXml : IInputFactory
		{
			const string DefaultKeysKey = "defaultKeys";

			public IInput Create(Dictionary<string, object> parameterValues)
			{
				AdaptDefaultKeys(parameterValues);

				return TypeActivator.CreateInstance<Input.MultipleOptions>(parameterValues);
			}

			private void AdaptDefaultKeys(Dictionary<string, object> parameterValues)
			{
				if (parameterValues.TryGetValue(DefaultKeysKey, out object value))
				{
					var valueStr = value.ToString();
					var defaultKeys = valueStr.Split(',');
					parameterValues[DefaultKeysKey] = defaultKeys;
				}
			}
		}
	}
}
