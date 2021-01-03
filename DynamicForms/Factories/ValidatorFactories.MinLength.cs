using System.Collections.Generic;
using DynamicForms.Validators;

namespace DynamicForms.Factories
{
	public partial class ValidatorFactory
	{
		public class MinLength : IValidatorFactory
		{
			public IValidator Create(Dictionary<string, object> parameterValues)
				=> TypeActivator.CreateInstance<Validator.MinLength>(parameterValues);
		}
	}
}
