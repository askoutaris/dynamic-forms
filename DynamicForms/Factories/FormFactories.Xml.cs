using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DynamicForms.Inputs;
using DynamicForms.Validators;

namespace DynamicForms.Factories
{
	public class XmlFormFactory : FormFactoryBase
	{
		private readonly string _xmlFilePath;

		public XmlFormFactory(string xmlFullFilePath, IEnumerable<InputFactorySet> inputFactories, IEnumerable<ValidatorFactorySet> validatorFactories)
			: base(inputFactories, validatorFactories)
		{
			_xmlFilePath = xmlFullFilePath;
		}

		public override Input.FormGroup Create()
		{
			var doc = XDocument.Load(_xmlFilePath);
			var formElement = doc.Descendants("formGroup").First();
			var formName = formElement.Attribute("name").Value;
			var formCaption = formElement.Attribute("caption").Value;
			var inputs = GetInputs(formElement);

			return new Input.FormGroup(formName, formCaption, inputs.ToArray(), Array.Empty<IValidator>());
		}

		private List<IInput> GetInputs(XElement formElement)
		{
			var inputs = new List<IInput>();
			foreach (var inputElement in formElement.Descendants("input"))
			{
				var validators = GetValidators(inputElement);

				var parameterValues = new Dictionary<string, object>() { { "validators", validators } };
				foreach (var attribute in inputElement.Attributes())
					parameterValues.Add(attribute.Name.ToString(), attribute.Value);

				var inputAlias = inputElement.Attribute("alias").Value;
				var input = CreateInput(inputAlias, parameterValues);
				inputs.Add(input);
			}

			return inputs;
		}
		private IValidator[] GetValidators(XElement inputElement)
		{
			var validatorsAttribute = inputElement.Attribute("validators");
			if (validatorsAttribute == null)
				return Array.Empty<IValidator>();

			var validators = new List<IValidator>();
			var validatorData = validatorsAttribute.Value.Split(';');
			foreach (var data in validatorData)
			{
				var validatorAlias = Constants.Regex.ValidatorName.Match(data).Value;
				var validatorParameters = GetValidatorParameters(data);
				var validator = CreateValidator(validatorAlias, validatorParameters);
				validators.Add(validator);
			}

			return validators.ToArray();
		}
		private Dictionary<string, object> GetValidatorParameters(string validatorStr)
		{
			var parameters = new Dictionary<string, object>();

			var pipeParametersMatch = Constants.Regex.ValidatorParameters.Match(validatorStr);
			if (pipeParametersMatch.Success)
			{
				var parameterPairs = pipeParametersMatch.ToString().Split(',');
				foreach (var pair in parameterPairs)
				{
					var parts = pair.Split('=');
					if (parts.Length != 2)
						throw new Exception($"Invalid pipe parameters {parameterPairs} in {validatorStr}");

					var name = parts[0];
					var value = parts[1];
					parameters.Add(name, value);
				}
			}

			return parameters;
		}
	}
}
