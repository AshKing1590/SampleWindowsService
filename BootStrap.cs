using System;
using Topshelf;

namespace WinServe
{
  internal class BootStrap
  {
    internal static void Start()
    {
      HostFactory.Run(configure => 
      {
        configure.Service<Application>(service =>
        {
          service.ConstructUsing(s => new Application(new ServiceConfig()));
          service.WhenStarted(s => s.Start());
          service.WhenStopped(s => s.Stop());
        });

        configure.RunAsLocalSystem();
        configure.SetServiceName("WinServe Service");
        configure.SetDisplayName("WinServe Service");
        configure.SetDescription("WinServe Service");
      });
    }
  }
}