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

      public class and_it_cannot_find_the_factory_for_the_type
      {
        Establish c = () =>
        {
          factories = new Dictionary<Type, ICreateOneDependency>();
          the_special_case = fake.an<ICreateOneDependency>();
          depends.on(factories);
          depends.on<ICreateADependencyFactoryWhenItIsMissing>(x =>
          {
            x.ShouldEqual(typeof(SomeType));
            return the_special_case;
          });
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(SomeType));

        It returns_the_factory_created_by_the_missing_factory_builder = () =>
          result.ShouldEqual(the_special_case);

        static ICreateOneDependency result;
        static ICreateOneDependency the_special_case;
        static IDictionary<Type, ICreateOneDependency> factories;
      }
      public class SomeType
      {
      }
    }
  }
}