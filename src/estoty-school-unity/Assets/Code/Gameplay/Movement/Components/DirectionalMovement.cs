using UnityEngine;

namespace Code.Gameplay.Movement.Components
{
  public class DirectionalMovement : MonoBehaviour, IMovement
  {
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    
    public Vector3 Direction { get; set; }
    public bool IsMoving => true;

    private void Update()
    {
      Vector3 motion = Direction.normalized * _speed;
      transform.position += motion * Time.deltaTime;
    }
  }
}