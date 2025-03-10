using System;
using UnityEngine;

namespace Code.Gameplay.Inputs.Components
{
  public class PlayerInput : MonoBehaviour, IInput
  {
    public Vector3 Direction { get; private set; }
    
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