using Animancer;
using Code.Gameplay.Lifetime.Components;
using Code.Gameplay.Movement.Components;
using UnityEngine;

namespace Code.Gameplay.Enemy.Components
{
  [RequireComponent(typeof(Health))]
  public class EnemyAnimator : MonoBehaviour
  {
    [Header("General")]
    [SerializeField] private AnimancerComponent _animancer;
    [Header("Animations")]
    [SerializeField] private ClipTransition _idle;
    [SerializeField] private ClipTransition _run;
    [SerializeField] private ClipTransition _death;
    
    private IMovement _movement;
    private Health _health;

    private void OnEnable()
    {
      _health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
      _health.OnDeath -= HandleDeath;
    }

    private void Awake()
    {
      _movement = GetComponent<IMovement>();
      _health = GetComponent<Health>();
    }

    private void Update()
    {
      if (_health.IsAlive)
      {
        _animancer.Play(_movement.IsMoving ? _run : _idle);
      }
    }

    private void HandleDeath()
    {
      _animancer.Stop();
      _animancer.Play(_death);
    }
  }
}