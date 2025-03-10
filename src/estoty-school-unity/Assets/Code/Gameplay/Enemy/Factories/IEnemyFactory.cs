using UnityEngine;

namespace Code.Gameplay.Enemy.Factories
{
  public interface IEnemyFactory
  {
    EnemyActor CreateEnemy(Vector3 at);
  }
}