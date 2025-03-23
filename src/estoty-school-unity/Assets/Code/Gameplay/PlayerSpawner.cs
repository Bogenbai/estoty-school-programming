using Code.Gameplay.Player.Factories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
  public class PlayerSpawner : MonoBehaviour
  {
    private IPlayerFactory _playerFactory;

    [Inject]
    private void Construct(
      IPlayerFactory playerFactory)
    {
      _playerFactory = playerFactory;
    }
    
    private void Start()
    {
      _playerFactory.CreatePlayer(transform.position);
    }
  }
}