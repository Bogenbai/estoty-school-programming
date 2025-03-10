using System;
using UnityEngine;

namespace Code.Gameplay.Inputs.Components
{
  public interface IInput
  {
    Vector3 Direction { get; }
    bool IsEnabled { get; set; }
    event Action OnAttack;
  }
}