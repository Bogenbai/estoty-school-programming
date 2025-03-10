using UnityEngine;

namespace Code.Gameplay.Components.Movement
{
  public class RigidbodyMovement : MonoBehaviour
  {
    private Rigidbody _rigidbody;
    private Transform _transform;
    
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _rotationSpeed = 10f;

    public void Awake()
    {
      _rigidbody = GetComponent<Rigidbody>();
      _transform = GetComponent<Transform>();
    }

    public void FixedUpdate()
    {
      float moveHorizontal = Input.GetAxisRaw("Horizontal");
      float moveVertical = Input.GetAxisRaw("Vertical");    

      Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * _moveSpeed;

      _rigidbody.velocity = new Vector3(movement.x, _rigidbody.velocity.y, movement.z);
      
      if (movement != Vector3.zero)
      {
        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
      }
    }
  }
}