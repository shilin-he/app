using app.utility;

namespace app.web.core
{
  public class TimedFeature : IImplementAUserStory
  {
    ITimeThings timer;
    IImplementAUserStory feature;
    ILogInformation log;

    public TimedFeature(ITimeThings timer, IImplementAUserStory feature, ILogInformation log)
    {
      this.timer = timer;
      this.feature = feature;
      this.log = log;
    }

    public void process(IProvideDetailsAboutARequest request)
    {
      timer.start();
      feature.process(request);
      var elapsed = timer.end();

      log(string.Format("The feature [{0}] took {1} to run",
        feature.GetType().Name, elapsed.ToString()));

    }
  }
}