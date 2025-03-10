using Code.Infrastructure.Instantiating;
using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
  public class AssetInstantiateService : IAssetInstantiateService
  {
    private readonly InstantiatorProvider _instantiatorProvider;

    public AssetInstantiateService(InstantiatorProvider instantiatorProvider)
    {
      _instantiatorProvider = instantiatorProvider;
    }

    public GameObject Instantiate(GameObject prefab, Vector3 at, Transform parent = null)
    {
      GameObject instantiated = _instantiatorProvider.Instantiator.InstantiatePrefab(prefab, parent);
      instantiated.name = instantiated.name.Replace("(Clone)", string.Empty);
      
      Transform transform = instantiated.transform;
      transform.position = at;
      transform.rotation = Quaternion.identity;
      
      return instantiated;
    }

    public T Instantiate<T>(GameObject prefab, Vector3 at, Transform parent = null) where T : MonoBehaviour
    {
      var instantiated = _instantiatorProvider.Instantiator.InstantiatePrefabForComponent<T>(prefab, parent);
      instantiated.name = instantiated.name.Replace("(Clone)", string.Empty);
      
      Transform transform = instantiated.transform;
      transform.position = at;
      transform.rotation = Quaternion.identity;
      
      return instantiated;
    }

    public T Instantiate<T>(GameObject prefab, Vector3 at, Vector3 rotation, Transform parent = null) where T : MonoBehaviour
    {
      var instantiated = Instantiate<T>(prefab, at, parent);
      instantiated.transform.rotation = Quaternion.Euler(rotation);
      
      return instantiated;
    }

    public GameObject Instantiate(GameObject prefab, Vector3 at, Vector3 rotation, Transform parent = null)
    {
      GameObject instantiated = _instantiatorProvider.Instantiator.InstantiatePrefab(prefab, parent);
      instantiated.name = instantiated.name.Replace("(Clone)", string.Empty);
      
      Transform transform = instantiated.transform;
      transform.position = at;
      transform.rotation = Quaternion.Euler(rotation);
      
      return instantiated;
    }

    public T Instantiate<T>(GameObject prefab) where T : MonoBehaviour
    {
      var instantiated = _instantiatorProvider.Instantiator.InstantiatePrefabForComponent<T>(prefab);
      instantiated.name = instantiated.name.Replace("(Clone)", string.Empty);
      
      Transform transform = instantiated.transform;
      transform.rotation = Quaternion.identity;
      
      return instantiated;
    }
  }
}