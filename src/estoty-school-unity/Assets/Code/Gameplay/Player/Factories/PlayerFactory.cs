using Code.Gameplay.Statistics;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Player.Factories
{
  public class PlayerFactory : IPlayerFactory
  {
    private readonly IAssetsService _assets;
    private readonly IAssetInstantiateService _instantiate;

    public PlayerFactory(IAssetsService assets, IAssetInstantiateService instantiate)
    {
      _assets = assets;
      _instantiate = instantiate;
    }
    
    public PlayerActor CreatePlayer(Vector3 at)
    {
      var prefab = _assets.Load<GameObject>(AssetPaths.PlayerPrefab);
      var player = _instantiate.Instantiate<PlayerActor>(prefab, at);
      
      player.Stats.SetStat(StatTypeId.Health, 10);
      player.Stats.SetStat(StatTypeId.Damage, 1);
      player.Stats.SetStat(StatTypeId.MovementSpeed, 6);
      player.Stats.SetStat(StatTypeId.RotationSpeed, 6);
      
      return player;
    }
  }
}