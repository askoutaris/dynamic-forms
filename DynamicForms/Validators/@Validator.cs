using DynamicForms.InputValues;

namespace DynamicForms.Validators
{
	public interface IValidator
	{
		public ValidationError[] Validate(IInputValue inputValue);
	}

	public partial class Validator
	{

	}

	public class ValidationError
	{
		public string InputName { get; }
		public string ErrorMessage { get; }

		private ValidationError()
		{
			InputName = string.Empty;
			ErrorMessage = string.Empty;
		}

		public ValidationError(string inputName, string errorMessage)
		{
			InputName = inputName;
			ErrorMessage = errorMessage;
		}
	}
}
