using System;

namespace DynamicForms.InputValues
{
	public abstract partial class InputValue
	{
		public class Number : InputValue
		{
			public decimal? Value { get; }

			private Number()
			{

			}

			public Number(string name, decimal? value) : base(name)
			{
				Value = value;
			}

			public override object? GetValue()
				=> Value;
		}
	}
}
