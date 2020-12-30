using System.Collections.Generic;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class FormInput
	{
		public class MultipleOptions : FormInput
		{
			public IReadOnlyDictionary<string, string> KeyValues { get; }
			public string[]? DefaultKeys { get; }
			public bool Multiple { get; }

			private MultipleOptions()
			{
				KeyValues = new Dictionary<string, string>();
			}

			public MultipleOptions(string name, string caption, IValidator[] validators, Dictionary<string, string> keyValues, string[]? defaultKeys, bool multiple) : base(name, caption, validators)
			{
				KeyValues = keyValues;
				DefaultKeys = defaultKeys;
				Multiple = multiple;
			}
		}
	}
}
