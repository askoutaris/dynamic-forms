namespace DynamicForms.InputValues
{
	public interface IFormInputValue
	{
		string Name { get; }
		object? GetValue();
	}

	public abstract partial class FormInputValue : IFormInputValue
	{
		public string Name { get; }

		protected FormInputValue()
		{
			Name = string.Empty;
		}

		protected FormInputValue(string name)
		{
			Name = name;
		}

		public abstract object? GetValue();
	}
}
