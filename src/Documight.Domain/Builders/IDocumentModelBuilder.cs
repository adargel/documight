using System.Reflection;
using Documight.Domain.Model;

namespace Documight.Domain.Builders
{
    public interface IDocumentModelBuilder
    {
        DocumentModel Build(Assembly[] assemblies, XmlComments[] comments);
    }
}