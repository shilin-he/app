using app.utility;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.web
{
  [Subject(typeof(TimedFeature))]
  public class TimedFeatureSpecs
  {
    public abstract class concern : Observes<IImplementAUserStory,
      TimedFeature>
    {
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        timer = depends.on<ITimeThings>();
        feature = depends.on<IImplementAUserStory>();
        request = fake.an<IProvideDetailsAboutARequest>();
        depends.on<ILogInformation>(x =>
        {
          logged_message = true;
        });
      };

      Because b = () =>
        sut.process(request);

      //It starts_a_timer = () =>
      //    inner_controller.received(x => x.start_timer());
      It starts_the_timer = () =>
        timer.received(x => x.start());

      It delegates_the_processing_to_the_inner_controller = () =>
        feature.received(x => x.process(request));

      It ends_the_timer = () =>
        timer.received(x => x.end());

      It logs_the_timing_details = () =>
        logged_message.ShouldBeTrue();


      //It stops_a_timer = () =>
      //    inner_controller.received(x => x.stop_timer());

      static IProvideDetailsAboutARequest request;
      static IImplementAUserStory feature;
      static ITimeThings timer;
      static bool logged_message;
    }
  }
}