using System.Threading.Tasks;

namespace DynamicForms.Factories
{
	public interface IFormFactory
	{
		Task<IForm> Create();
	}
}
