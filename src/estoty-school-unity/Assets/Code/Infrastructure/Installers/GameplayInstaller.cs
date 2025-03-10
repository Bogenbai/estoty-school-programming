using Code.Gameplay.Player.Factories;
using Code.Gameplay.Projectiles.Factory;
using Code.Infrastructure.Instantiating;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class GameplayInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      BindInstantiatorSetter();
      BindGameplayFactories();
    }

    private void BindInstantiatorSetter()
    {
      Container.BindInterfacesAndSelfTo<InstantiatorSetter>().AsSingle();
    }

    private void BindGameplayFactories()
    {
      Container.BindInterfacesTo<PlayerFactory>().AsSingle();
      Container.BindInterfacesTo<ProjectileFactory>().AsSingle();
    }
  }
}