using System.Collections.Generic;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Pooling.Services
{
    public class PoolService : IPoolService
    {
        private readonly IAssetsService _assets;
        private readonly IAssetInstantiateService _assetInstantiate;
        
        private readonly Dictionary<string, List<Poolable>> _pools;
        private readonly Dictionary<string, GameObject> _prefabs;
        private readonly Dictionary<string, Transform> _parents;
        
        private const int DefaultInitialPoolSize = 5;

        public PoolService(IAssetsService assets, IAssetInstantiateService assetInstantiate)
        {
            _assets = assets;
            _assetInstantiate = assetInstantiate;
            
            _pools = new Dictionary<string, List<Poolable>>();
            _prefabs = new Dictionary<string, GameObject>();
            _parents = new Dictionary<string, Transform>();
        }

        public T Take<T>(string assetPath, Vector3 at, string parentName = null, int initialPoolSize = DefaultInitialPoolSize) where T : Component
        {
            GameObject prefab = LoadPrefab(assetPath);
            string key = GetPoolKey(prefab);
            List<Poolable> pool = GetOrCreatePool(key, assetPath, initialPoolSize, parentName);
            Poolable instance = GetAvailableInstance(pool, key, assetPath, initialPoolSize, parentName);

            ActivateInstance(instance, at);
            return instance.GetComponent<T>();
        }

        public void Put(GameObject instance)
        {
            if (!instance.TryGetComponent(out Poolable poolable))
            {
                Debug.LogError("Trying to put a non-poolable object into the pool.");
                return;
            }

            DeactivateInstance(poolable);
            AddToPool(poolable.AssetPath, poolable);
        }

        private GameObject LoadPrefab(string assetPath)
        {
            if (!_prefabs.TryGetValue(assetPath, out GameObject prefab))
            {
                prefab = _assets.Load<GameObject>(assetPath);
                _prefabs[assetPath] = prefab;
            }
            return prefab;
        }

        private string GetPoolKey(GameObject prefab)
        {
            return prefab.GetInstanceID().ToString();
        }

        private List<Poolable> GetOrCreatePool(string key, string assetPath, int initialPoolSize, string parentName)
        {
            if (!_pools.TryGetValue(key, out List<Poolable> pool))
            {
                pool = new List<Poolable>();
                _pools[key] = pool;
                PopulatePool(key, assetPath, initialPoolSize, parentName);
            }
            return pool;
        }

        private Poolable GetAvailableInstance(List<Poolable> pool, string key, string assetPath, int initialPoolSize, string parentName)
        {
            Poolable instance = pool.Find(p => p.IsPooled);
            if (instance == null)
            {
                PopulatePool(key, assetPath, initialPoolSize, parentName);
                instance = pool.Find(p => p.IsPooled);
            }
            return instance;
        }

        private void PopulatePool(string key, string assetPath, int count, string parentName)
        {
            GameObject prefab = LoadPrefab(assetPath);
            List<Poolable> pool = _pools[key];
            Transform parent = GetOrCreateParent(parentName);

            int targetSize = pool.Count + count;
            while (pool.Count < targetSize)
            {
                pool.Add(CreatePoolable(assetPath, prefab, parent));
            }
        }

        private Poolable CreatePoolable(string assetPath, GameObject prefab, Transform parent)
        {
            GameObject instance = _assetInstantiate.Instantiate(prefab, Vector3.zero);
            Poolable poolable = instance.AddComponent<Poolable>();
            poolable.AssetPath = assetPath;
            poolable.IsPooled = true;
            instance.transform.SetParent(parent);
            instance.SetActive(false);
            return poolable;
        }

        private Transform GetOrCreateParent(string parentName)
        {
            if (string.IsNullOrEmpty(parentName))
                return null;

            if (!_parents.TryGetValue(parentName, out Transform parent))
            {
                parent = new GameObject(parentName).transform;
                _parents[parentName] = parent;
            }
            return parent;
        }

        private void ActivateInstance(Poolable instance, Vector3 position)
        {
            instance.IsPooled = false;
            instance.gameObject.SetActive(true);
            instance.transform.position = position;
        }

        private void DeactivateInstance(Poolable poolable)
        {
            poolable.IsPooled = true;
            poolable.gameObject.SetActive(false);
        }

        private void AddToPool(string key, Poolable poolable)
        {
            if (!_pools.TryGetValue(key, out List<Poolable> pool))
            {
                pool = new List<Poolable>();
                _pools[key] = pool;
            }
            if (!pool.Contains(poolable))
            {
                pool.Add(poolable);
            }
        }
    }
}