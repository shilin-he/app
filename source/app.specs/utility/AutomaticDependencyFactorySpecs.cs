using System;
using System.Data;
using System.Reflection;
using app.specs.testutility;
using app.utility.container;
using app.utility.container.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.utility
{
  [Subject(typeof(AutomaticDependencyFactory))]
  public class AutomaticDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneDependency,
      AutomaticDependencyFactory>
    {
    }

    public class when_creating_a_dependency : concern
    {
      Establish c = () =>
      {
        connection = fake.an<IDbConnection>();
        command = fake.an<IDbCommand>();
        reader = fake.an<IDataReader>();

        container = depends.on<IFetchDependencies>();

        greediest_ctor = ObjectFactory.expressions.targeting<ItemWithLotsOfDependencies>()
          .get_the_ctor_pointed_at_by(() => 
            new ItemWithLotsOfDependencies(null, null, null));

        depends.on(typeof(ItemWithLotsOfDependencies));
        depends.on<IGetTheConstructorToCreateAType>(x =>
        {
          x.ShouldEqual(typeof(ItemWithLotsOfDependencies));
          return greediest_ctor;
        });

        container.setup(x => x.an(typeof(IDbConnection))).Return(connection);
        container.setup(x => x.an(typeof(IDbCommand))).Return(command);
        container.setup(x => x.an(typeof(IDataReader))).Return(reader);
      };

      Because b = () =>
        result = sut.create();

      It creates_the_dependency_with_all_of_its_dependencies_resolved = () =>
      {
        var item = result.ShouldBeAn<ItemWithLotsOfDependencies>();
        item.connection.ShouldEqual(connection);
        item.command.ShouldEqual(command);
        item.reader.ShouldEqual(reader);
      };

      static object result;
      static IDbConnection connection;
      static IDbCommand command;
      static IDataReader reader;
      static ConstructorInfo greediest_ctor;
      static IFetchDependencies container;
    }

    public class ItemWithLotsOfDependencies
    {
      public IDbConnection connection;
      public IDbCommand command;
      public IDataReader reader;

      public ItemWithLotsOfDependencies(IDbConnection connection, IDbCommand command, IDataReader reader)
      {
        this.connection = connection;
        this.command = command;
        this.reader = reader;
      }

      public ItemWithLotsOfDependencies(IDbConnection connection, IDbCommand command)
      {
        this.connection = connection;
        this.command = command;
      }
    }
  }
}