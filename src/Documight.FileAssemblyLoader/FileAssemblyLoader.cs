using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Documight.Domain.Loaders;

namespace Documight.FileAssemblyLoader
{
    public class FileAssemblyLoader : IAssemblyLoader
    {
        public Assembly[] LoadAssembliesFrom(string path)
        {
            return
            Directory.GetFiles(path)
                .Where(f => Path.GetExtension(f) == ".dll")
                .Select(Assembly.LoadFrom).ToArray();
        }
    }
}