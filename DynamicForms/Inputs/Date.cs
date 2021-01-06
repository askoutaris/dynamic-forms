using System;
using System.Collections.Generic;
using DynamicForms.Attributes;
using DynamicForms.Validators;

namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		[Alias(Constants.Inputs.Date)]
		public class Date : Input
		{
			public DateTime? DefaultValue { get; }
			public DateTime MinDate { get; }
			public DateTime MaxDate { get; }

			private Date()
			{

			}

			public Date(string name, string caption, IEnumerable<IValidator> validators, DateTime? defaultValue, DateTime minDate, DateTime maxDate)
				: base(name, caption, validators)
			{
				DefaultValue = defaultValue;
				MinDate = minDate;
				MaxDate = maxDate;
			}
		}
	}

}