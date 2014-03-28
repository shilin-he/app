namespace app.tasks
{
  public interface IProvideStartupServices
  {
    void register<Contract, Implementation>();
    void register<Contract>(Contract instance);
  }

  public class StartupServices : IProvideStartupServices
  {
    public void register<Contract, Implementation>()
    {
    }

    public void register<Contract>(Contract instance)
    {
    }
  }
}