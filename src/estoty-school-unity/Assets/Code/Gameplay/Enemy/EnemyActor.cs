using Code.Gameplay.Enemy.Services;
using Code.Gameplay.Lifetime.Components;
using Code.Gameplay.Statistics.Components;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Enemy
{
  [RequireComponent(typeof(Stats))]
  [RequireComponent(typeof(Health))]
  public class EnemyActor : MonoBehaviour
  {
    private IEnemyRegistryService _enemyRegistryService;
    
    public Stats Stats { get; private set; }
    public Health Health { get; private set; }

    [Inject]
    private void Construct(IEnemyRegistryService enemyRegistryService)
    {
      _enemyRegistryService = enemyRegistryService;
    }

    private void OnEnable()
    {
      _enemyRegistryService.Register(this);
    }
    
    private void OnDisable()
    {
      _enemyRegistryService.Unregister(this);
    }

    private void Awake()
    {
      Stats = GetComponent<Stats>();
      Health = GetComponent<Health>();
    }
  }
}