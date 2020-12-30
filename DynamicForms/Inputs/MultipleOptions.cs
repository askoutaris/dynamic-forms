using System.Collections.Generic;

namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		public class MultipleOptions : Input
		{
			public IReadOnlyDictionary<string, string> KeyValues { get; }
			public string[]? DefaultKeys { get; }
			public bool Multiple { get; }

			private MultipleOptions()
			{
				KeyValues = new Dictionary<string, string>();
			}

			public MultipleOptions(string name, string caption, Dictionary<string, string> keyValues, string[]? defaultKeys, bool multiple) : base(name, caption)
			{
				KeyValues = keyValues;
				DefaultKeys = defaultKeys;
				Multiple = multiple;
			}
		}
	}
}
