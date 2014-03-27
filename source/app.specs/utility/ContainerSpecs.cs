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

    public class when_requesting_an_dependency : concern
    {
      Because b = () =>
        result = sut.an<SomeDependency>();

      It returns_the_instance_created_by_the_factory_for_the_type = () => 

      static SomeDependency result;
    }

    public class SomeDependency
    {
    }
  }
}