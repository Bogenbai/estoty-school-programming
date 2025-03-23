using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Pooling.Services;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Pooling.Components
{
	public class ReturnToPoolAfterParticlesEnded : MonoBehaviour
	{
		private List<ParticleSystem> _particles;
		
		private IPoolService _pool;

		[Inject]
		private void Construct(IPoolService pool)
		{
			_pool = pool;
		}

		private void Awake()
		{
			_particles = GetComponentsInChildren<ParticleSystem>().ToList();
		}

		private void Update()
		{
			if (!IsAlive())
			{
				_pool.Put(gameObject);
			}
		}
		
		private bool IsAlive()
		{
			return _particles.Any(p => p.IsAlive());
		}
	}
}