using System;
using DynamicForms;
using DynamicForms.Factories;

namespace Workbench
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputFactories = new InputFactorySet[] {
				new InputFactorySet(Constants.Inputs.Boolean, new InputFactory.Boolean()),
				new InputFactorySet(Constants.Inputs.Date, new InputFactory.DateXml()),
				new InputFactorySet(Constants.Inputs.FormGroup, new InputFactory.FormGroup()),
				new InputFactorySet(Constants.Inputs.MultipleOptions, new InputFactory.MultipleOptions()),
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
			var form = factory.Create();

			Console.WriteLine("Hello World!");
		}
	}
}
