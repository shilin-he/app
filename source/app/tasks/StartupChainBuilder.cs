using app.tasks.startup;
using app.utility;

namespace app.tasks
{
  public class StartupChainBuilder : IDefineStartupChains
  {
    public static ICombineStartupSteps combine_steps = StartupItems.tasks.combine;

    public IRunATask step { get; private set; }
    ICreateAStartupStep step_factory;

    public StartupChainBuilder(IRunATask step, ICreateAStartupStep step_factory)
    {
      this.step = step;
      this.step_factory = step_factory;
    }


    public IDefineStartupChains followed_by<Step>() where Step : IRunAStartupStep
    {
      return new StartupChainBuilder(combine<Step>(), step_factory);
    }

    IRunATask combine<Step>() where Step : IRunAStartupStep
    {
      var new_step = step_factory.create_step(typeof(Step));
      var combined = combine_steps(step, new_step);
      return combined;
    }

    public void finish_with<Step>() where Step : IRunAStartupStep
    {
      var combined = combine<Step>();
      combined.run();
    }
  }
}