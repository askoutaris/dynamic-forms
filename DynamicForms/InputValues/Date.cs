using System;

namespace DynamicForms.InputValues
{
	public abstract partial class InputValue
	{
		public class Date : InputValue
		{
			public DateTime? Value { get; }

			private Date()
			{

			}

			public Date(string name, DateTime? value)
				: base(name)
			{
				Value = value;
			}

			public override object? GetValue()
				=> Value;
		}
	}
}
