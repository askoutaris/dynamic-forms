using System.Collections.Generic;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public partial class InputFactory
	{
		public class MultipleOptions : IInputFactory
		{
			public IInput Create(Dictionary<string, object> parameterValues)
				=> TypeActivator.CreateInstance<Input.MultipleOptions>(parameterValues);
		}
	}
}
