using System;

namespace Code.Gameplay.Inputs.Components
{
  public class EnemyInput : IInput
  {
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    
    public event Action OnAttack;
  }
}