using Code.Gameplay.Statistics;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Enemy.Factories
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IAssetsService _assets;
    private readonly IAssetInstantiateService _instantiate;

    public EnemyFactory(IAssetsService assets, IAssetInstantiateService instantiate)
    {
      _assets = assets;
      _instantiate = instantiate;
    }
    
    public EnemyActor CreateEnemy(Vector3 at)
    {
      var prefab = _assets.Load<GameObject>(AssetPaths.EnemyPrefab);
      var enemy = _instantiate.Instantiate<EnemyActor>(prefab, at);
      
      enemy.Stats.SetStat(StatTypeId.Health, 2);
      enemy.Stats.SetStat(StatTypeId.Damage, 1);
      enemy.Stats.SetStat(StatTypeId.MovementSpeed, 2);
      enemy.Stats.SetStat(StatTypeId.RotationSpeed, 10);
      enemy.Stats.SetStat(StatTypeId.VisionRange, 100);
      
      enemy.Health.Setup(enemy.Stats.GetStat(StatTypeId.Health));
      
      return enemy;
    }
  }
}