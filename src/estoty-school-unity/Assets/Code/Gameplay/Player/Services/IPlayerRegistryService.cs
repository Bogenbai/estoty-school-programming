using System;

namespace Code.Gameplay.Player.Services
{
  public interface IPlayerRegistryService
  {
    event Action<PlayerActor> OnPlayerRegistered;
    event Action<PlayerActor> OnPlayerUnregistered;
    void RegisterPlayer(PlayerActor player);
    void UnregisterPlayer();
    PlayerActor GetPlayer();
  }
}