using System;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Components
{
  public class Health : MonoBehaviour
  {
    private float _maxHealth = 5;
    [SerializeField] private float _currentHealth;

    public event Action OnDeath;
    public bool IsAlive => _currentHealth > 0;

    public void Setup(float maxHealth)
    {
      _maxHealth = maxHealth;
      _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
      if (!IsAlive)
        return;
      
      _currentHealth -= damage;
      
      if (_currentHealth <= 0)
      {
        OnDeath?.Invoke();
      }
    }
  }
}