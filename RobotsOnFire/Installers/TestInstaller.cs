using System;
using System.Timers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NLog;

namespace RobotsOnFire.Installers
{
    public class TestInstaller : IWindsorInstaller
    {
        static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDisposable>()
                    .Instance(CreateAndStartTestTimer(interval: TimeSpan.FromSeconds(1)))
                    .Named("TestTimer")
                );
        }

        Timer CreateAndStartTestTimer(TimeSpan interval)
        {
            var timer = new Timer(interval.TotalMilliseconds);
            timer.Elapsed += (o, ea) => Log.Info("woooH0000! It's going great!!1");
            timer.Start();
            return timer;
        }
    }
}
