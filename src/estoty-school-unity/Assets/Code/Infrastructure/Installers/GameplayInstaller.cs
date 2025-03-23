using Code.Gameplay.Enemy.Factories;
using Code.Gameplay.Enemy.Services;
using Code.Gameplay.Player.Factories;
using Code.Gameplay.Player.Services;
using Code.Gameplay.Projectiles.Factory;
using Code.Infrastructure.Instantiating;
using Code.Infrastructure.Pooling.Services;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class GameplayInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      BindGameplayFactories();
      BindEnemyServices();
      BindPlayerServices();
      BindPools();
      BindInstantiatorSetter();
    }

    private void BindGameplayFactories()
    {
      Container.BindInterfacesTo<PlayerFactory>().AsSingle();
      Container.BindInterfacesTo<EnemyFactory>().AsSingle();
      Container.BindInterfacesTo<ProjectileFactory>().AsSingle();
    }

    private void BindEnemyServices()
    {
      Container.BindInterfacesTo<EnemyRegistryService>().AsSingle();
    }

    private void BindPlayerServices()
    {
      Container.BindInterfacesTo<PlayerRegistryService>().AsSingle();
    }
    
    private void BindPools()
    {
      Container.BindInterfacesTo<ObjectPool>().AsSingle();
    }

    private void BindInstantiatorSetter()
    {
      Container.BindInterfacesAndSelfTo<InstantiatorSetter>().AsSingle();
    }
  }
}