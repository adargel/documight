using System.Reflection;
using Documight.Domain.Model;

namespace Documight.Domain.Builders
{
    public interface IDocumentModelBuilder
    {
        Document Build(Assembly[] assemblies, XmlComments[] comments);
    }
}