using System;
using System.Text.RegularExpressions;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	[ValidatorName(Constants.Validators.Pattern)]
	public class PatternValidator : IValidator
	{
		private readonly string _pattern;

		public PatternValidator(string pattern)
		{
			_pattern = pattern;
		}

		public ValidationError[] Validate(IFormInputValue inputValue)
		{
			if (inputValue is not FormInputValue.Text text)
				throw new ArgumentException($"PatternValidator can only be use with Text input. Input {inputValue.Name} is {inputValue.GetType()}");

			if (!Regex.IsMatch(text.Value ?? string.Empty, _pattern))
				return new[] { new ValidationError(inputValue.Name, $"Is not valid") };

			return Array.Empty<ValidationError>();
		}
	}
}
