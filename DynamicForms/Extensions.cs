using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using DynamicForms.Attributes;

namespace DynamicForms
{
	static class TypeExtensions
	{
		public static string GetAlias(this Type type)
		{
			var nameAttribute = type.GetCustomAttributes().FirstOrDefault(x => x.GetType() == (typeof(AliasAttribute)));
			if (nameAttribute == null)
				throw new Exception($"Type {type.FullName} must be decorated with {nameof(AliasAttribute)}");

			return ((AliasAttribute)nameAttribute).TypeName;
		}

		public static object? GetDefaultValue(this Type type)
		{
			if (type.IsValueType)
				return Activator.CreateInstance(type);
			else
				return null;
		}

		public static bool IsAssignableFrom<TType>(this Type type)
			=> typeof(TType).IsAssignableFrom(type);
	}
}
