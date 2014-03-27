using System;
using System.Data.SqlClient;
using app.utility.container.basic;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.utility
{
  [Subject(typeof(SimpleDependencyFactory))]
  public class SimpleDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneDependency,
      SimpleDependencyFactory>
    {
    }

    public class when_it_creates_a_dependency : concern
    {
      Establish c = () =>
      {
        the_result = new SqlConnection();
        depends.on<Func<object>>(() => the_result);
      };

      Because b = () =>
        result = sut.create();

      It returns_the_object_created_by_its_provided_delegate = () =>
        result.ShouldEqual(the_result);

      static object result;
      static SqlConnection the_result;
    }
  }
}