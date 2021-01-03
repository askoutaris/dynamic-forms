namespace DynamicForms.InputValues
{
	public abstract partial class InputValue
	{
		public class Boolean : InputValue
		{
			public bool? Value { get; }

			private Boolean()
			{

			}

			public Boolean(string name, bool? value) : base(name)
			{
				Value = value;
			}

			public override object? GetValue()
				=> Value;
		}
	}
}
