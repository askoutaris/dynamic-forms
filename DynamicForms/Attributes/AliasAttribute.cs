using System;

namespace DynamicForms.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class AliasAttribute : Attribute
	{
		public string TypeName { get; }

		public AliasAttribute(string validatorName)
		{
			TypeName = validatorName;
		}
	}
}
