using UnityEngine;

namespace Code.Gameplay.Vfx.Factories
{
	public interface IVfxFactory
	{
		ParticleSystem CreateExplosion(Vector3 at);
	}
}