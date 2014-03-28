namespace app.tasks.startup
{
  public class Start
  {
    public static ICreateAStartupChainFromAnInitialStep create_chain = StartupItems.Containers.Basic.create_chain;

    public static IDefineStartupChains by<Step>() where Step : IRunAStartupStep
    {
      return
        create_chain(typeof(Step));
    }

    public static void by_running_all_steps_in(string starup_steps)
    {
      throw new System.NotImplementedException();
    }
  }
}