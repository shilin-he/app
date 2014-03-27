using app.utility.container;
using app.utility.container.basic;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.utility
{
  [Subject(typeof(Container))]
  public class ContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
      Container>
    {
    }

    public class when_observation_name : concern
    {
      Because b = () =>
        sut.an<>()

      It first_observation = () => 
    }
  }
}