using System.Security;
using app.utility;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.web
{
  [Subject(typeof(SecuredFeature))]
  public class SecuredFeatureSpecs
  {
    public abstract class concern : Observes<IImplementAUserStory,
      SecuredFeature>
    {
    }

    public class when_run : concern
    {
      public class and_the_security_constraint_is_met
      {
        Establish c = () =>
        {
          depends.on<IVerifyAConstraint>(() => true);
          request = fake.an<IProvideDetailsAboutARequest>();
          feature = depends.on<IImplementAUserStory>();
        };
        Because b = () =>
          sut.process(request);

        It forward_the_processing_to_the_feature = () =>
          feature.received(x => x.process(request));

        static IImplementAUserStory feature;
        static IProvideDetailsAboutARequest request;
      }
      public class and_the_security_constraint_is_not_met
      {
        Establish c = () =>
        {
          depends.on<IVerifyAConstraint>(() => false);
          request = fake.an<IProvideDetailsAboutARequest>();
          feature = depends.on<IImplementAUserStory>();
        };
        Because b = () =>
          spec.catch_exception(() => sut.process(request));

        It throws_a_security_exception = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();

        static IImplementAUserStory feature;
        static IProvideDetailsAboutARequest request;
      }
    }
  }
}