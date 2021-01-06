using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public partial class InputFactory
	{
		public class Date : IInputFactory
		{
			public Task<IInput> Create(Dictionary<string, object> parameterValues)
				=> Task.FromResult<IInput>(TypeActivator.CreateInstance<Input.Date>(parameterValues));
		}
	}
}
