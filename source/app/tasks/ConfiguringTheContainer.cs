namespace app.tasks
{
  public class ConfiguringTheContainer : IRunAStartupStep
  {
    IProvideStartupServices services;

    public ConfiguringTheContainer(IProvideStartupServices services)
    {
      this.services = services;
    }

    public void run()
    {
    }
  }
}