using System.Collections.Generic;
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
			throw new System.NotImplementedException();
		}
	}
}
