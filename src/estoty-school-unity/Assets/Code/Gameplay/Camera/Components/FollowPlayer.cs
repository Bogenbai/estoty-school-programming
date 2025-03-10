using UnityEngine;

namespace Code.Gameplay.Camera.Components
{
  public class FollowPlayer : MonoBehaviour
  {
    private Transform _transform;
    private Vector3 _offset;

    private const float FollowSpeed = 5;

    private void Awake()
    {
      _transform = GetComponent<Transform>();
    }

    public void Setup(Vector3 offset)
    {
      _offset = offset;
    }

    public void FixedUpdate()
    {
      /*var playerTransform = ComponentRegistry.GetComponent<Transform>(playerID);
      
      if (playerTransform != null)
      {
        var newPosition = playerTransform.Position + _offset;
        
        _transform.Position = Vector3.Lerp(
          _transform.Position, 
          newPosition, 
          Time.deltaTime * FollowSpeed);
      }*/
    }
  }
}