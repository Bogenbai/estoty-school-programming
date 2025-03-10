using Zenject;

namespace Code.Infrastructure.Instantiating
{
    public class InstantiatorSetter : IInitializable
    {
        public InstantiatorSetter(IInstantiator instantiator, InstantiatorProvider instantiatorProvider)
        {
            instantiatorProvider.Instantiator = instantiator;
        }

        public void Initialize() { }
    }
}