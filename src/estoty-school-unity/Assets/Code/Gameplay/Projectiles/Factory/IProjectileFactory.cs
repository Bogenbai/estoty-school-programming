using Code.Gameplay.Teams;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Factory
{
  public interface IProjectileFactory
  {
    ProjectileActor CreateProjectile(Vector3 at, Vector3 right, float damage, TeamTypeId teamTypeId);
  }
}