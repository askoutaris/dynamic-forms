using System;

namespace DynamicForms.InputValues
{
	public abstract partial class FormInputValue
	{
		public class Date : FormInputValue
		{
			public DateTime? Value { get; }

			private Date()
			{

			}

			public Date(string name, DateTime? value) : base(name)
			{
				Value = value;
			}

			public override object? GetValue()
				=> Value;
		}
	}
}
