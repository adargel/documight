using Documight.Domain;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Documight.Console.Specs
{
    public class ConsoleSpecs
    {
        protected static Console console;
        protected static Mock<IDocumentation> documentEngine;

        Establish context = () =>
            {
                documentEngine = new Mock<IDocumentation>();
                console = new Console(documentEngine.Object);
            };
    }

    public class When_running_the_console
    {
        protected static Console console;
        protected static Mock<IDocumentation> documentEngine;

        Establish context = () =>
        {
            documentEngine = new Mock<IDocumentation>();
            console = new Console(documentEngine.Object);
        };

        Because of = () => console.Run(new Arguments());

        It calls_the_documentation_engine_with_the_parameters_given_to_generate_the_documentation = ()=>
            documentEngine.Verify(e => e.Create("document", "documentation"));
    }
}