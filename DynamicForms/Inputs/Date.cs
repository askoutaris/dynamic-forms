using System;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class FormInput
	{
		public class Date : FormInput
		{
			public DateTime? DefaultValue { get; }
			public DateTime MinDate { get; }
			public DateTime MaxDate { get; }

			private Date()
			{

			}

			public Date(string name, string caption, IValidator[] validators, DateTime? defaultValue, DateTime minDate, DateTime maxDate) : base(name, caption, validators)
			{
				DefaultValue = defaultValue;
				MinDate = minDate;
				MaxDate = maxDate;
			}
		}
	}

}