using Autofac;
using Dapplo.Addons;
using Dapplo.CaliburnMicro;
using GameOfLife.Ui.ViewModels;

namespace GameOfLife
{
    public class GameOfLifeAddonModule : AddonModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameViewModel>()
                .As<IShell>()
                .SingleInstance();
            base.Load(builder);
        }
    }
}
