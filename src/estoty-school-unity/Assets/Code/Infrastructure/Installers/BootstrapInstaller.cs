using Code.Infrastructure.AssetManagement;
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
    }

    private void BindInstantiationServices()
    {
      Container.BindInterfacesAndSelfTo<InstantiatorProvider>().AsSingle();
      Container.BindInterfacesTo<InstantiatorSetter>().AsSingle();
    }

    private void BindIdentifierServices()
    {
      Container.BindInterfacesTo<IdentifierService>().AsSingle();
    }
  }
}