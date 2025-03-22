using Code.Gameplay.Enemy.Configs;
using Code.Gameplay.Statistics;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Configs;
using UnityEngine;

namespace Code.Gameplay.Enemy.Factories
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IAssetInstantiateService _instantiate;
    private readonly IConfigsService _configs;

    public EnemyFactory(
      IAssetInstantiateService instantiate,
      IConfigsService configs)
    {
      _instantiate = instantiate;
      _configs = configs;
    }
    
    public EnemyActor CreateEnemy(Vector3 at)
    {
      EnemyConfig config = _configs.EnemyConfig;

      EnemyActor prefab = config.Prefab;
      var enemy = _instantiate.Instantiate<EnemyActor>(prefab.gameObject, at);
      
      enemy.Stats.SetStat(StatTypeId.Health, config.MaxHealth);
      enemy.Stats.SetStat(StatTypeId.Damage, config.Damage);
      enemy.Stats.SetStat(StatTypeId.MovementSpeed, config.MovementSpeed);
      enemy.Stats.SetStat(StatTypeId.RotationSpeed, config.RotationSpeed);
      enemy.Stats.SetStat(StatTypeId.VisionRange, config.VisionRange);
      
      enemy.Health.Setup(enemy.Stats.GetStat(StatTypeId.Health));
      
      return enemy;
    }
  }
}