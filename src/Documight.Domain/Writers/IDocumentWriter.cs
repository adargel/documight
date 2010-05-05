using Documight.Domain.Model;

namespace Documight.Domain.Writers
{
    public interface IDocumentWriter
    {
        void Write(Document model, string outputPath);
    }
}