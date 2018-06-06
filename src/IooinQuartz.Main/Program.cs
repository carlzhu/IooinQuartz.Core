using System;
using Topshelf;

namespace IooinQuartz.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Host host = HostFactory.New(x =>
            {
                string serviceName = "IOOIN";
                x.SetServiceName(serviceName);
                x.SetDisplayName(serviceName);
                x.SetDescription("IOOIN Schedule.");

                x.Service<Service>(hostSettings => new Service(hostSettings));
            });

            host.Run();


        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("", e.ExceptionObject as Exception);
            Console.WriteLine("error");
            Environment.Exit(0);
        }
    }
}
