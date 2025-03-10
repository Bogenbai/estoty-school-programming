using Code.Gameplay.Teams;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Factory
{
  public class ProjectileFactory : IProjectileFactory
  {
    private readonly IAssetsService _assets;
    private readonly IAssetInstantiateService _instantiate;

    public ProjectileFactory(IAssetsService assets, IAssetInstantiateService instantiate)
    {
      _assets = assets;
      _instantiate = instantiate;
    }
    
    public ProjectileActor CreateProjectile(Vector3 at, Vector3 direction, float damage, TeamTypeId teamTypeId)
    {
      var prefab = _assets.Load<GameObject>(AssetPaths.ProjectilePrefab);
      var projectile = _instantiate.Instantiate<ProjectileActor>(prefab, at);
      
      projectile.Movement.Direction = direction;
      projectile.DamageArea.Setup(damage);
      projectile.Team.SetTeam(teamTypeId);
      
      return projectile;
    }
  }
}