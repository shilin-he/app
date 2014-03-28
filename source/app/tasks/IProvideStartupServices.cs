using app.utility.container.basic;

namespace app.tasks
{
  public interface IProvideStartupServices
  {
    void register<Contract, Implementation>(IManageTheLifecycleOfAComponent life_cycle);
    void register<Contract, Implementation>();
    void register<Contract>(Contract instance);
  }

  public class StartupServices : IProvideStartupServices
  {
    public void register<Contract, Implementation>(IManageTheLifecycleOfAComponent life_cycle)
    {

    }

    public void register<Contract, Implementation>()
    {
    }

    public void register<Contract>(Contract instance)
    {
    }
  }
}