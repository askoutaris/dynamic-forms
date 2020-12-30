namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		public class Number : Input
		{
			public decimal? DefaultValue { get; }
			public int Decimals { get; }

			public Number()
			{

			}

			public Number(string name, string caption, decimal? defaultValue, int decimals) : base(name, caption)
			{
				DefaultValue = defaultValue;
				Decimals = decimals;
			}
		}
	}
}
