using Code.Gameplay.Enemy.Factories;
using Code.Gameplay.Enemy.Services;
using Code.Gameplay.Player.Factories;
using Code.Gameplay.Player.Services;
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
      BindEnemyServices();
      BindPlayerServices();
    }

    private void BindInstantiatorSetter()
    {
      Container.BindInterfacesAndSelfTo<InstantiatorSetter>().AsSingle();
    }

    private void BindGameplayFactories()
    {
      Container.BindInterfacesTo<PlayerFactory>().AsSingle();
      Container.BindInterfacesTo<ProjectileFactory>().AsSingle();
      Container.BindInterfacesTo<EnemyFactory>().AsSingle();
    }

    private void BindEnemyServices()
    {
      Container.BindInterfacesTo<EnemyRegistryService>().AsSingle();
    }

    private void BindPlayerServices()
    {
      Container.BindInterfacesTo<PlayerRegistryService>().AsSingle();
    }
  }
}