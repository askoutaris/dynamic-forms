using System;
using System.Collections.Generic;

namespace DynamicForms.InputValues
{
	public abstract partial class InputValue
	{
		public class FormGroup : InputValue
		{
			public IReadOnlyCollection<IInputValue> Value { get; }

			private FormGroup()
			{
				Value = Array.Empty<IInputValue>();
			}

			public FormGroup(string name, IInputValue[] value)
				: base(name)
			{
				Value = value;
			}

			public override object? GetValue()
				=> Value;
		}
	}
}
