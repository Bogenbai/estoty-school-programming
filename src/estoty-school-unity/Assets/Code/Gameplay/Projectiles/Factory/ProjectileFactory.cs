using Code.Gameplay.Teams;
using Code.Infrastructure.Pooling.Services;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Factory
{
  public class ProjectileFactory : IProjectileFactory
  {
    private readonly IObjectPool _pool;

    public ProjectileFactory(IObjectPool pool)
    {
      _pool = pool;
    }
    
    public ProjectileActor CreateProjectile(Vector3 at, Vector3 direction, float damage, TeamTypeId teamTypeId)
    {
      var projectile = _pool.Take<ProjectileActor>(AssetPaths.ProjectilePrefab, at, 5, nameof(ProjectileFactory));
      
      projectile.Movement.Direction = direction;
      projectile.DamageArea.Setup(damage);
      projectile.Team.SetTeam(teamTypeId);
      
      return projectile;
    }
  }
}