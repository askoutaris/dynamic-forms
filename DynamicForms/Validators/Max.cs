using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public partial class Validator
	{
		[Alias(Constants.Validators.Max)]
		public class Max: IValidator
		{
			private readonly decimal _max;

			public Max(decimal max)
			{
				_max = max;
			}

			public ValidationError[] Validate(IInputValue inputValue)
			{
				if (inputValue is not InputValue.Number number)
					throw new ArgumentException($"MaxValidator can only be use with Number input. Input {inputValue.Name} is {inputValue.GetType()}");

				if (number.Value > _max)
					return new[] { new ValidationError(inputValue.Name, $"Must be less than {_max}") };

				return Array.Empty<ValidationError>();
			}
		}
	}
}
