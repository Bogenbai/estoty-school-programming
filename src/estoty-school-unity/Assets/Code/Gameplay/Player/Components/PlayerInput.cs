using System;
using Code.Gameplay.Inputs.Components;
using UnityEngine;

namespace Code.Gameplay.Player.Components
{
  public class PlayerInput : MonoBehaviour, IInput
  {
    private Vector3 _direction;

    public Vector3 Direction
    {
      get => !IsEnabled ? Vector3.zero : _direction;
      private set => _direction = value;
    }

    public bool IsEnabled { get; set; } = true;
    
    public event Action OnAttack;

    public void Update()
    {
      var horizontal = Input.GetAxisRaw("Horizontal");
      var vertical = Input.GetAxisRaw("Vertical");
      Direction = new Vector3(horizontal, 0f, vertical).normalized;
      
      if (Input.GetKeyDown(KeyCode.Space))
        OnAttack?.Invoke();
    }
  }
}