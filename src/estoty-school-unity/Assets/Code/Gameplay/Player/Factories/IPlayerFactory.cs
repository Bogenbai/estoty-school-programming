using UnityEngine;

namespace Code.Gameplay.Player.Factories
{
  public interface IPlayerFactory
  {
    PlayerActor CreatePlayer(Vector3 at);
  }
}