using app.tasks.startup;
using app.utility.container.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(StartupServices))]
  public class StartupServicesSpecs
  {
    public abstract class concern : Observes<IProvideStartupServices,
      StartupServices>
    {
    }

    public class when_registering_an_item_into_the_container : concern
    {
      public class by_concrete_type
      {
        Establish c = () =>
        {
          factory = fake.an<ICreateOneDependency>();
          factories = depends.on<ICreateDependencyFactories>();

          factories.setup(x => x.create_factory<MyType>()).Return(factory);
        };

        Because b = () =>
          sut.register<MyType>();

        It registers_the_factory_into_the_set_of_factories = () =>
          concrete_sut.services[typeof(MyType)].ShouldEqual(factory);

        static ICreateOneDependency factory;
        static ICreateDependencyFactories factories;
      }

      public class by_contract_and_implementation
      {
        Establish c = () =>
        {
          factory = fake.an<ICreateOneDependency>();
          factories = depends.on<ICreateDependencyFactories>();

          factories.setup(x => x.create_factory<IMyContract, MyType>()).Return(factory);
        };

        Because b = () =>
          sut.register<IMyContract, MyType>();

        It registers_the_factory_into_the_set_of_factories = () =>
          concrete_sut.services[typeof(IMyContract)].ShouldEqual(factory);

        static ICreateOneDependency factory;
        static ICreateDependencyFactories factories;
      }

      public class by_contract_instance
      {
        Establish c = () =>
        {
          factory = fake.an<ICreateOneDependency>();
          my_type = new MyType();
          factories = depends.on<ICreateDependencyFactories>();

          factories.setup(x => x.create_factory(my_type)).Return(factory);
        };

        Because b = () =>
          sut.register(my_type);

        It registers_the_factory_into_the_set_of_factories = () =>
          concrete_sut.services[typeof(MyType)].ShouldEqual(factory);

        static ICreateOneDependency factory;
        static ICreateDependencyFactories factories;
        static MyType my_type;
      }
    }

    public class MyType : IMyContract
    {
    }

    public interface IMyContract
    {
    }
  }
}