using Documight.Domain.Builders;
using Documight.Domain.Loaders;
using Documight.Domain.Writers;

namespace Documight.Domain
{
    public class Documentation : IDocumentation
    {
        readonly IAssemblyLoader _assemblyLoader;
        readonly ICommentLoader _commentLoader;
        readonly IDocumentModelBuilder _modelBuilder;
        readonly IDocumentWriter _documentWriter;

        public Documentation(IAssemblyLoader assemblyLoader, ICommentLoader commentLoader, IDocumentModelBuilder modelBuilder, IDocumentWriter documentWriter)
        {
            _assemblyLoader = assemblyLoader;
            _commentLoader = commentLoader;
            _modelBuilder = modelBuilder;
            _documentWriter = documentWriter;
        }

        public void Create(string inputPath, string outputPath)
        {
            var assemblies = _assemblyLoader.LoadAssembliesFrom(inputPath);
            var comments = _commentLoader.LoadCommentsFrom(inputPath);

            var model = _modelBuilder.Build(assemblies, comments);

            _documentWriter.Write(model, outputPath);
        }
    }
}