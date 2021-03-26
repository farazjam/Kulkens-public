using Zenject;
public class MainGameInstaller : MonoInstaller<MainGameInstaller>
{
    public override void InstallBindings()
    {
        GameSettingsInstaller.InstallFromResource("GameSettings_default", Container);
        Container.Bind<MenuSettings>().AsSingle();
    }

}