using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public partial class Validator
	{
		[Alias(Constants.Validators.MaxLength)]
		public class MaxLength: IValidator
		{
			private readonly decimal _length;

			public MaxLength(decimal length)
			{
				_length = length;
			}

			public ValidationError[] Validate(IInputValue inputValue)
			{
				if (inputValue is not InputValue.Text text)
					throw new ArgumentException($"MaxLengthValidator can only be use with Text input. Input {inputValue.Name} is {inputValue.GetType()}");

				if ((text.Value ?? string.Empty).Length < _length)
					return new[] { new ValidationError(inputValue.Name, $"Must be longer than {_length}") };

				return Array.Empty<ValidationError>();
			}
		}
	}
}
