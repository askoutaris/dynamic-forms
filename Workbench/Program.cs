using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicForms;
using DynamicForms.Factories;

namespace Workbench
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var keyValueFactories = new KeyValueFactorySet[] {
				new KeyValueFactorySet("COMPETITION_CONTEXTS",new CompetitionContextsKeyValueFactory()),
				new KeyValueFactorySet("xml",new XmlKeyValueFactory()),
			};

			var inputFactories = new InputFactorySet[] {
				new InputFactorySet(Constants.Inputs.Boolean, new InputFactory.Boolean()),
				new InputFactorySet(Constants.Inputs.Date, new InputFactory.DateXml()),
				new InputFactorySet(Constants.Inputs.FormGroup, new InputFactory.FormGroup()),
				new InputFactorySet(Constants.Inputs.MultipleOptions, new InputFactory.MultipleOptionsXml(keyValueFactories)),
				new InputFactorySet(Constants.Inputs.Number, new InputFactory.Number()),
				new InputFactorySet(Constants.Inputs.Text, new InputFactory.Text()),
			};

			var validatorFactories = new ValidatorFactorySet[] {
				new ValidatorFactorySet(Constants.Validators.Email, new ValidatorFactory.Email()),
				new ValidatorFactorySet(Constants.Validators.Max, new ValidatorFactory.Max()),
				new ValidatorFactorySet(Constants.Validators.MaxLength, new ValidatorFactory.MaxLength()),
				new ValidatorFactorySet(Constants.Validators.Min, new ValidatorFactory.Min()),
				new ValidatorFactorySet(Constants.Validators.MinLength, new ValidatorFactory.MinLength()),
				new ValidatorFactorySet(Constants.Validators.Pattern, new ValidatorFactory.Pattern()),
				new ValidatorFactorySet(Constants.Validators.Required, new ValidatorFactory.Required()),
				new ValidatorFactorySet(Constants.Validators.RequiredTrue, new ValidatorFactory.RequiredTrue()),
			};

			var factory = new XmlFormFactory("XMLFile.xml", inputFactories, validatorFactories);
			var form = await factory.Create();

			Console.WriteLine("Hello World!");
		}
	}

	class CompetitionContextsKeyValueFactory : IKeyValueFactory
	{
		public Task<Dictionary<string, string>> GetValues(Dictionary<string, object> parameterValues)
		{
			return Task.FromResult(new Dictionary<string, string> {
				{ "SOCCER","Soccer" },
				{ "BASKETBALL","Basketball" }
			});
		}
	}

	class XmlKeyValueFactory : IKeyValueFactory
	{
		public Task<Dictionary<string, string>> GetValues(Dictionary<string, object> parameterValues)
		{
			var keyValues = new Dictionary<string, string>();
			if (parameterValues.TryGetValue("sourceValues", out object value))
			{
				var valuesStr = value.ToString();
				var pairs = valuesStr.Split(',');
				foreach (var pair in pairs)
				{
					var parts = pair.Split(':');
					keyValues.Add(parts[0], parts[1]);
				}
			}

			return Task.FromResult(keyValues);
		}
	}
}
