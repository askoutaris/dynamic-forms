using System;
using System.Text.RegularExpressions;
using DynamicForms.Attributes;
using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public partial class Validator
	{
		[Alias(Constants.Validators.Pattern)]
		public class Pattern : IValidator
		{
			private readonly string _pattern;

			public Pattern(string pattern)
			{
				_pattern = pattern;
			}

			public ValidationError[] Validate(IInputValue inputValue)
			{
				if (inputValue is not InputValue.Text text)
					throw new ArgumentException($"PatternValidator can only be use with Text input. Input {inputValue.Name} is {inputValue.GetType()}");

				if (!Regex.IsMatch(text.Value ?? string.Empty, _pattern))
					return new[] { new ValidationError(inputValue.Name, $"Is not valid") };

				return Array.Empty<ValidationError>();
			}
		}
	}
}
