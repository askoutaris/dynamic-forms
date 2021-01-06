namespace DynamicForms.Factories
{
	public class InputFactorySet
	{
		public string InputAlias { get; }
		public IInputFactory Factory { get; }

		public InputFactorySet(string inputAlias, IInputFactory factory)
		{
			InputAlias = inputAlias;
			Factory = factory;
		}
	}

	public class ValidatorFactorySet
	{
		public string ValidatorAlias { get; }
		public IValidatorFactory Factory { get; }

		public ValidatorFactorySet(string validatorAlias, IValidatorFactory factory)
		{
			ValidatorAlias = validatorAlias;
			Factory = factory;
		}
	}

	public class KeyValueFactorySet
	{
		public string Name { get; }
		public IKeyValueFactory Factory { get; }

		public KeyValueFactorySet(string name, IKeyValueFactory factory)
		{
			Name = name;
			Factory = factory;
		}
	}
}
