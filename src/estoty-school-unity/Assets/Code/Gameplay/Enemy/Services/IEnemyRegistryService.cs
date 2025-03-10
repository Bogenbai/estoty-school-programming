using System;
using System.Collections.Generic;

namespace Code.Gameplay.Enemy.Services
{
  public interface IEnemyRegistryService
  {
    IReadOnlyCollection<EnemyActor> Enemies { get; }
    event Action<EnemyActor> OnEnemyRegistered;
    event Action<EnemyActor> OnEnemyUnregistered;
    void Register(EnemyActor enemy);
    void Unregister(EnemyActor enemy);
    int GetEnemyCount();
  }
}