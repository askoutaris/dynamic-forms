using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public partial class Validator
	{
		[Alias(Constants.Validators.Min)]
		public class Min : IValidator
		{
			private readonly decimal _min;

			public Min(decimal min)
			{
				_min = min;
			}

			public ValidationError[] Validate(IInputValue inputValue)
			{
				if (inputValue is not InputValue.Number number)
					throw new ArgumentException($"MinValidator can only be use with Number input. Input {inputValue.Name} is {inputValue.GetType()}");

				if (number.Value < _min)
					return new[] { new ValidationError(inputValue.Name, $"Must be greater than {_min}") };

				return Array.Empty<ValidationError>();
			}
		}
	}
}
