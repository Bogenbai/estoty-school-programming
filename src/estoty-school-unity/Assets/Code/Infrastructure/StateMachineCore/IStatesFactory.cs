namespace Code.Infrastructure.StateMachineCore
{
	public interface IStatesFactory
	{
		T Create<T>() where T : IState;
		T Create<T>(object[] args) where T : IState;
	}
}