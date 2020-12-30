using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	[ValidatorName(Constants.Validators.Email)]
	public class EmailValidator : IValidator
	{
		public ValidationError[] Validate(IFormInputValue inputValue)
		{
			if (inputValue is not FormInputValue.Text text)
				throw new ArgumentException($"EmailValidator can only be use with Text input. Input {inputValue.Name} is {inputValue.GetType()}");

			if (!Constants.Regex.Email.IsMatch(text.Value ?? string.Empty))
				return new[] { new ValidationError(inputValue.Name, $"Is not a valid email address") };

			return Array.Empty<ValidationError>();
		}
	}
}
