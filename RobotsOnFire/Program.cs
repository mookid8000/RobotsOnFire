using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NLog;
using Topshelf;

namespace RobotsOnFire
{
    class Program : ServiceControl
    {
        static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static void Main()
        {
            HostFactory.Run(f =>
            {
                f.UseNLog();
                f.Service<Program>();
            });
        }

        readonly WindsorContainer _container = new WindsorContainer();

        public bool Start(HostControl hostControl)
        {
            try
            {
                Log.Info("Initializing container");
                _container.Install(FromAssembly.This());

                return true;
            }
            catch (Exception exception)
            {
                Log.Error("An error occurred during intialization: {0}", exception);

                return false;
            }
        }

        public bool Stop(HostControl hostControl)
        {
            try
            {
                Log.Info("Disposing container");
                _container.Dispose();

                return true;
            }
            catch (Exception exception)
            {
                Log.Error("An error occurred during container disposal: {0}", exception);

                return false;
            }
        }
    }
}
