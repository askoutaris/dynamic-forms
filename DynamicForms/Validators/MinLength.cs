using System;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public partial class Validator
	{
		[Alias(Constants.Validators.MinLength)]
		public class MinLength: IValidator
		{
			private readonly decimal _length;

			public MinLength(decimal length)
			{
				_length = length;
			}

			public ValidationError[] Validate(IInputValue inputValue)
			{
				if (inputValue is not InputValue.Text text)
					throw new ArgumentException($"MinLengthValidator can only be use with Text input. Input {inputValue.Name} is {inputValue.GetType()}");

				if ((text.Value ?? string.Empty).Length < _length)
					return new[] { new ValidationError(inputValue.Name, $"Must be longer than {_length}") };

				return Array.Empty<ValidationError>();
			}
		}
	}
}
