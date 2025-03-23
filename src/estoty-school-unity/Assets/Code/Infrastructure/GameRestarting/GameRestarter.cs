using UnityEngine;
using Zenject;

namespace Code.Infrastructure.GameRestarting
{
	public class GameRestarter : IInitializable, ITickable
	{
		public void Initialize() { }

		public void Tick()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}
	}
}