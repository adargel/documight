using Documight.Domain;

namespace Documight.Console
{
    public class Console
    {
        readonly IDocumentation _documentEngine;

        public Console(IDocumentation documentEngine)
        {
            _documentEngine = documentEngine;
        }

        public void Run(Arguments args=null)
        {
            args = args ?? new DefaultArguments();
            _documentEngine.Create(args.InputPath, args.OutputPath);
        }
    }
}