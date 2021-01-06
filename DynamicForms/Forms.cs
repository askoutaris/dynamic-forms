using System;
using System.Collections.Generic;
using System.Linq;
using DynamicForms.Inputs;
using DynamicForms.InputValues;
using DynamicForms.Validators;

namespace DynamicForms
{
	public interface IForm
	{
		string Name { get; }
		IReadOnlyCollection<IInput> Inputs { get; }
		ValidationError[] Validate(IInputValue[] values);
	}

	public class Form : IForm
	{
		public string Name { get; }
		public string Caption { get; }
		public IReadOnlyCollection<IInput> Inputs { get; }

		public Form(string name, string caption, IReadOnlyCollection<IInput> inputs)
		{
			Name = name;
			Caption = caption;
			Inputs = inputs;
		}

		public ValidationError[] Validate(IInputValue[] values)
		{
			return ValidateInternal(Inputs.ToArray(), values);
		}

		private ValidationError[] ValidateInternal(IInput[] inputs, params IInputValue[] values)
		{
			var validatorErrors = new List<ValidationError>();
			foreach (var input in inputs)
			{
				var inputValue = values.SingleOrDefault(x => x.Name == input.Name);
				if (inputValue == null)
					throw new Exception($"InputValue not found for input {input.Name}");

				foreach (var validator in input.Validators)
				{
					var errors = validator.Validate(inputValue);
					validatorErrors.AddRange(errors);
				}

				if (input is Input.FormGroup group)
				{
					if (inputValue is not InputValue.FormGroup groupValue)
						throw new Exception($"Value for group {group.Name} must be of type {nameof(InputValue.FormGroup)}");

					var errors = ValidateInternal(group.Inputs.ToArray(), groupValue.Value.ToArray());
					validatorErrors.AddRange(errors);
				}
			}

			return validatorErrors.ToArray();
		}
	}
}
