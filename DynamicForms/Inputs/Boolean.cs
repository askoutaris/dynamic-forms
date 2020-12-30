using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class FormInput
	{
		public class Boolean : FormInput
		{
			public bool? DefaultValue { get; }

			private Boolean()
			{

			}

			public Boolean(string name, string caption, bool? defaultValue, IValidator[] validators) : base(name, caption, validators)
			{
				DefaultValue = defaultValue;
			}
		}
	}
}
