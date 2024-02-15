using System.Threading.Tasks;
using AzureFunction.Interfaces;

namespace AzureFunction.Context
{
	public class TriggerContext
	{
		private IStrategy _strategy;

		public TriggerContext()
		{
		}

        public TriggerContext(IStrategy strategy)
        {
			_strategy = strategy;
        }

		public void SetStrategy(IStrategy strategy)
		{
			_strategy = strategy;
		}

		public async Task Execute()
		{
			await _strategy.Run();
		}
    }
}

