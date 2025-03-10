using Code.Gameplay.Camera.Factories;
using Code.Gameplay.Player.Factories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
  public class GameRunner : MonoBehaviour
  {
    [SerializeField] private Transform _playerSpawnPoint;
    
    private IPlayerFactory _playerFactory;
    private ICameraFactory _cameraFactory;

    [Inject]
    private void Construct(
      IPlayerFactory playerFactory, 
      ICameraFactory cameraFactory)
    {
      _cameraFactory = cameraFactory;
      _playerFactory = playerFactory;
    }
    
    private void Awake()
    {
      InitializeGameWorld();
    }

    private void InitializeGameWorld()
    {
      _playerFactory.CreatePlayer(_playerSpawnPoint.position);
      _cameraFactory.CreateCamera(_playerSpawnPoint.position);
    }
  }
}