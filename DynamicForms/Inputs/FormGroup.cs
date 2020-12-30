using System;
using System.Collections.Generic;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class FormInput
	{
		public class FormGroup : FormInput
		{
			public IReadOnlyCollection<FormInput> Inputs { get; }

			private FormGroup()
			{
				Inputs = Array.Empty<FormInput>();
			}

			public FormGroup(string name, string caption, FormInput[] inputs, IValidator[] validators) : base(name, caption, validators)
			{
				Inputs = inputs;
			}
		}
	}
}
