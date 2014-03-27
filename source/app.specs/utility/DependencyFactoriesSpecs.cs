using System;
using System.Collections.Generic;
using app.utility.container.basic;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.utility
{
  [Subject(typeof(DependencyFactories))]
  public class DependencyFactoriesSpecs
  {
    public abstract class concern : Observes<IFindFactoriesThatCanCreateDependencies,
      DependencyFactories>
    {
    }

    public class when_requesting_a_factory_for_a_type : concern
    {
      public class and_it_finds_the_factory_for_the_type
      {
        Establish c = () =>
        {
          factories = new Dictionary<Type, ICreateOneDependency>();
          depends.on(factories);
          the_factory_that_can_create_the_type = fake.an<ICreateOneDependency>();

          factories[typeof(SomeType)] = the_factory_that_can_create_the_type;
          factories[typeof(int)] = fake.an<ICreateOneDependency>();
          factories[typeof(string)] = fake.an<ICreateOneDependency>();
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(SomeType));

        It returns_the_factory_for_the_type = () =>
          result.ShouldEqual(the_factory_that_can_create_the_type);

        static ICreateOneDependency result;
        static ICreateOneDependency the_factory_that_can_create_the_type;
        static IDictionary<Type, ICreateOneDependency> factories;
      }

      public class SomeType
      {
      }
    }
  }
}