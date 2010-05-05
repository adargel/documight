using System.Reflection;

namespace Documight.Domain.Loaders
{
    public interface IAssemblyLoader
    {
        Assembly[] LoadAssembliesFrom(string path);
    }
}