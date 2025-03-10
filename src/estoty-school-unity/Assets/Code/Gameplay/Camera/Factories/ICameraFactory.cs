using UnityEngine;

namespace Code.Gameplay.Camera.Factories
{
  public interface ICameraFactory
  {
    GameObject CreateCamera(UnityEngine.Vector3 at);
  }
}