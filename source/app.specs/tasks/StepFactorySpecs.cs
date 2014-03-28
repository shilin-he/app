using app.tasks;
using app.utility;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.tasks
{
    public class StepFactorySpecs
    {
        public abstract class concern : Observes<ICreateAStartupStep, StepFactory>
        {

        }

        public class when_creating_a_step : concern
        {
            private Establish c = () =>
            {
                startup_services = depends.on<IProvideStartupServices>( );
            };

            private Because b = () => { result = sut.create_step(typeof (MyTestType)); };

            private It returns_an_instance_of_the_provided_type = () =>
            {
                var step = result.ShouldBeAn<MyTestType>();
                step.Services.ShouldBeTheSameAs(startup_services);
            };

            private static IRunATask result;
            private static IProvideStartupServices startup_services;
        }

        class MyTestType : IRunAStartupStep
        {
            public IProvideStartupServices Services { get; set; }

            public MyTestType(IProvideStartupServices services)
            {
                Services = services;
            }

            public void run()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}