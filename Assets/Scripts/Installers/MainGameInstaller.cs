using UnityEngine;
using Zenject;
public class MainGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        GameSettingsInstaller.InstallFromResource("GameSettings_default", Container);
    }

}