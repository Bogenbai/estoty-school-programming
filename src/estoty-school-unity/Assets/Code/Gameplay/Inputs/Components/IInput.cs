using System;
using UnityEngine;

namespace Code.Gameplay.Inputs.Components
{
  public interface IInput
  {
    Vector3 Direction { get; }
    event Action OnAttack;
  }
}