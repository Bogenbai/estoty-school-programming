using Code.Gameplay.Inputs.Components;
using Code.Gameplay.Lifetime.Components;
using Code.Gameplay.Player.Services;
using Code.Gameplay.Statistics.Components;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Player
{
  [RequireComponent(typeof(PlayerInput))]
  [RequireComponent(typeof(Stats))]
  public class PlayerActor : MonoBehaviour
  {
    private IPlayerRegistryService _playerRegistryService;
    
    public PlayerInput Input { get; private set; }
    public Stats Stats { get; private set; }
    public Health Health { get; private set; }

    [Inject]
    private void Construct(IPlayerRegistryService playerRegistryService)
    {
      _playerRegistryService = playerRegistryService;
    }
    
    private void OnEnable()
    {
      _playerRegistryService.RegisterPlayer(this);
    }

    private void OnDisable()
    {
      _playerRegistryService.UnregisterPlayer();
    }

    private void Awake()
    {
      Input = GetComponent<PlayerInput>();
      Stats = GetComponent<Stats>();
      Health = GetComponent<Health>();
    }
  }
}