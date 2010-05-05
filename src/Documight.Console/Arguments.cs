namespace Documight.Console
{
    public class Arguments
    {
        public Arguments()
        {
            InputPath = "document";
            OutputPath = "documentation";
        }

        public string InputPath { get; set; }
        public string OutputPath { get; set; }
    }
}