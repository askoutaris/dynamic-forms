using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	[ValidatorName(Constants.Validators.RequiredTrue)]
	public class RequiredTrueValidator : IValidator
	{
		public ValidationError[] Validate(IFormInputValue inputValue)
		{
			if (inputValue is not FormInputValue.Boolean boolean)
				throw new ArgumentException($"RequiredTrueValidator can only be use with Boolean input. Input {inputValue.Name} is {inputValue.GetType()}");

			if (boolean.Value != true)
				return new[] { new ValidationError(inputValue.Name, $"Must be true") };

			return Array.Empty<ValidationError>();
		}
	}
}
