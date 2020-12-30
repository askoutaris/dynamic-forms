using System;

namespace DynamicForms.InputValues
{
	public abstract partial class InputValue
	{
		public class MultipleOptions : InputValue
		{
			public string[]? Keys { get; }

			public MultipleOptions()
			{

			}

			public MultipleOptions(string name, string[]? keys) : base(name)
			{
				Keys = keys;
			}

			public override object? GetValue()
				=> Keys;
		}
	}
}
