using System;
using System.Collections.Generic;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public interface IFormInput
	{
		string Name { get; }
		string Caption { get; }
	}

	public abstract partial class FormInput : IFormInput
	{
		public string Name { get; }
		public string Caption { get; }
		public IReadOnlyCollection<IValidator> Validators { get; }

		public FormInput()
		{
			Name = string.Empty;
			Caption = string.Empty;
			Validators = Array.Empty<IValidator>();
		}

		protected FormInput(string name, string caption, IReadOnlyCollection<IValidator> validators)
		{
			Name = name;
			Caption = caption;
			Validators = validators;
		}
	}
}
