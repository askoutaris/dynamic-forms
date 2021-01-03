using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public partial class Validator
	{
		[Alias(Constants.Validators.Email)]
		public class Email : IValidator
		{
			public ValidationError[] Validate(IInputValue inputValue)
			{
				if (inputValue is not InputValue.Text text)
					throw new ArgumentException($"EmailValidator can only be use with Text input. Input {inputValue.Name} is {inputValue.GetType()}");

				if (!Constants.Regex.Email.IsMatch(text.Value ?? string.Empty))
					return new[] { new ValidationError(inputValue.Name, $"Is not a valid email address") };

				return Array.Empty<ValidationError>();
			}
		}
	}
}
