using System;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class when_adding: concern
    {
      public class two_positive_numbers
      {
        //Act
        Because b = () =>
          result = sut.add(2, 3);

        //Assert
        It returns_the_sum = () =>
          result.ShouldEqual(5);

        static int result;
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