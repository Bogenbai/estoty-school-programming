using UnityEngine;

namespace Code.Infrastructure.Pooling.Services
{
	public interface IObjectPool
	{
		T Take<T>(string assetPath, Vector3 at, int initialPoolSize, string parentName) where T : Component;
		void Put(GameObject instance);
	}
}