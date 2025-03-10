using Code.Gameplay.Combat.Components;
using Code.Gameplay.Movement.Components;
using Code.Gameplay.Teams.Components;
using UnityEngine;

namespace Code.Gameplay.Projectiles
{
  [RequireComponent(typeof(DamageArea))]
  [RequireComponent(typeof(DirectionalMovement))]
  [RequireComponent(typeof(Team))]
  public class ProjectileActor : MonoBehaviour
  {
    public DamageArea DamageArea { get; private set; }
    public DirectionalMovement Movement { get; private set; }
    public Team Team { get; private set; }

    private void Awake()
    {
      DamageArea = GetComponentInChildren<DamageArea>();
      Movement = GetComponent<DirectionalMovement>();
      Team = GetComponent<Team>();
    }
  }
}