using Code.Infrastructure.Pooling.Services;
using UnityEngine;

namespace Code.Gameplay.Vfx.Factories
{
	public class VfxFactory : IVfxFactory
	{
		private readonly IPoolService _pool;

		public VfxFactory(IPoolService pool)
		{
			_pool = pool;
		}
		
		public ParticleSystem CreateExplosion(Vector3 at)
		{
			return _pool.Take<ParticleSystem>(AssetPaths.BigExplosionVfx, at, nameof(VfxFactory));
		}
	}
}