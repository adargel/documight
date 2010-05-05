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

    public class When_running_the_console_with_no_args : ConsoleSpecs
    {
        Because of = () => console.Run();

        It creates_the_documentation_using_default_input_and_output_paths = () =>
            documentEngine.Verify(e => e.Create("document", "documentation"));
    }

    public class When_running_the_console_with_input_arg_and_no_output_arg : ConsoleSpecs
    {
        Because of = () =>
            console.Run(new Arguments { InputPath = "input" });

        It uses_the_supplied_input_argument_and_default_output_argument = () =>
            documentEngine.Verify(e => e.Create("input", "documentation"));
    }

    public class When_running_the_console_with_output_arg_and_no_input_arg : ConsoleSpecs
    {
        Because of = () =>
            console.Run(new Arguments { OutputPath = "output" });

        It uses_the_supplied_input_argument_and_default_output_argument = () =>
            documentEngine.Verify(e => e.Create("document", "output"));
    }
}