using UnityEngine;

namespace Code.Gameplay.Lifetime.Components
{
	[RequireComponent(typeof(Health))]
	public class DestroyOnDeath : MonoBehaviour
	{
		private Health _health;

		private void Awake()
		{
			_health = GetComponent<Health>();
			
			_health.OnDeath += HandleDeath;
		}

		private void OnDestroy()
		{
			_health.OnDeath -= HandleDeath;
		}

		private void HandleDeath()
		{
			Destroy(gameObject);
		}
	}
}