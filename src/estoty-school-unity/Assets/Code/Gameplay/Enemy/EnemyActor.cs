using Code.Gameplay.Enemy.Services;
using Code.Gameplay.Inputs.Components;
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
    public IInput Input { get; private set; }
    public Collider Collider { get; private set; }

    [Inject]
    private void Construct(IEnemyRegistryService enemyRegistryService)
    {
      _enemyRegistryService = enemyRegistryService;
    }

    private void OnEnable()
    {
      _enemyRegistryService.Register(this);
      Health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
      _enemyRegistryService.Unregister(this);
      Health.OnDeath -= HandleDeath;
    }

    private void Awake()
    {
      Stats = GetComponent<Stats>();
      Health = GetComponent<Health>();
      Input = GetComponent<IInput>();
      Collider = GetComponent<Collider>();
    }

    private void HandleDeath()
    {
      Collider.enabled = false;
      _enemyRegistryService.Unregister(this);
      Input.IsEnabled = false; 
      Destroy(gameObject, 5);
    }
  }
}