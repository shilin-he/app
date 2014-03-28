using System;
using System.Collections;
using System.Collections.Generic;
using app.tasks;
using app.tasks.startup;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{

  [Subject(typeof(Start))]
  public class StartSpecs
  {
    public abstract class concern : Observes<Start>
    {

    }

    public class when_start : concern
    {
      Because b = () =>
      {
        startup_step_builder = Start.by<ConfiguringFrontController>();
        result = new List<Type>(startup_step_builder.get_steps());
      };

      It adds_a_startup_step_to_the_startup_step_builder = () =>
        result[0].ShouldEqual(typeof(ConfiguringFrontController));

      static IBuildStartSteps startup_step_builder;
      static IList<Type> result;
    }
  }
}
