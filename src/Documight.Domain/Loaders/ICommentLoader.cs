using Documight.Domain.Model;

namespace Documight.Domain.Loaders
{
    public interface ICommentLoader
    {
        XmlComments[] LoadCommentsFrom(string path);
    }
}