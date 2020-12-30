using System.Collections.Generic;
using DynamicForms.Inputs;

namespace DynamicForms
{
	public class Form
	{
		public string Name { get; }
		public string Caption { get; }
		public IReadOnlyCollection<Input> Inputs { get; }

		public Form(string name, string caption, Input[] inputs)
		{
			Name = name;
			Caption = caption;
			Inputs = inputs;
		}
	}
}
