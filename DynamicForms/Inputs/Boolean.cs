﻿namespace DynamicForms.Inputs
{
	public abstract partial class Input
	{
		public class Boolean : Input
		{
			public bool? DefaultValue { get; }

			public Boolean()
			{

			}

			public Boolean(string name, string caption, bool? defaultValue) : base(name, caption)
			{
				DefaultValue = defaultValue;
			}
		}
	}
}