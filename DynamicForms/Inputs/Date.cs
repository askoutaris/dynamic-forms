using System;

namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		public class Date : Input
		{
			public DateTime? DefaultValue { get; }
			public DateTime MinDate { get; }
			public DateTime MaxDate { get; }

			private Date()
			{

			}

			public Date(string name, string caption, DateTime? defaultValue, DateTime minDate, DateTime maxDate) : base(name, caption)
			{
				DefaultValue = defaultValue;
				MinDate = minDate;
				MaxDate = maxDate;
			}
		}
	}

}