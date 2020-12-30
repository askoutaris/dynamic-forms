using System.Collections.Generic;
using DynamicForms.Inputs;

namespace DynamicForms
{
	public class FormGroup
	{
		public string Name { get; }
		public string Caption { get; }
		public IReadOnlyCollection<Inputs.FormInput> Inputs { get; }

		public FormGroup(string name, string caption, Inputs.FormInput[] inputs)
		{
			Name = name;
			Caption = caption;
			Inputs = inputs;
		}
	}
}
