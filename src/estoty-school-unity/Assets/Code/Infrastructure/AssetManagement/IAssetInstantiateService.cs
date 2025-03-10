using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
  public interface IAssetInstantiateService
  {
    GameObject Instantiate(GameObject prefab, Vector3 at, Transform parent = null);
    T Instantiate<T>(GameObject prefab, Vector3 at, Transform parent = null) where T : MonoBehaviour;
    T Instantiate<T>(GameObject prefab, Vector3 at, Vector3 rotation, Transform parent = null) where T : MonoBehaviour;
    GameObject Instantiate(GameObject prefab, Vector3 at, Vector3 rotation, Transform parent = null);
    T Instantiate<T>(GameObject prefab) where T : MonoBehaviour;
  }
}