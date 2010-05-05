using System.Xml;

namespace Documight.Domain.Model
{
    public class XmlComments
    {
        readonly XmlDocument _comments;

        public XmlComments(XmlDocument comments)
        {
            _comments = comments;
        }
    }
}