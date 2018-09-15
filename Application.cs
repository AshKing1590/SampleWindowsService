using FluentScheduler;
using Serilog;
using System;
using System.IO;

namespace WinServe
{
  internal class Application : Registry
  {
    private readonly IConfig _config;
    private readonly ILogger _logger;

    public Application( IConfig config)
    {
      _config = config;
      _logger = new LoggerConfiguration().WriteTo.RollingFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, config.LogDirectory, config.LogFileName)).CreateLogger();

      Schedule(() => PerformOperation1()).ToRunEvery(1).Weekdays().At(08, 00);
      Schedule(() => PerformOperation2()).ToRunNow().AndEvery(1).Hours().Between(08, 05, 18, 00);     

    }

    private void PerformOperation2()
    {
      _logger.Information($"Start operation 2 at : {DateTime.Now}");
      Console.WriteLine("Performing Operation 2");
    }

    private void PerformOperation1()
    {
      Console.WriteLine("Performing Operation 1");
      _logger.Error($"Operation 1 failed at : {DateTime.Now}");
    }

    public void Start()
    {
      JobManager.JobException += info => { };
      JobManager.Initialize(this);
      JobManager.Start();
    }

    public void Stop()
    {
      JobManager.Stop();
    }
  }
}