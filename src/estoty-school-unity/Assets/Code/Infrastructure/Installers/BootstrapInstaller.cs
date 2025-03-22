using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Configs;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Instantiating;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      BindAssetsServices();
      BindInstantiationServices();
      BindIdentifierServices();
    }

    private void BindAssetsServices()
    {
      Container.BindInterfacesTo<AssetsService>().AsSingle();
      Container.BindInterfacesTo<AssetInstantiateService>().AsSingle();
      
      Container.BindInterfacesTo<ConfigsService>().AsSingle();
    }

    private void BindInstantiationServices()
    {
      Container.BindInterfacesAndSelfTo<InstantiatorProvider>().AsSingle();
      Container.BindInterfacesTo<InstantiatorSetter>().AsSingle();
    }

    // todo remove
    private void BindIdentifierServices()
    {
      Container.BindInterfacesTo<IdentifierService>().AsSingle();
    }
  }
}