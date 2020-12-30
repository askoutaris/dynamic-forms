using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	[ValidatorName(Constants.Validators.Min)]
	public class MinValidator : IValidator
	{
		private readonly decimal _min;

		public MinValidator(decimal min)
		{
			_min = min;
		}

		public ValidationError[] Validate(IFormInputValue inputValue)
		{
			if (inputValue is not FormInputValue.Number number)
				throw new ArgumentException($"MinValidator can only be use with Number input. Input {inputValue.Name} is {inputValue.GetType()}");

			if (number.Value < _min)
				return new[] { new ValidationError(inputValue.Name, $"Must be greater than {_min}") };

			return Array.Empty<ValidationError>();
		}
	}
}
