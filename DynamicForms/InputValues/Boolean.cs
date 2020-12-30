namespace DynamicForms.InputValues
{
	public abstract partial class FormInputValue
	{
		public class Boolean : FormInputValue
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
