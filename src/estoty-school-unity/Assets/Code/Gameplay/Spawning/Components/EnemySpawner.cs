using System.Collections;
using Code.Gameplay.Enemy.Factories;
using Code.Gameplay.Enemy.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Spawning.Components
{
  public class EnemySpawner : MonoBehaviour
  {
    [SerializeField] private int _enemiesAtOnce = 1;
    
    private IEnemyFactory _enemyFactory;
    private IEnemyRegistryService _enemyRegistryService;

    [Inject]
    private void Construct(
      IEnemyFactory enemyFactory, 
      IEnemyRegistryService enemyRegistryService)
    {
      _enemyRegistryService = enemyRegistryService;
      _enemyFactory = enemyFactory;
    }

    private void Start()
    {
      StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
      while (true)
      {
        int enemyCount = _enemyRegistryService.GetEnemyCount();

        if (enemyCount >= _enemiesAtOnce)
        {
          yield return new WaitForSeconds(1);
          continue;
        }
        
        for (int i = 0; i < _enemiesAtOnce; i++)
        {
          _enemyFactory.CreateEnemy(transform.position);
        }

        yield return new WaitForSeconds(1);
      }
    }
  }
}