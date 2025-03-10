using Code.Gameplay.Player.Factories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
  public class GameRunner : MonoBehaviour
  {
    [SerializeField] private Transform _playerSpawnPoint;
    
    private IPlayerFactory _playerFactory;

    [Inject]
    private void Construct(
      IPlayerFactory playerFactory)
    {
      _playerFactory = playerFactory;
    }
    
    private void Awake()
    {
      InitializeGameWorld();
    }

    private void InitializeGameWorld()
    {
      _playerFactory.CreatePlayer(_playerSpawnPoint.position);
    }
  }
}