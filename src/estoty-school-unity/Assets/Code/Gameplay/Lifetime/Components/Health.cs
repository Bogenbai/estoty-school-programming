using System;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Components
{
  public class Health : MonoBehaviour
  {
    private float _maxHealth = 5;
    private float _currentHealth;

    public event Action OnDeath;
    
    public void Setup(float maxHealth)
    {
      _maxHealth = maxHealth;
      _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
      _currentHealth -= damage;
      
      if (_currentHealth <= 0)
      {
        OnDeath?.Invoke();
        Destroy(gameObject);
      }
    }
  }
}