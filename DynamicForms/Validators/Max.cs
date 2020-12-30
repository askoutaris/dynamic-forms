using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	[ValidatorName(Constants.Validators.Max)]
	public class MaxValidator : IValidator
	{
		private readonly decimal _max;

		public MaxValidator(decimal max)
		{
			_max = max;
		}

		public ValidationError[] Validate(IFormInputValue inputValue)
		{
			if (inputValue is not FormInputValue.Number number)
				throw new ArgumentException($"MaxValidator can only be use with Number input. Input {inputValue.Name} is {inputValue.GetType()}");

			if (number.Value > _max)
				return new[] { new ValidationError(inputValue.Name, $"Must be less than {_max}") };

			return Array.Empty<ValidationError>();
		}
	}
}
