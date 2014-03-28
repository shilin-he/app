using System;
using app.tasks.startup;
using app.utility.container;
using app.utility.container.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(DependencyFactoryBuilder))]
  public class DependencyFactoryBuilderSpecs
  {
    public abstract class concern : Observes<ICreateDependencyFactories,
      DependencyFactoryBuilder>
    {
    }

    public class when_creating_a_dependency : concern
    {
      public class by_contract_and_implementation
      {
        Establish c = () =>
          the_container = depends.on<IFetchDependencies>();

        Because b = () =>
          result = sut.create_factory<IContract, Implementation>();

        It returns_an_automatic_dependency_factory = () =>
        {
          var factory = result.ShouldBeAn<AutomaticDependencyFactory>();
          factory.container.ShouldEqual(the_container);
          factory.type_to_create.ShouldEqual(typeof(Implementation));
          factory.constructor_selection_strategy.ShouldEqual(StartupItems.Reflection.greediest_ctor);
        };

        static ICreateOneDependency result;
        static IFetchDependencies the_container;
      }

      public class by_implementation
      {
        Establish c = () =>
          the_container = depends.on<IFetchDependencies>();

        Because b = () =>
          result = sut.create_factory<Implementation>();

        It returns_an_automatic_dependency_factory = () =>
        {
          var factory = result.ShouldBeAn<AutomaticDependencyFactory>();
          factory.container.ShouldEqual(the_container);
          factory.type_to_create.ShouldEqual(typeof(Implementation));
          factory.constructor_selection_strategy.ShouldEqual(StartupItems.Reflection.greediest_ctor);
        };

        static ICreateOneDependency result;
        static IFetchDependencies the_container;
      }

      public class by_instance
      {
        Establish c = () =>
          the_instance = new Implementation();

        Because b = () =>
          result = sut.create_factory(the_instance);

        It returns_an_automatic_dependency_factory = () =>
        {
          var factory = result.ShouldBeAn<SimpleDependencyFactory>();
          factory.create().ShouldEqual(the_instance);
        };

        static ICreateOneDependency result;
        static Implementation the_instance;
      }
      public class Implementation : IContract
      {
      }

      public interface IContract
      {
      }
    }
  }
}