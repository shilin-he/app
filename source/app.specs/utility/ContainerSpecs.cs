using System.Web.Configuration;
using app.utility.container;
using app.utility.container.basic;
using developwithpassion.specifications.extensions;
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
      Establish c = () =>
      {
        depency = new SomeDependency();
        dependency_factory = depends.on<ICreateDependencies>();
        dependency_factory.setup(x => x.create<SomeDependency>()).Return(depency);
      };

      Because b = () =>
        result = sut.an<SomeDependency>();

      It returns_the_instance_created_by_the_factory_for_the_type = () =>
        result.ShouldEqual(depency);

      static SomeDependency result;
      static ICreateDependencies dependency_factory;
      static SomeDependency depency;
    }

    public class SomeDependency
    {
    }
  }
}