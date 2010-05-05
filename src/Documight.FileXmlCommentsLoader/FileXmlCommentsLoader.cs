using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Documight.Domain.Loaders;
using Documight.Domain.Model;

namespace Documight.FileXmlCommentsLoader
{
    public class FileXmlCommentsLoader : ICommentLoader
    {
        public XmlComments[] LoadCommentsFrom(string path)
        {
            var comments = new List<XmlComments>();
            foreach(var file in Directory.GetFiles(path).Where(f => Path.GetExtension(f).ToLower() == ".xml"))
            {
                var doc = new XmlDocument();
                doc.Load(file);
                
                comments.Add(new XmlComments(doc));
            }
            return comments.ToArray();
        }
    }
}