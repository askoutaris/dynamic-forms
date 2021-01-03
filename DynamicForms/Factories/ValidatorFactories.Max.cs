using System.Collections.Generic;
using DynamicForms.Validators;

namespace DynamicForms.Factories
{
	public partial class ValidatorFactory
	{
		public class Max : IValidatorFactory
		{
			public IValidator Create(Dictionary<string, object> parameterValues)
				=> TypeActivator.CreateInstance<Validator.Max>(parameterValues);
		}
	}
}
