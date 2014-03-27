using System;
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
      public class and_it_has_the_factory_for_the_dependency
      {
        Establish c = () =>
        {
          dependency = new SomeDependency();
          factory = fake.an<ICreateOneDependency>();
          dependencies = depends.on<IFindFactoriesThatCanCreateDependencies>();
          dependencies.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);

          factory.setup(x => x.create()).Return(dependency);
        };

        public class using_generic_arguments
        {
          Because b = () =>
            result = sut.an<SomeDependency>();

          It returns_the_instance_created_by_the_factory_for_the_dependency = () =>
            result.ShouldEqual(dependency);

          static SomeDependency result;
        }

        public class using_runtime_arguments
        {
          Because b = () =>
            result = sut.an(typeof(SomeDependency));

          It returns_the_instance_created_by_the_factory_for_the_dependency = () =>
            result.ShouldEqual(dependency);

          static object result;
        }

        static IFindFactoriesThatCanCreateDependencies dependencies;
        static SomeDependency dependency;
        static ICreateOneDependency factory;
      }

      public class and_the_factory_for_the_dependency_throws_an_breakdown_on_creation
      {
        Establish c = () =>
        {
          inner_exception = new Exception();
          created_exception = new Exception();
          factory = fake.an<ICreateOneDependency>();
          dependencies = depends.on<IFindFactoriesThatCanCreateDependencies>();
          dependencies.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);
          depends.on<ICreateDependencyCreationErrors>((type, error) =>
          {
            type.ShouldEqual(typeof(SomeDependency));
            error.ShouldEqual(inner_exception);
            return created_exception;
          });

          factory.setup(x => x.create()).Throw(inner_exception);
        };

        Because b = () =>
          spec.catch_exception(() => sut.an<SomeDependency>());

        It throws_the_breakdown_detail_created_by_the_creation_breakdown_factory = () =>
          spec.exception_thrown.ShouldEqual(created_exception);

        static IFindFactoriesThatCanCreateDependencies dependencies;
        static ICreateOneDependency factory;
        static Exception inner_exception;
        static Exception created_exception;
      }
    }

    public class SomeDependency
    {
    }
  }
}