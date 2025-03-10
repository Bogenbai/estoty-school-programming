using Code.Gameplay.Camera.Factories;
using Code.Gameplay.Player.Factories;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class GameplayInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      BindPlayerServices();
    }

    private void BindPlayerServices()
    {
      Container.BindInterfacesTo<PlayerFactory>().AsSingle();
      Container.BindInterfacesTo<CameraFactory>().AsSingle();
    }
  }
}