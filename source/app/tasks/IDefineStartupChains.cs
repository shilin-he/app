namespace app.tasks
{
  public interface IDefineStartupChains
  {
    IDefineStartupChains followed_by<Step>() where Step : IRunAStartupStep;
    void finish_with<Step>() where Step : IRunAStartupStep;
  }
}