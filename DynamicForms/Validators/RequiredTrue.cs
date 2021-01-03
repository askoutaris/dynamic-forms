using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public partial class Validator
	{
		[Alias(Constants.Validators.RequiredTrue)]
		public class RequiredTrue : IValidator
		{
			public ValidationError[] Validate(IInputValue inputValue)
			{
				if (inputValue is not InputValue.Boolean boolean)
					throw new ArgumentException($"RequiredTrueValidator can only be use with Boolean input. Input {inputValue.Name} is {inputValue.GetType()}");

				if (boolean.Value != true)
					return new[] { new ValidationError(inputValue.Name, $"Must be true") };

				return Array.Empty<ValidationError>();
			}
		}
	}
}
