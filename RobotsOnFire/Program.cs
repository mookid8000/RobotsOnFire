using System;
using NLog;
using Topshelf;

namespace RobotsOnFire
{
    class Program
    {
        static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (o, ea) => Log.Fatal("Unhandled exception: {0}", ea.ExceptionObject);

            HostFactory.Run(f =>
            {
                f.UseNLog();
                f.Service<RobotService>();
            });
        }
    }
}
