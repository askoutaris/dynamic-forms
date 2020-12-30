namespace DynamicForms.Inputs
{
	public abstract partial class Input
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
