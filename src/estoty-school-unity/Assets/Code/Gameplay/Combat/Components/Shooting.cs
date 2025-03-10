using Code.Gameplay.Inputs.Components;
using Code.Gameplay.Projectiles.Factory;
using Code.Gameplay.Statistics;
using Code.Gameplay.Statistics.Components;
using Code.Gameplay.Teams.Components;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Combat.Components
{
  [RequireComponent(typeof(Team))]
  [RequireComponent(typeof(Stats))]
  public class Shooting : MonoBehaviour
  {
    [SerializeField] private Transform _shootingPoint;
    
    private IInput _input;
    private IProjectileFactory _projectileFactory;
    private Team _team;
    private Stats _stats;

    [Inject]
    private void Construct(IProjectileFactory projectileFactory)
    {
      _projectileFactory = projectileFactory;
    }

    private void Awake()
    {
      _input = GetComponent<IInput>();
      _team = GetComponent<Team>();
      _stats = GetComponent<Stats>();
    }

    private void OnEnable()
    {
      _input.OnAttack += HandleAttack;
    }

    private void OnDisable()
    {
      _input.OnAttack -= HandleAttack;
    }

    private void HandleAttack()
    {
      float damage = _stats.GetStat(StatTypeId.Damage);
      _projectileFactory.CreateProjectile(_shootingPoint.position, transform.forward, damage, _team.TeamTypeId);
    }
  }
}