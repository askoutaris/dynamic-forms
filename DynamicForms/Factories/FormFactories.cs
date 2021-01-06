using System.Threading.Tasks;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public interface IFormFactory
	{
		Task<Input.FormGroup> Create();
	}
}
