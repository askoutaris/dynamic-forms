namespace DynamicForms.InputValues
{
	public abstract partial class InputValue
	{
		public string Name { get; }

		protected InputValue()
		{
			Name = string.Empty;
		}

		protected InputValue(string name)
		{
			Name = name;
		}

		public abstract object? GetValue();
	}
}
