using Code.Gameplay.Lifetime.Components;
using Code.Gameplay.Statistics;
using Code.Gameplay.Statistics.Components;
using Code.Gameplay.Teams.Components;
using Code.Gameplay.Vision.Components;
using UnityEngine;

namespace Code.Gameplay.Combat.Components
{
	[RequireComponent(typeof(Team))]
	[RequireComponent(typeof(VisionSight))]
	[RequireComponent(typeof(Stats))]
	public class MeleeAttack : MonoBehaviour
	{
		private Team _team;
		private VisionSight _visionSight;
		private Stats _stats;
		
		private float _cooldown;

		private void Awake()
		{
			_team = GetComponent<Team>();
			_visionSight = GetComponent<VisionSight>();
			_stats = GetComponent<Stats>();
		}

		private void Update()
		{
			ProcessCooldown();
			ProcessAttack();
		}

		private void ProcessCooldown()
		{
			_cooldown = Mathf.Max(0, _cooldown - Time.deltaTime);
		}

		private void ProcessAttack()
		{
			foreach (GameObject target in _visionSight.Enemies)
			{
				float attackRange = _stats.GetStat(StatTypeId.AttackRange);

				if (IsOnCooldown() 
				    || _team.IsSameTeam(target) 
				    || IsFar(target, attackRange)
				    || !target.TryGetComponent(out Health health))
				{
					continue;
				}
				
				DealDamage(health);
			}
		}

		private void DealDamage(Health health)
		{
			float damage = _stats.GetStat(StatTypeId.Damage);
			health.TakeDamage(damage);
			
			PutOnCooldown();
		}

		private void PutOnCooldown() => _cooldown = _stats.GetStat(StatTypeId.AttackCooldown);

		private bool IsOnCooldown() => _cooldown > 0;

		private bool IsFar(GameObject target, float attackRange) => Vector3.Distance(transform.position, target.transform.position) > attackRange;
	}
}