using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DynamicForms
{
	static class TypeActivator
	{
		public static TType CreateInstance<TType>(Dictionary<string, object> parameterValues)
		{
			var type = typeof(TType);
			var ctorParams = GetConstructoreValues(type, parameterValues);
			return (TType)Activator.CreateInstance(type, ctorParams);
		}

		private static object?[] GetConstructoreValues(Type type, Dictionary<string, object> parameterValues)
		{
			var parameters = GetConstructorParameters(type);

			var values = new List<object?>(parameterValues.Count);
			foreach (var param in parameters)
			{
				var valueKey = parameterValues.Keys.FirstOrDefault(key => string.Compare(key, param.Name, StringComparison.OrdinalIgnoreCase) == 0);

				object? parameterValue;
				if (valueKey != null)
				{
					var value = parameterValues[valueKey];
					if (value is string valueStr)
						parameterValue = TypeDescriptor.GetConverter(param.ParameterType).ConvertFromString(valueStr);
					else
						parameterValue = value;
				}
				else
				{
					parameterValue = param.ParameterType.GetDefaultValue();
				}

				values.Add(parameterValue);
			}

			return values.ToArray();
		}
		private static ParameterInfo[] GetConstructorParameters(Type type)
		{
			var ctors = type.GetConstructors();
			if (ctors.Length != 1)
				throw new Exception($"{type.Name} must have only one ctor");

			return ctors[0].GetParameters()
				.OrderBy(x => x.Position)
				.ToArray();
		}
	}
}
