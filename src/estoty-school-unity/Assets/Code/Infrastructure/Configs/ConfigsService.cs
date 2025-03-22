using Code.Gameplay;
using Code.Gameplay.Enemy.Configs;
using Code.Gameplay.Player.Configs;
using Code.Infrastructure.AssetManagement;
using Zenject;

namespace Code.Infrastructure.Configs
{
	public class ConfigsService : IConfigsService, IInitializable
	{
		private readonly IAssetsService _assetsService;
		
		public PlayerConfig PlayerConfig { get; private set; }
		public EnemyConfig EnemyConfig { get; private set; }

		public ConfigsService(IAssetsService assetsService)
		{
			_assetsService = assetsService;
		}
		
		public void Initialize()
		{
			LoadHeroConfig();
			LoadEnemyConfig();
		}

		private void LoadEnemyConfig()
		{
			EnemyConfig = _assetsService.Load<EnemyConfig>(AssetPaths.EnemyConfig);
		}

		private void LoadHeroConfig()
		{
			PlayerConfig = _assetsService.Load<PlayerConfig>(AssetPaths.PlayerConfig);
		}
	}
}