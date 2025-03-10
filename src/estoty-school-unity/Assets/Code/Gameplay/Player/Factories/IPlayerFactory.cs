using UnityEngine;

namespace Code.Gameplay.Player.Factories
{
  public interface IPlayerFactory
  {
    GameObject CreatePlayer(Vector3 at);
  }
}