using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
  public class AssetsService : IAssetsService
  {
    public GameObject Load(string path)
    {
      return Resources.Load<GameObject>(path);
    }

    public T Load<T>(string path) where T : UnityEngine.Object
    {
      return Resources.Load<T>(path);
    }
  }
}