using System;
using System.Data;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.events
{
  [Subject(typeof(MessyTesting))]
  public class MessyTestingSpecs
  {
    public abstract class concern : Observes<MessyTesting>
    {
    }

    public class SomeClient
    {
      public static void run()
      {
      }
    }

    public class when_testing_the_difficult_to_test : concern
    {
      Establish c = () =>
      {
        connection_string = "blah";
        command = fake.an<IDbCommand>();
        connection = fake.an<IDbConnection>();
        reader = fake.an<IDataReader>();
        table = new DataTable();
        depends.on<Func<string, string>>(x =>
        {
          x.ShouldEqual("connection_string");
          return connection_string;
        });

        depends.on<Func<IDataReader, DataTable>>(x =>
        {
          x.ShouldEqual(reader);
          return table;
        });

        depends.on<Func<string, IDbConnection>>(x =>
        {
          used_connection_string_resolution = true;
          x.ShouldEqual(connection_string);
          return connection;
        });

        connection.setup(x => x.CreateCommand()).Return(command);
        command.setup(x => x.ExecuteReader()).Return(reader);
      };

      Because b = () =>
        result = sut.some_method();

      It configures_the_command_correctly = () =>
      {
        command.CommandText.ShouldEqual("SELECT * FROM Customers");
        command.CommandType.ShouldEqual(CommandType.Text);
      };

      It should_get_customers = () =>
      {
        result.ShouldEqual(table);
      };

      static DataTable result;
      static string connection_string;
      static IDbConnection connection;
      static IDbCommand command;
      static IDataReader reader;
      static DataTable table;
      static bool used_connection_string_resolution;
    }
  }

  public class MessyTesting
  {
    Func<string, string> get_the_connection_string;
    Func<string, IDbConnection> create_connection;
    Func<IDataReader, DataTable> load_table;

    public MessyTesting(Func<string, string> get_the_connection_string, Func<string, IDbConnection> create_connection,
      Func<IDataReader, DataTable> load_table)
    {
      this.get_the_connection_string = get_the_connection_string;
      this.create_connection = create_connection;
      this.load_table = load_table;
    }

    public DataTable some_method()
    {
      var connection = create_connection(get_the_connection_string("connection_string"));
      using (connection)
      {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
          command.CommandText = "SELECT * FROM Customers";
          command.CommandType = CommandType.Text;
          using (var reader = command.ExecuteReader())
          {
            return load_table(reader);
          }
        }
      }
    }
  }
}