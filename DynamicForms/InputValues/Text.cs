using System;

namespace DynamicForms.InputValues
{
	public abstract partial class InputValue
	{
		public class Text : InputValue
		{
			public string? Value { get; }

			public Text()
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
