using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
  public interface IAssetsService
  {
    GameObject Load(string path);
    T Load<T>(string path) where T : UnityEngine.Object;
  }
}