namespace app.tasks
{
  public class Start
  {
    public static ICreateAStartupChainFromAnInitialStep create_chain = (type) =>
    {
      IProvideStartupServices services = null;
      var step_factory = new StepFactory(services);
      var first_step = step_factory.create_step(type);
      return new StartupChainBuilder(first_step, step_factory);
    };

    public static IDefineStartupChains by<Step>() where Step : IRunAStartupStep
    {
      return create_chain(typeof(Step));
    }
  }
}