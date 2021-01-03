using System.Collections.Generic;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public interface IInputFactory
	{
		IInput Create(Dictionary<string, object> parameterValues);
	}

	public partial class InputFactory
	{

	}
}
