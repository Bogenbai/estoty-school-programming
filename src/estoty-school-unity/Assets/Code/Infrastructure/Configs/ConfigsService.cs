using Code.Gameplay;
using Code.Gameplay.Player.Configs;
using Code.Infrastructure.AssetManagement;
using Zenject;

namespace Code.Infrastructure.Configs
{
	public class ConfigsService : IConfigsService, IInitializable
	{
		private readonly IAssetsService _assetsService;
		
		public PlayerConfig PlayerConfig { get; private set; }

		public ConfigsService(IAssetsService assetsService)
		{
			_assetsService = assetsService;
		}
		
		public void Initialize()
		{
			LoadHeroConfig();
		}

		private void LoadHeroConfig()
		{
			PlayerConfig = _assetsService.Load<PlayerConfig>(AssetPaths.PlayerConfig);
		}
	}
}