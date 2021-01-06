using System;
using System.Collections.Generic;
using System.Linq;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public interface IInput
	{
		string Name { get; }
		string Caption { get; }
		IReadOnlyCollection<IValidator> Validators { get; }
	}

	public abstract partial class Input : IInput
	{
		public string Name { get; }
		public string Caption { get; }
		public IReadOnlyCollection<IValidator> Validators { get; }

		public Input()
		{
			Name = string.Empty;
			Caption = string.Empty;
			Validators = Array.Empty<IValidator>();
		}

		protected Input(string name, string caption, IEnumerable<IValidator> validators)
		{
			Name = name;
			Caption = caption;
			Validators = validators.ToArray();
		}
	}
}
