using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class FormInput
	{
		public class Number : FormInput
		{
			public decimal? DefaultValue { get; }
			public int Decimals { get; }

			private Number()
			{

			}

			public Number(string name, string caption, IValidator[] validators, decimal? defaultValue, int decimals) : base(name, caption, validators)
			{
				DefaultValue = defaultValue;
				Decimals = decimals;
			}
		}
	}
}
