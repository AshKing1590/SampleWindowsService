using System.Configuration;

namespace WinServe
{
  internal class ServiceConfig : IConfig
  {
    public ServiceConfig()
    {
      UserName = ConfigurationManager.AppSettings["UserName"];
      Password = ConfigurationManager.AppSettings["Password"];
      SqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
      RabbitMqConnectionString = ConfigurationManager.AppSettings["RabbitMqConnectionString"];
      LogDirectory = ConfigurationManager.AppSettings["LogDirectory"];
      LogFileName = ConfigurationManager.AppSettings["LogFileName"];
    }

    public string UserName { get; }

    public string Password { get; }

    public string SqlConnectionString { get; }

    public string RabbitMqConnectionString { get; }

    public string LogDirectory { get; }

    public string LogFileName { get; }
  }

  public interface IConfig
  {
    string UserName { get; }
    string Password { get; }
    string SqlConnectionString { get; }
    string RabbitMqConnectionString { get; }
    string LogDirectory { get; }
    string LogFileName { get; }
  }
}