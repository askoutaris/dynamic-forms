using System;

namespace DynamicForms.InputValues
{
	public abstract partial class FormInputValue
	{
		public class MultipleOptions : FormInputValue
		{
			public string[]? Keys { get; }

			private MultipleOptions()
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
