using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	[ValidatorName(Constants.Validators.MinLength)]
	public class MinLengthValidator : IValidator
	{
		private readonly decimal _minLength;

		public MinLengthValidator(decimal minLength)
		{
			_minLength = minLength;
		}

		public ValidationError[] Validate(IFormInputValue inputValue)
		{
			if (inputValue is not FormInputValue.Text text)
				throw new ArgumentException($"MinLengthValidator can only be use with Text input. Input {inputValue.Name} is {inputValue.GetType()}");

			if ((text.Value ?? string.Empty).Length < _minLength)
				return new[] { new ValidationError(inputValue.Name, $"Must be longer than {_minLength}") };

			return Array.Empty<ValidationError>();
		}
	}
}
