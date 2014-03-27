using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        new MessyTesting().some_method();
      }
    }

    public class when_testing_the_difficult_to_test : concern
    {
    }
  }

  public class MessyTesting
  {
    public DataTable some_method()
    {
      var connection = new SqlConnection(ConfigurationManager.AppSettings["connection_string"]);
      using (connection)
      {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
          command.CommandText = "SELECT * FROM Customers";
          command.CommandType = CommandType.Text;
          using (var reader = command.ExecuteReader())
          {
            var results = new DataTable();
            results.Load(reader);
            return results;
          }
        }
      }
    }
  }
}