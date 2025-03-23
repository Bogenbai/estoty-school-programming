using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Instantiating.Factories
{
	public class GeneralFactory
	{
		private readonly IAssetsService _assets;
		private readonly IAssetInstantiateService _assetInstantiate;

		public GeneralFactory(IAssetsService assets, IAssetInstantiateService assetInstantiate)
		{
			_assets = assets;
			_assetInstantiate = assetInstantiate;
		}

		public T Create<T>(string path) where T : MonoBehaviour
		{
			var prefabGameObject = _assets.Load<GameObject>(path);

			if (prefabGameObject == null)
			{
				Debug.LogError($"{nameof(GeneralFactory)}: Prefab by path {path} not found");
				return null;
			}
			
			return _assetInstantiate.Instantiate<T>(prefabGameObject);
		}
	}
}