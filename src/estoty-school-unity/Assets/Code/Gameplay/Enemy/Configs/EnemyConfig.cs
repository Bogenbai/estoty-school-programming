using Code.Infrastructure;
using UnityEngine;

namespace Code.Gameplay.Enemy.Configs
{
	[CreateAssetMenu(menuName = Constants.GameName + "/Configs/EnemyConfig", fileName = "EnemyConfig")]
	public class EnemyConfig : ScriptableObject 
	{
		public EnemyActor Prefab;

		public float MovementSpeed = 2;
		public float RotationSpeed = 10;
		public float MaxHealth = 2;
		public float Damage = 1;
		public float VisionRange = 100;
	}
}