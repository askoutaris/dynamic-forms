using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DynamicForms.Inputs;
using DynamicForms.Validators;

namespace DynamicForms.Factories
{
	public class XmlFormFactory : FormFactoryBase
	{
		const string _validatorsKey = "validators";
		private readonly string _xmlFilePath;

		public XmlFormFactory(string xmlFullFilePath, IEnumerable<InputFactorySet> inputFactories, IEnumerable<ValidatorFactorySet> validatorFactories)
			: base(inputFactories, validatorFactories)
		{
			_xmlFilePath = xmlFullFilePath;
		}

		public override async Task<Input.FormGroup> Create()
		{
			var doc = XDocument.Load(_xmlFilePath);
			var formElement = doc.Descendants("formGroup").First();
			var formName = formElement.Attribute("name").Value;
			var formCaption = formElement.Attribute("caption").Value;
			var inputs = await GetInputs(formElement);

			return new Input.FormGroup(formName, formCaption, inputs.ToArray(), Array.Empty<IValidator>());
		}

		private async Task<List<IInput>> GetInputs(XElement groupElement)
		{
			var inputs = new List<IInput>();
			foreach (var element in groupElement.Elements())
			{
				var parameterValues = new Dictionary<string, object>();
				foreach (var attribute in element.Attributes())
				{
					switch (attribute.Name.ToString())
					{
						case _validatorsKey:
							var validators = GetValidators(element);
							parameterValues.Add(attribute.Name.ToString(), validators);
							break;
						default:
							parameterValues.Add(attribute.Name.ToString(), attribute.Value);
							break;
					}
				}

				if (!parameterValues.ContainsKey(_validatorsKey))
					parameterValues.Add(_validatorsKey, Array.Empty<IValidator>());

				if (element.Name == "group")
				{
					var groupInputs = await GetInputs(element);
					parameterValues.Add("inputs", groupInputs);
					var input = await CreateInput(Constants.Inputs.FormGroup, parameterValues);
					inputs.Add(input);
				}
				else
				{
					var inputAlias = element.Attribute("type").Value;
					var input = await CreateInput(inputAlias, parameterValues);
					inputs.Add(input);
				}
			}

			return inputs;
		}
		private IValidator[] GetValidators(XElement inputElement)
		{
			var validatorsAttribute = inputElement.Attribute(_validatorsKey);
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
