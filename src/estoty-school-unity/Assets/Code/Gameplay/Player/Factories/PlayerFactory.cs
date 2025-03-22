using Code.Gameplay.Player.Configs;
using Code.Gameplay.Statistics;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Configs;
using UnityEngine;

namespace Code.Gameplay.Player.Factories
{
  public class PlayerFactory : IPlayerFactory
  {
    private readonly IAssetsService _assets;
    private readonly IAssetInstantiateService _instantiate;
    private readonly IConfigsService _configs;

    public PlayerFactory(
      IAssetsService assets, 
      IAssetInstantiateService instantiate,
      IConfigsService configs)
    {
      _assets = assets;
      _instantiate = instantiate;
      _configs = configs;
    }
    
    public PlayerActor CreatePlayer(Vector3 at)
    {
      PlayerConfig config = _configs.PlayerConfig;
      
      PlayerActor prefab = config.Prefab;
      var player = _instantiate.Instantiate<PlayerActor>(prefab.gameObject, at);
      
      player.Stats.SetStat(StatTypeId.Health, config.MaxHealth);
      player.Stats.SetStat(StatTypeId.Damage, config.Damage);
      player.Stats.SetStat(StatTypeId.MovementSpeed, config.MovementSpeed);
      player.Stats.SetStat(StatTypeId.RotationSpeed, config.RotationSpeed);
      
      player.Health.Setup(player.Stats.GetStat(StatTypeId.Health));
      
      return player;
    }
  }
}