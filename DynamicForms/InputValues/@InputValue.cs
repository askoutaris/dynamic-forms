namespace DynamicForms.InputValues
{
	public interface IInputValue
	{
		string Name { get; }
		object? GetValue();
	}

	public abstract partial class InputValue : IInputValue
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
