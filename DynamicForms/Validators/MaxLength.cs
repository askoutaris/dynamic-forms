using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	[ValidatorName(Constants.Validators.MaxLength)]
	public class MaxLengthValidator : IValidator
	{
		private readonly decimal _maxLength;

		public MaxLengthValidator(decimal maxLength)
		{
			_maxLength = maxLength;
		}

		public ValidationError[] Validate(IFormInputValue inputValue)
		{
			if (inputValue is not FormInputValue.Text text)
				throw new ArgumentException($"MaxLengthValidator can only be use with Text input. Input {inputValue.Name} is {inputValue.GetType()}");

			if ((text.Value ?? string.Empty).Length < _maxLength)
				return new[] { new ValidationError(inputValue.Name, $"Must be longer than {_maxLength}") };

			return Array.Empty<ValidationError>();
		}
	}
}
