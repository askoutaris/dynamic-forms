using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public interface IFormFactory
	{
		Input.FormGroup Create();
	}
}
