using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public partial class Validator
	{
		[Alias(Constants.Validators.Required)]
		public class Required: IValidator
		{
			public ValidationError[] Validate(IInputValue inputValue)
			{
				if (inputValue is InputValue.MultipleOptions multipleOptions)
					return ValidateMultipleOptions(multipleOptions);
				else
					return ValidateDefault(inputValue);
			}

			private ValidationError[] ValidateDefault(IInputValue inputValue)
			{
				if (inputValue.GetValue() == null)
					return new[] { new ValidationError(inputValue.Name, "Required") };

				return Array.Empty<ValidationError>();
			}

			private ValidationError[] ValidateMultipleOptions(InputValue.MultipleOptions multipleOptions)
			{
				if (multipleOptions.Keys == null || multipleOptions.Keys.Length == 0)
					return new[] { new ValidationError(multipleOptions.Name, "Is required") };

				return Array.Empty<ValidationError>();
			}
		}
	}
}
