using System;

namespace DynamicForms.InputValues
{
	public abstract partial class FormInputValue
	{
		public class Number : FormInputValue
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
