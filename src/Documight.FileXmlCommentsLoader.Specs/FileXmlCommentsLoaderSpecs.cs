using System;
using Documight.Domain.Model;
using Machine.Specifications;

namespace Documight.FileXmlCommentsLoader.Specs
{
    public class When_loading_comments_from_a_directory_with_comment_files
    {
        static FileXmlCommentsLoader loader;
        static XmlComments[] comments;

        Establish context = () => 
            loader = new FileXmlCommentsLoader();

        Because of = () => 
            comments = loader.LoadCommentsFrom(Environment.CurrentDirectory + @"\Fixtures\");

        It loads_the_comment_files_in_the_directory = () =>
            comments.Length.ShouldEqual(1);
    }
}