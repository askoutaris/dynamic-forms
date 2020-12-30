namespace DynamicForms.Inputs
{
	public interface IInput
	{
		string Name { get; }
		string Caption { get; }
	}

	public abstract partial class Input : IInput
	{
		public string Name { get; }
		public string Caption { get; }

		public Input()
		{
			Name = string.Empty;
			Caption = string.Empty;
		}

		protected Input(string name, string caption)
		{
			Name = name;
			Caption = caption;
		}
	}
}
