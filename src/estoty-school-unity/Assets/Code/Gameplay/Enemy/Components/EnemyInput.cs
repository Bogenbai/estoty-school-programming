using System;
using System.Collections;
using Code.Gameplay.Inputs.Components;
using Code.Gameplay.Vision.Components;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Gameplay.Enemy.Components
{
  [RequireComponent(typeof(VisionSight))]
  public class EnemyInput : MonoBehaviour, IInput
  {
    private NavMeshPath _path;
    private int _currentCorner;
    
    private VisionSight _visionSight;
    private Transform _target;
    private Vector3 _direction;

    public Vector3 Direction
    {
      get => !IsEnabled ? Vector3.zero : _direction;
      private set => _direction = value;
    }

    public bool IsEnabled { get; set; } = true;
    
    public event Action OnAttack;

    private void Awake()
    {
      _visionSight = GetComponent<VisionSight>();
      
      _path = new NavMeshPath();
      CalculateNewPath();
      StartCoroutine(UpdatePathRoutine());
    }

    private void Update()
    {
      if (_path.corners.Length > 0 && _currentCorner < _path.corners.Length)
      {
        Direction = (_path.corners[_currentCorner] - transform.position).normalized;

        if (Vector3.Distance(transform.position, _path.corners[_currentCorner]) < 0.5f)
        {
          _currentCorner++;
        }
      }
    }

    private IEnumerator UpdatePathRoutine()
    {
      while (true)
      {
        CalculateNewPath();
        yield return new WaitForSeconds(0.5f);
      }
    }

    private void CalculateNewPath()
    {
      Transform newTarget = _visionSight.GetClosestEnemy()?.transform;
      
      if (newTarget != _target && newTarget != null)
      {
        _target = newTarget;
      }
      
      if (_target != null)
      {
        NavMesh.CalculatePath(transform.position, _target.position, NavMesh.AllAreas, _path);
        _currentCorner = 0;
      }
      else
      {
        Direction = Vector3.zero;
      }
    }
  }
}