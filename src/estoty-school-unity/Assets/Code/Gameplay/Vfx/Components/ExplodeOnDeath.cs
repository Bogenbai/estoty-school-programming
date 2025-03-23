using Code.Gameplay.Lifetime.Components;
using Code.Gameplay.Vfx.Factories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Vfx.Components
{
	[RequireComponent(typeof(Health))]
	public class ExplodeOnDeath : MonoBehaviour
	{
		private IVfxFactory _vfxFactory;
		
		private Health _health;

		[Inject]
		private void Construct(IVfxFactory vfxFactory)
		{
			_vfxFactory = vfxFactory;
		}

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
			_vfxFactory.CreateExplosion(transform.position);
		}
	}
}