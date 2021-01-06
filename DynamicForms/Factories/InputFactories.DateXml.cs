using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DynamicForms.Inputs;

namespace DynamicForms.Factories
{
	public partial class InputFactory
	{
		public class DateXml : IInputFactory
		{
			public Task<IInput> Create(Dictionary<string, object> parameterValues)
			{
				AdaptDateParameter(parameterValues, "minDate");
				AdaptDateParameter(parameterValues, "maxDate");
				AdaptDateParameter(parameterValues, "defaultValue");

				return Task.FromResult<IInput>(TypeActivator.CreateInstance<Input.Date>(parameterValues));
			}

			private void AdaptDateParameter(Dictionary<string, object> parameterValues, string parameterName)
			{
				if (!parameterValues.TryGetValue(parameterName, out object value))
					return;

				var expression = value.ToString();
				if (DateTime.TryParse(expression, out var _))
					return;

				var date = GetDateFromExpression(expression);
				parameterValues[parameterName] = date;
			}

			private DateTime GetDateFromExpression(string expression)
			{
				var matches = Constants.Regex.DateExpressionXml.Matches(expression);
				var date = DateTime.Now;
				foreach (Match match in matches)
				{
					var sign = match.Groups["sign"].Value;
					var amount = int.Parse(match.Groups["amount"].Value);
					var unit = match.Groups["unit"].Value;

					if (sign == "-")
						amount = -amount;

					switch (unit)
					{
						case "Y": date = date.AddYears(amount); break;
						case "M": date = date.AddMonths(amount); break;
						case "D": date = date.AddDays(amount); break;
						case "H": date = date.AddHours(amount); break;
						case "m": date = date.AddMinutes(amount); break;
						case "S": date = date.AddSeconds(amount); break;
					}
				}

				return date;
			}
		}
	}
}
