using System;
using Documight.Domain.Model;
using Machine.Specifications;

namespace Documight.FileXmlCommentsLoader.Specs
{
    public class FileXmlCommentsLoaderSpecs
    {
        protected static FileXmlCommentsLoader loader;

        Establish context = () => 
            loader = new FileXmlCommentsLoader();
    }

    public class When_loading_comments_from_a_directory_with_comment_files : FileXmlCommentsLoaderSpecs
    {
        static XmlComments[] comments;

        Because of = () => 
            comments = loader.LoadCommentsFrom(Environment.CurrentDirectory + @"\Fixtures\");

        It loads_the_comment_files_in_the_directory = () =>
            comments.Length.ShouldEqual(1);
    }

    public class When_loading_files_from_a_directory_without_comments : FileXmlCommentsLoaderSpecs
    {
        static XmlComments[] comments;

        Because of = () =>
            comments = loader.LoadCommentsFrom(Environment.CurrentDirectory + @"\..\");

        It does_not_load_any_comments = () => 
            comments.Length.ShouldEqual(0);
    }
}