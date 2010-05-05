namespace Documight.Domain.Writers
{
    public interface IDocumentWriter
    {
        void Write(DocumentModel model, string outputPath);
    }
}