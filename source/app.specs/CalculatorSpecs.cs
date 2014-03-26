using System;
using System.Data;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      public static IDbConnection connection;
    }

    public class when_created : concern
    {
      It does_not_open_the_connection = () =>
        connection.never_received(x => x.Open());
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        Establish c = () =>
        {
          command = fake.an<IDbCommand>();

          connection.setup(x => x.CreateCommand()).Return(command);
        };

        //Act
        Because b = () =>
          result = sut.add(2, 3);

        //Assert
        It opens_a_connection_to_the_database = () =>
          connection.received(x => x.Open());

        It runs_a_query = () =>
          command.received(x => x.ExecuteNonQuery());

        It returns_the_sum = () =>
          result.ShouldEqual(5);

        static int result;
        static IDbCommand command;
      }

      public class a_negative_and_a_positive
      {
        //Act
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        //Assert
        It throws_an_argument_exception = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();
      }
    }
  }
}