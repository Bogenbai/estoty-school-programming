using Code.Gameplay.Combat.Components;
using Code.Gameplay.Movement.Components;
using Code.Gameplay.Teams.Components;
using Code.Infrastructure.Pooling.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Projectiles
{
  [RequireComponent(typeof(DamageArea))]
  [RequireComponent(typeof(DirectionalMovement))]
  [RequireComponent(typeof(Team))]
  public class ProjectileActor : MonoBehaviour
  {
    private IObjectPool _objectPool;
    
    public DamageArea DamageArea { get; private set; }
    public DirectionalMovement Movement { get; private set; }
    public Team Team { get; private set; }

    [Inject]
    private void Construct(IObjectPool objectPool)
    {
      _objectPool = objectPool;
    }

    private void Awake()
    {
      DamageArea = GetComponentInChildren<DamageArea>();
      Movement = GetComponent<DirectionalMovement>();
      Team = GetComponent<Team>();
      
      DamageArea.OnTouch += HandleDamageAreaTouch;
    }

    private void OnDestroy()
    {
      DamageArea.OnTouch -= HandleDamageAreaTouch;
    }

    private void HandleDamageAreaTouch()
    {
      _objectPool.Put(gameObject);
    }
  }
}