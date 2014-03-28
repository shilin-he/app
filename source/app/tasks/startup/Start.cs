namespace app.tasks.startup
{
  public class Start
  {
    public static ICreateAStartupChainFromAnInitialStep create_chain = (type) =>
    {
      var builder = new DependencyFactoryBuilder(null);
      var services = new StartupServices(builder);
      var step_factory = new StartupStepFactory(services);
      var first_step = step_factory.create_step(type);
      return new StartupChainBuilder(first_step, step_factory);
    };

    public static IDefineStartupChains by<Step>() where Step : IRunAStartupStep
    {
      return create_chain(typeof(Step));
    }
  }
}