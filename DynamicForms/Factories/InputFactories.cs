using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public interface IInputFactory
	{
		Task<IInput> Create(Dictionary<string, object> parameterValues);
	}

	public partial class InputFactory
	{

	}
}
