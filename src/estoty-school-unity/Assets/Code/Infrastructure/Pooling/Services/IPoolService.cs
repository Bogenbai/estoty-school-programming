using UnityEngine;

namespace Code.Infrastructure.Pooling.Services
{
	public interface IPoolService
	{
		T Take<T>(string assetPath, Vector3 at, string parentName, int initialPoolSize = 5) where T : Component;
		void Put(GameObject instance);
	}
}