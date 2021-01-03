namespace DynamicForms
{
	public static class Constants
	{
		public static class Inputs
		{
			public const string Boolean = "boolean";
			public const string Date = "date";
			public const string FormGroup = "formgroup";
			public const string MultipleOptions = "multipleoptions";
			public const string Number = "number";
			public const string Text = "text";
		}

		public static class Validators
		{
			public const string Email = "email";
			public const string Max = "max";
			public const string MaxLength = "maxlength";
			public const string Min = "min";
			public const string MinLength = "minlength";
			public const string Pattern = "pattern";
			public const string Required = "required";
			public const string RequiredTrue = "requiredtrue";
		}

		public static class Regex
		{
			public static readonly System.Text.RegularExpressions.Regex DateExpressionXml = new System.Text.RegularExpressions.Regex($@"((?<{Keys.Sign}>[\+\-])?(?<{Keys.Amount}>\d*)(?<{Keys.Unit}>[YyMmDdHhMmSs]))");
			public static readonly System.Text.RegularExpressions.Regex Email = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			public static readonly System.Text.RegularExpressions.Regex ValidatorName = new System.Text.RegularExpressions.Regex(@"(((.*?)(?=\:))|^((?!\:).)*$)");
			public static readonly System.Text.RegularExpressions.Regex ValidatorParameters = new System.Text.RegularExpressions.Regex(@"(?<=\:)(.*)[^}]");

			public static class Keys
			{
				public const string Sign = "sign";
				public const string Amount = "amount";
				public const string Unit = "unit";
			}
		}
	}
}
