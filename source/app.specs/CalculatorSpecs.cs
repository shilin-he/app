using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Rhino.Mocks;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<ICalculate, Calculator>
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

        It disposes_its_resources = () =>
        {
          connection.received(x => x.Dispose());
          command.received(x => x.Dispose());
        };

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

    public class when_shutting_off_the_calculator : concern
    {
      public class and_they_are_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();

          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          sut.shut_off();

        It does_not_do_anything_special = () =>
        {
        };

        static IPrincipal principal;
      }
      public class and_they_are_not_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();

          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          spec.catch_exception(() => sut.shut_off());

        It throws_a_security_exception = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();

        static IPrincipal principal;
      }
    }
  }
}