using UnityEngine;

namespace Code.Gameplay.Common.Components
{
  public class DestroyAfter : MonoBehaviour
  { 
    [SerializeField] private float _delay = 10f;

    private void Start()
    {
      Destroy(gameObject, _delay);
    }
  }
}