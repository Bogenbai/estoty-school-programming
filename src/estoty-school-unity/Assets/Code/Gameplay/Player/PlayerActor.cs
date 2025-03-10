using Code.Gameplay.Inputs.Components;
using Code.Gameplay.Statistics.Components;
using UnityEngine;

namespace Code.Gameplay.Player
{
  [RequireComponent(typeof(PlayerInput))]
  [RequireComponent(typeof(Stats))]
  public class PlayerActor : MonoBehaviour
  {
    public PlayerInput Input { get; private set; }
    public Stats Stats { get; private set; }

    private void Awake()
    {
      Input = GetComponent<PlayerInput>();
      Stats = GetComponent<Stats>();
    }
  }
}