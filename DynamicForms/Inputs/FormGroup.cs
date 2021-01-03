using System;
using System.Collections.Generic;
using System.Linq;
using DynamicForms.Attributes;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		[Alias(Constants.Inputs.FormGroup)]
		public class FormGroup : Input
		{
			public IReadOnlyCollection<IInput> Inputs { get; }

			private FormGroup()
			{
				Inputs = Array.Empty<IInput>();
			}

			public FormGroup(string name, string caption, IEnumerable<IInput> inputs, IEnumerable<IValidator> validators) : base(name, caption, validators)
			{
				Inputs = inputs.ToArray();
			}
		}
	}
}
