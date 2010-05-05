using Machine.Specifications;

namespace Documight.Console.Specs
{
    public class ArgumentSpecs
    {
        protected static string[] argString;
        protected static Arguments args;
    }

    public class When_creating_args_instance_with_no_parameters : ArgumentSpecs
    {
        Because of = () => args = new Arguments();

        It returns_default_input_path = () =>
            args.InputPath.ShouldEqual("document");

        It returns_default_output_path = () =>
            args.OutputPath.ShouldEqual("documentation");
    }

    public class When_creating_args_instance_with_input_path_parameter : ArgumentSpecs
    {
        Because of = () => args = new Arguments(new[] { "/input", "input" });

        It returns_the_given_path_for_input_path = () =>
            args.InputPath.ShouldEqual("input");

        It returns_default_output_path = () =>
            args.OutputPath.ShouldEqual("documentation");
    }

    public class When_creating_args_instance_with_output_path_parameter : ArgumentSpecs
    {
        Because of = () => args = new Arguments(new[] { "/output", "output" });

        It returns_the_given_path_for_output_path = () =>
            args.OutputPath.ShouldEqual("output");

        It returns_default_input_path = () =>
            args.InputPath.ShouldEqual("document");
    }

    public class When_creating_args_instance_with_all_parameters : ArgumentSpecs
    {
        Because of = () => args = new Arguments(new[] { "/input", "input", "/output", "output" });

        It returns_the_given_path_for_input_path = () =>
            args.InputPath.ShouldEqual("input");

        It returns_the_given_path_for_output_path = () =>
             args.OutputPath.ShouldEqual("output");
    }
}