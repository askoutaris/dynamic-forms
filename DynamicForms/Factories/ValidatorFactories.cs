using System.Collections.Generic;
using DynamicForms.Validators;

namespace DynamicForms.Factories
{
	public interface IValidatorFactory
	{
		IValidator Create(Dictionary<string, object> parameterValues);
	}

	public partial class ValidatorFactory
	{

	}
}
