using Code.Gameplay.Player.Configs;

namespace Code.Infrastructure.Configs
{
	public interface IConfigsService
	{
		PlayerConfig PlayerConfig { get; }
	}
}