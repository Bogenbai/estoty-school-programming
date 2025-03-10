using Zenject;

namespace Code.Infrastructure.Instantiating
{
    public class InstantiatorProvider
    {
        public IInstantiator Instantiator;

        public InstantiatorProvider(IInstantiator instantiator)
        {
            Instantiator = instantiator;
        }
    }
}