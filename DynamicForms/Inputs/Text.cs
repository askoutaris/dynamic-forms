namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		public class Text : Input
		{
			public string? DefaultValue { get; }

			public Text()
			{

			}

			public Text(string name, string caption, string? defaultValue) : base(name, caption)
			{
				DefaultValue = defaultValue;
			}
		}
	}
}
