using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class FormInput
	{
		public class Text : FormInput
		{
			public string? DefaultValue { get; }

			private Text()
			{

			}

			public Text(string name, string caption, IValidator[] validators, string? defaultValue) : base(name, caption, validators)
			{
				DefaultValue = defaultValue;
			}
		}
	}
}
