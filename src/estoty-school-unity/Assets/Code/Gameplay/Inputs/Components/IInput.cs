using System;

namespace Code.Gameplay.Inputs.Components
{
  public interface IInput
  {
    float Horizontal { get; }
    float Vertical { get; }
    event Action OnAttack;
  }
}