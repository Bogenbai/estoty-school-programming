using System.Collections.Generic;
using Code.Gameplay.Lifetime.Components;
using Code.Gameplay.Statistics;
using Code.Gameplay.Statistics.Components;
using Code.Gameplay.Teams.Components;
using UnityEngine;

namespace Code.Gameplay.Vision.Components
{
  [RequireComponent(typeof(Team))]
  [RequireComponent(typeof(Stats))]
  public class VisionSight : MonoBehaviour
  {
    private Team _team;
    private Stats _stats;
    private Collider[] _hits;

    public List<GameObject> Enemies { get; } = new();

    private void Awake()
    {
      _team = GetComponent<Team>();
      _stats = GetComponent<Stats>();
      _hits = new Collider[50];
    }

    private void FixedUpdate()
    {
      GatherEnemiesInSight();
    }
    
    public Health GetClosestEnemy()
    {
      Health closest = null;
      float minDistance = float.MaxValue;
      
      foreach (GameObject enemy in Enemies)
      {
        if (enemy == null)
          continue;
        
        if (enemy.TryGetComponent(out Health health))
        {
          float distance = Vector3.Distance(transform.position, health.transform.position);
          
          if (distance < minDistance)
          {
            minDistance = distance;
            closest = health;
          }
        }
      }

      return closest;
    }

    private void GatherEnemiesInSight()
    {
      float visionRange = _stats.GetStat(StatTypeId.VisionRange);
      
      Enemies.Clear();
      int size = Physics.OverlapSphereNonAlloc(transform.position, visionRange, _hits);

      for (var i = 0; i < size; i++)
      {
        Collider hit = _hits[i];
        
        if (hit.TryGetComponent(out Team team) && team != _team)
        {
          Enemies.Add(hit.gameObject);
        }
      }
    }
  }
}