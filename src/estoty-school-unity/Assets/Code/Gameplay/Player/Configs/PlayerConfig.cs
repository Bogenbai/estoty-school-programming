using Code.Infrastructure;
using UnityEngine;

namespace Code.Gameplay.Player.Configs
{
	[CreateAssetMenu(menuName = Constants.GameName + "/Configs/PlayerConfig", fileName = "PlayerConfig")]
	public class PlayerConfig : ScriptableObject 
	{
		public PlayerActor Prefab;

		public float MovementSpeed;
		public float RotationSpeed;
		public float MaxHealth;
		public float Damage;
	}
}