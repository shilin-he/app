using app.utility.container;
using app.utility.container.basic;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs.utility
{
    [Subject(typeof (Container))]
    public class ContainerSpecs
    {
        public abstract class concern : Observes<IFetchDependencies,
            Container>
        {
        }

        public class when_requesting_a_type : concern
        {
            public class that_is_known_by_the_resolver
            {
                private Because b = () =>
                    sut.an<>()...;

                private It should_return_an_object_of_that_type = () => 
            }
        }
    }
}