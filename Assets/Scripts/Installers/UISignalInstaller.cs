using Zenject;

public class UISignalInstaller : MonoInstaller<UISignalInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<UpdateUILivesSignal>();

        Container.BindSignal<UpdateUILivesSignal>()
            .ToMethod<UILives>((x, n) => x.ChangeLives(n.LivesText))
            .FromResolve();
    }
}