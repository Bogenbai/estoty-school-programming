using Code.Gameplay.Inputs.Components;
using Code.Gameplay.Statistics;
using Code.Gameplay.Statistics.Components;
using UnityEngine;

namespace Code.Gameplay.Movement.Components
{
  [RequireComponent(typeof(Stats))]
  [RequireComponent(typeof(Rigidbody))]
  [RequireComponent(typeof(IInput))]
  public class RigidbodyMovement : MonoBehaviour, IMovement
  {
    private Rigidbody _rigidbody;
    private Transform _transform;
    private IInput _input;
    private Stats _stats;

    public bool IsMoving { get; private set; }

    public void Awake()
    {
      _rigidbody = GetComponent<Rigidbody>();
      _transform = GetComponent<Transform>();
      _input = GetComponent<IInput>();
      _stats = GetComponent<Stats>();
    }

    public void FixedUpdate()
    {
      float moveHorizontal = _input.Horizontal;
      float moveVertical = _input.Vertical;
      float movementSpeed = _stats.GetStat(StatTypeId.MovementSpeed);
      
      Vector3 motion = new Vector3(moveHorizontal, 0f, moveVertical).normalized * movementSpeed;

      Move(motion);
      Rotate(motion);
    }

    private void Rotate(Vector3 motion)
    {
      float rotationSpeed = _stats.GetStat(StatTypeId.RotationSpeed);
      
      if (motion != Vector3.zero)
      {
        Quaternion targetRotation = Quaternion.LookRotation(motion, Vector3.up);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
      }
    }

    private void Move(Vector3 motion)
    {
      IsMoving = motion != Vector3.zero;
      _rigidbody.velocity = new Vector3(motion.x, _rigidbody.velocity.y, motion.z);
    }
  }
}