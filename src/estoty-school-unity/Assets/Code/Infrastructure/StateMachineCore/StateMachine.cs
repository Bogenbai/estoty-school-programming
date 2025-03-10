using System;
using Zenject;

namespace Code.Infrastructure.StateMachineCore
{
	public abstract class StateMachine : IStateMachine, IProcessable, ITickable
	{
		protected readonly IStatesFactory StatesFactory;

		public IState ActiveState { get; protected set; }

		public event Action<IState> OnStateEnter; 
		public event Action<IState> OnStateExit; 

		public StateMachine(IStatesFactory statesFactory)
		{
			this.StatesFactory = statesFactory;
		}

		public void Tick()
		{
			Process();
		}

		public void Process()
		{
			(ActiveState as IProcessable)?.Process();
		}
		
		public void Enter<TState>() where TState : IState
		{
			IState state = ChangeActiveStateTo<TState>();
			(state as IEnter)?.Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload) where TState : IState, IPayloadedEnter<TPayload>
		{
			IState state = ChangeActiveStateTo<TState>();
			(state as IPayloadedEnter<TPayload>)?.Enter(payload);
		}

		public void Enter<TState, TPayload1, TPayload2>(TPayload1 payload1, TPayload2 payload2)
			where TState : IState, IPayloadedEnter<TPayload1, TPayload2>
		{
			IState state = ChangeActiveStateTo<TState>();
			(state as IPayloadedEnter<TPayload1, TPayload2>)?.Enter(payload1, payload2);
		}

		public void Enter<TState, TPayload1, TPayload2, TPayload3>(TPayload1 payload1, TPayload2 payload2, TPayload3 payload3)
			where TState : IState, IPayloadedEnter<TPayload1, TPayload2, TPayload3>
		{
			IState state = ChangeActiveStateTo<TState>();
			(state as IPayloadedEnter<TPayload1, TPayload2, TPayload3>)?.Enter(payload1, payload2, payload3);
		}

		private IState ChangeActiveStateTo<TState>() where TState : IState
		{
			(ActiveState as IExit)?.Exit();
			OnStateExit?.Invoke(ActiveState);

			ActiveState = CreateState<TState>();
			OnStateEnter?.Invoke(ActiveState);

			PrintLog();

			return ActiveState;
		}

		protected virtual void PrintLog()
		{
		}

		protected virtual IState CreateState<TState>() where TState : IState
		{
			return StatesFactory.Create<TState>(new object[] { this });
		}
	}
}