using System.Collections.Generic;
using DynamicForms.Attributes;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		[Alias(Constants.Inputs.Number)]
		public class Number : Input
		{
			public decimal? DefaultValue { get; }
			public int Decimals { get; }

			private Number()
			{

			}

			public Number(string name, string caption, IEnumerable<IValidator> validators, decimal? defaultValue, int decimals)
				: base(name, caption, validators)
			{
				DefaultValue = defaultValue;
				Decimals = decimals;
			}
		}
	}
}
