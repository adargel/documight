using Documight.Domain;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Documight.Console.Specs
{
    public class When_running_the_console_with_no_args
    {
        static Console console;
        static Mock<IDocumentation> documentEngine;

        Establish context = () =>
            {
                documentEngine = new Mock<IDocumentation>();
                console = new Console(documentEngine.Object);
            };

        Because of = () => console.Run();

        It creates_the_documentation_using_default_input_and_output_paths = () =>
            documentEngine.Verify(e => e.Create("document", "documentation"));
    }
}