using System;

namespace Code.Gameplay.Player.Services
{
  public class PlayerRegistryService : IPlayerRegistryService
  {
    private PlayerActor _player;
    
    public event Action<PlayerActor> OnPlayerRegistered;
    public event Action<PlayerActor> OnPlayerUnregistered;

    public void RegisterPlayer(PlayerActor player)
    {
      _player = player;
      OnPlayerRegistered?.Invoke(player);
    }
    
    public void UnregisterPlayer()
    {
      _player = null;
      OnPlayerUnregistered?.Invoke(_player);
    }
    
    public PlayerActor GetPlayer()
    {
      return _player;
    }
  }
}