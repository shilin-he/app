 using System;
 using System.Threading;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.web
{
    [Subject(typeof (TimedFrontController))]
    public class TimedFrontControllerSpecs
    {
        public abstract class concern : Observes<IProcessWebRequests,
            TimedFrontController>
        {

        }


        public class when_processing_a_request : concern
        {
            private Establish c = () =>
            {
                timer = depends.on<ITimeThings>();
                inner_controller = depends.on<IProcessWebRequests>();
                request = fake.an<IProvideDetailsAboutARequest>();


            };

            private Because b = () =>
                sut.process(request);

            //It starts_a_timer = () =>
            //    inner_controller.received(x => x.start_timer());
            private It starts_the_time_thing = () => timer.received(x => x.startTimer());

            private It delegates_the_processing_to_the_inner_controller = () =>
                inner_controller.received(x => x.process(request));

            private It ends_the_time_thing = () => timer.received(x => x.endTimer());

            //It stops_a_timer = () =>
            //    inner_controller.received(x => x.stop_timer());

            private static IProvideDetailsAboutARequest request;
            private static IProcessWebRequests inner_controller;
            private static ITimeThings timer;
        }
    }

    internal interface ITimeThings
    {
        void startTimer();
        TimeSpan endTimer();
    }
}
