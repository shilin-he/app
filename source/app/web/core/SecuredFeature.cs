using System.Security;
using app.utility;

namespace app.web.core
{
  public class SecuredFeature : IImplementAUserStory
  {
    IVerifyAConstraint constraint;
    IImplementAUserStory feature;

    public SecuredFeature(IVerifyAConstraint constraint, IImplementAUserStory feature)
    {
      this.constraint = constraint;
      this.feature = feature;
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      if (constraint())
      {
        feature.process(request);
        return;
      }
      throw new SecurityException();

    }
  }
}