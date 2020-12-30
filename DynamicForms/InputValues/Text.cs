using System;

namespace DynamicForms.InputValues
{
	public abstract partial class FormInputValue
	{
		public class Text : FormInputValue
		{
			public string? Value { get; }

			private Text()
			{

			}

			public Text(string name, string? value) : base(name)
			{
				Value = value;
			}

			public override object? GetValue()
				=> Value;
		}
	}
}
