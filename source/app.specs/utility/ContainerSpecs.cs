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

    public class when_get_an_instance_of_a_type : concern
    {
      Because b = () =>
        sut.an<>()

      It returns_an_instance_of_the_type_with_all_its_dependencies_loaded = () => 
    }
  }
}