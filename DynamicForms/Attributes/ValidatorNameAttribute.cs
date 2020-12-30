using System;

namespace DynamicForms.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ValidatorNameAttribute : Attribute
	{
		public string ValidatorName { get; }

		public ValidatorNameAttribute(string validatorName)
		{
			ValidatorName = validatorName;
		}
	}
}
