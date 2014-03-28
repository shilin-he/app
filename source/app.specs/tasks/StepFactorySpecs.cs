using System;
using app.tasks;
using app.tasks.startup;
using app.utility;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.tasks
{
  public class StepFactorySpecs
  {
    public abstract class concern : Observes<ICreateAStartupStep, StartupStepFactory>
    {
    }

    public class when_creating_a_step : concern
    {
      Establish c = () =>
      {
        startup_services = depends.on<IProvideStartupServices>();
        ICreateSteps factory = (type, parameters) =>
        {
          type.ShouldEqual(typeof(MyTestType));
          parameters.ShouldContainOnly(startup_services);
          return new MyTestType(startup_services);
        };
        spec.change(() => StartupStepFactory.create_instance);
      };

      Because b = () =>
      {
        result = sut.create_step(typeof(MyTestType));
      };

      It returns_an_instance_of_the_step = () =>
      {
        var step = result.ShouldBeAn<MyTestType>();
        step.services.ShouldEqual(startup_services);
      };

      static IRunATask result;
      static IProvideStartupServices startup_services;
    }

    class MyTestType : IRunAStartupStep
    {
      public IProvideStartupServices services { get; set; }

      public MyTestType(IProvideStartupServices services)
      {
        this.services = services;
      }

      public void run()
      {
        throw new NotImplementedException();
      }
    }
  }
}