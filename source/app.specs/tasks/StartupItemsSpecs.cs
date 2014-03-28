 using app.tasks;
 using app.tasks.startup;
 using app.utility;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.tasks
{   

  [Subject(typeof(StartupItems))]
  public class StartupItemsSpecs
  {
    public abstract class concern : Observes
    {
        
    }

    public class when_creating_a_startup_step : concern
    {
      Establish c = () =>
        services = fake.an<IProvideStartupServices>();

      Because b = () =>
        result = StartupItems.Reflection.create<IRunATask>.create_instance(typeof(MyType), services);

      It returns_the_startup_step = () =>
        result.ShouldBeAn<MyType>();
        
      static IRunATask result;
      static IProvideStartupServices services;
    }

    public class MyType: IRunAStartupStep
  {
      public MyType(IProvideStartupServices services)
      {
      }

      public void run()
      {
        throw new System.NotImplementedException();
      }
  }
  }

}
