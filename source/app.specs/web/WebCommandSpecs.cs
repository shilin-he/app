using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.web
{
  [Subject(typeof(WebCommand))]
  public class WebCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
      WebCommand>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutARequest>();
        depends.on<IMatchARequest>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_process(request);

      It makes_the_determination_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static IProvideDetailsAboutARequest request;
      static bool result;
    }
    public class when_processing_the_request : concern
    {
      Establish c = () =>
      {
        feature = depends.on<IImplementAUserStory>();
        request = fake.an<IProvideDetailsAboutARequest>();
      };

      Because b = () =>
        sut.process(request);

      It delegates_the_processing_to_the_application_feature_for_the_request = () =>
        feature.received(x => x.process(request));

      static IImplementAUserStory feature;
      static IProvideDetailsAboutARequest request;
    }
  }
}