using app.utility.container.basic;

namespace app.tasks
{
  public interface IProvideStartupServices
  {
    void register<Contract, Implementation>(IManageTheLifecycleOfAComponent life_cycle);
    void register<Contract, Implementation>();
    void register<Contract>(Contract instance);
  }
}