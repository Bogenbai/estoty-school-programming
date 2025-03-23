using Code.Gameplay.Teams;
using Code.Infrastructure.Pooling.Services;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Factory
{
  public class ProjectileFactory : IProjectileFactory
  {
    private readonly IPoolService _poolService;

    public ProjectileFactory(IPoolService poolService)
    {
      _poolService = poolService;
    }
    
    public ProjectileActor CreateProjectile(Vector3 at, Vector3 direction, float damage, TeamTypeId teamTypeId)
    {
      var projectile = _poolService.Take<ProjectileActor>(AssetPaths.ProjectilePrefab, at, nameof(ProjectileFactory));
      
      projectile.Movement.Direction = direction;
      projectile.DamageArea.Setup(damage);
      projectile.Team.SetTeam(teamTypeId);
      
      return projectile;
    }
  }
}