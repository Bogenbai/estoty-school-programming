using Code.Infrastructure.Instantiating;

namespace Code.Infrastructure.StateMachineCore
{
  public class StateFactory : IStatesFactory
  {
    private readonly InstantiatorProvider _instantiatorProvider;

    public StateFactory(InstantiatorProvider instantiatorProvider)
    {
      _instantiatorProvider = instantiatorProvider;
    }

    public T Create<T>() where T : IState => _instantiatorProvider.Instantiator.Instantiate<T>();
    public T Create<T>(object[] args) where T : IState => _instantiatorProvider.Instantiator.Instantiate<T>(args);
  }
}