using Animancer;
using Code.Gameplay.Movement.Components;
using UnityEngine;

namespace Code.Gameplay.Player.Components
{
  public class PlayerAnimator : MonoBehaviour
  {
    [Header("General")]
    [SerializeField] private AnimancerComponent _animancer;
    [Header("Animations")]
    [SerializeField] private ClipTransition _idle;
    [SerializeField] private ClipTransition _run;
    
    private IMovement _movement;

    private void Awake()
    {
      _movement = GetComponent<IMovement>();
    }

    private void Update()
    {
      _animancer.Play(_movement.IsMoving ? _run : _idle);
    }
  }
}