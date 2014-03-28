using System;

namespace app.tasks
{
  public class Start
  {
    public static ICreateAStartupChainFromAnInitialStep create_chain = (type) =>
    {
      throw new NotImplementedException("This needs to be revisited");
    };


    public static IDefineStartupChains by<Step>() where Step : IRunAStartupStep
    {
      return create_chain(typeof(Step));
    }
  }
}