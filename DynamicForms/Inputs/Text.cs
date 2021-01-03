using System.Collections.Generic;
using DynamicForms.Attributes;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		[Alias(Constants.Inputs.Text)]
		public class Text : Input
		{
			public string? DefaultValue { get; }

			private Text()
			{

			}

			public Text(string name, string caption, IEnumerable<IValidator> validators, string? defaultValue) : base(name, caption, validators)
			{
				DefaultValue = defaultValue;
			}
		}
	}
}
