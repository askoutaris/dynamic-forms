using System.Collections.Generic;
using DynamicForms.Attributes;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		[Alias(Constants.Inputs.Boolean)]
		public class Boolean : Input
		{
			public bool? DefaultValue { get; }

			private Boolean()
			{

			}

			public Boolean(string name, string caption, bool? defaultValue, IEnumerable<IValidator> validators) : base(name, caption, validators)
			{
				DefaultValue = defaultValue;
			}
		}
	}
}
