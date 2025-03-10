using System;
using UnityEngine;

namespace Code.Gameplay.Inputs.Components
{
  public class PlayerInput : MonoBehaviour, IInput
  {
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    
    public event Action OnAttack;

    public void Update()
    {
      Horizontal = Input.GetAxisRaw("Horizontal");
      Vertical = Input.GetAxisRaw("Vertical");
      
      if (Input.GetKeyDown(KeyCode.Space))
        OnAttack?.Invoke();
    }
  }
}