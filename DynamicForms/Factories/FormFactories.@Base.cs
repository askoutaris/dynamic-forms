using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicForms.Inputs;
using DynamicForms.Validators;

namespace DynamicForms.Factories
{
	public abstract class FormFactoryBase : IFormFactory
	{
		private readonly Dictionary<string, IInputFactory> _inputFactories; // input alias - input factory
		private readonly Dictionary<string, IValidatorFactory> _validatorFactories; // validator alias - validator factory

		public FormFactoryBase(IEnumerable<InputFactorySet> inputFactories, IEnumerable<ValidatorFactorySet> validatorFactories)
		{
			_inputFactories = new();
			_validatorFactories = new();

			foreach (var set in inputFactories)
				RegisterInputFactory(set.InputAlias, set.Factory);
			foreach (var set in validatorFactories)
				RegisterValidatorFactory(set.ValidatorAlias, set.Factory);
		}

		public abstract Task<Input.FormGroup> Create();

		public void RegisterInputFactory(string inputAlias, IInputFactory factory)
		{
			if (_inputFactories.ContainsKey(inputAlias))
				throw new Exception($"Factory {factory.GetType().FullName} for input with alias ({inputAlias}) is already registered");

			_inputFactories.Add(inputAlias, factory);
		}

		public void RegisterValidatorFactory(string validatorAlias, IValidatorFactory factory)
		{
			if (_validatorFactories.ContainsKey(validatorAlias))
				throw new Exception($"Factory {factory.GetType().FullName} for validator with alias ({validatorAlias}) is already registered");

			_validatorFactories.Add(validatorAlias, factory);
		}

		protected async Task<IInput> CreateInput(string inputAlias, Dictionary<string, object> parameterValues)
		{
			if (!_inputFactories.TryGetValue(inputAlias, out IInputFactory factory))
				throw new Exception($"No factory found for input {inputAlias}. Consider registering the corresponding factory using RegisterInputFactory() method");

			return await factory.Create(parameterValues);
		}

		protected IValidator CreateValidator(string validatorAlias, Dictionary<string, object> parameterValues)
		{
			if (!_validatorFactories.TryGetValue(validatorAlias, out IValidatorFactory factory))
				throw new Exception($"No factory found for validator {validatorAlias}. Consider registering the corresponding factory using RegisterValidatorFactory() method");

			return factory.Create(parameterValues);
		}
	}
}
