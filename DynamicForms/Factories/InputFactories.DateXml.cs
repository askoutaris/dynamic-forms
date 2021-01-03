using System.Collections.Generic;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public partial class InputFactory
	{
		public class DateXml : IInputFactory
		{
			public IInput Create(Dictionary<string, object> parameterValues)
				=> TypeActivator.CreateInstance<Input.Date>(parameterValues);
		}
	}
}
