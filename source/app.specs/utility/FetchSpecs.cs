using app.utility.container;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs.utility
{
  [Subject(typeof(Fetch))]
  public class FetchSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_accessing_the_container_facade : concern
    {
      Establish c = () =>
      {
        container = fake.an<IFetchDependencies>();
        IResolveTheInitialContainer resolution = () => container;

        spec.change(() => Fetch.container_resolution).to(resolution);
      };
      Because b = () =>
        result = Fetch.me;

      It return_the_facade_resolved_through_the_resolution_mechanism = () =>
        result.ShouldEqual(container);

      static IFetchDependencies result;
      static IFetchDependencies container;
    }
  }
}
