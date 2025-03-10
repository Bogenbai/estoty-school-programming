using System;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Components
{
  public class Health : MonoBehaviour
  {
    [SerializeField] private float _maxHealth = 5;
    private float _currentHealth;

    public event Action OnDeath;
    
    public void Awake()
    {
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