using System;
using System.Collections.Generic;

namespace Code.Gameplay.Enemy.Services
{
  public class EnemyRegistryService : IEnemyRegistryService
  {
    private readonly List<EnemyActor> _enemies = new();
    public IReadOnlyCollection<EnemyActor> Enemies => _enemies;
    
    public event Action<EnemyActor> OnEnemyRegistered;
    public event Action<EnemyActor> OnEnemyUnregistered;
    
    public void Register(EnemyActor enemy)
    {
      if (_enemies.Contains(enemy))
        return;
      
      _enemies.Add(enemy);
      OnEnemyRegistered?.Invoke(enemy);
    }
    
    public void Unregister(EnemyActor enemy)
    {
      if (!_enemies.Contains(enemy))
        return;
      
      _enemies.Remove(enemy);
      OnEnemyUnregistered?.Invoke(enemy);
    }
    
    public int GetEnemyCount()
    {
      return _enemies.Count;
    }
  }
}