namespace Documight.Console
{
    public class Arguments
    {
        public Arguments(string[] args)
            : this()
        {
            for (var index = 0; index < args.Length; index++)
            {
                switch (args[index])
                {
                    case "/input":
                        InputPath = args[index + 1];
                        break;
                    case "/output":
                        OutputPath = args[index + 1];
                        break;
                }
            }
        }

        public Arguments()
        {
            InputPath = "document";
            OutputPath = "documentation";
        }

        public string InputPath { get; set; }
        public string OutputPath { get; set; }
    }
}