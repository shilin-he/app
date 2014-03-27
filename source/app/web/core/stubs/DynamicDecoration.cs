using System.Security;
using app.utility;

namespace app.web.core.stubs
{
  public interface IDispatchToAMethod
  {
    void proceed();
  }

  public interface IDecorateAMethodWithBehaviour
  {
    void apply_to(IDispatchToAMethod method);
  }

  public class Secured : IDecorateAMethodWithBehaviour
  {
    IVerifyAConstraint constraint;

    public Secured(IVerifyAConstraint constraint)
    {
      this.constraint = constraint;
    }

    public void apply_to(IDispatchToAMethod method)
    {
      if (constraint())
      {
        method.proceed();
        return;
      }
      throw new SecurityException("Not secure");
    }
  }

  public class Timed : IDecorateAMethodWithBehaviour
  {
    ITimeThings timer;
    ILogInformation log;

    public Timed(ITimeThings timer, ILogInformation log)
    {
      this.timer = timer;
      this.log = log;
    }

    public void apply_to(IDispatchToAMethod method)
    {
      timer.start();
      method.proceed();
      var result = timer.end();
      log(string.Format("It took {0}", result.ToString()));
    }
  }
}