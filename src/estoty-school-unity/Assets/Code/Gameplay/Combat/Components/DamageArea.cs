using System;
using Code.Gameplay.Lifetime.Components;
using Code.Gameplay.Teams.Components;
using UnityEngine;

namespace Code.Gameplay.Combat.Components
{
  [RequireComponent(typeof(Team))]
  public class DamageArea : MonoBehaviour
  {
    private float _damage;
    private Team _team;
    
    public event Action OnTouch;
    public event Action OnDamageDealt;

    private void Awake()
    {
      _team = GetComponent<Team>();
    }

    public void Setup(float damage)
    {
      _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (IsSameTeam(other))
      {
        return;
      }
      
      if (other.TryGetComponent(out Health health))
      {
        health.TakeDamage(_damage);
        OnDamageDealt?.Invoke();
      }
      
      OnTouch?.Invoke();
    }

    private bool IsSameTeam(Collider other)
    {
      return other.TryGetComponent(out Team team) && team.TeamTypeId == _team.TeamTypeId;
    }
  }
}