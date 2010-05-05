using System.Reflection;
using Documight.Domain.Builders;
using Documight.Domain.Loaders;
using Documight.Domain.Model;
using Documight.Domain.Writers;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Documight.Domain.Specs
{
    public class When_creating_the_documentation
    {
        protected static Documentation docs;
        protected static Mock<IAssemblyLoader> assemblyLoader;
        protected static Mock<ICommentLoader> commentLoader;
        protected static Mock<IDocumentWriter> docWriter;
        protected static Mock<IDocumentModelBuilder> docBuilder;
        protected static Document model;
        protected static Assembly[] assemblies;
        protected static XmlComments[] comments;
        protected static string inputPath = "docinput";
        protected static string outputPath = "docoutput";

        Establish context = () =>
            {
                model = new Document();

                assemblyLoader = new Mock<IAssemblyLoader>();
                assemblyLoader.Setup(a => a.LoadAssembliesFrom(inputPath)).Returns(assemblies);

                commentLoader = new Mock<ICommentLoader>();
                commentLoader.Setup(c => c.LoadCommentsFrom(inputPath)).Returns(comments);

                docBuilder = new Mock<IDocumentModelBuilder>();
                docBuilder.Setup(b => b.Build(assemblies, comments)).Returns(model);

                docWriter = new Mock<IDocumentWriter>();

                docs = new Documentation(assemblyLoader.Object, commentLoader.Object, docBuilder.Object, docWriter.Object);
            };

        Because of = () => 
            docs.Create(inputPath, outputPath);

        It loads_dlls_from_input_directory = () =>
            assemblyLoader.Verify(a => a.LoadAssembliesFrom(inputPath));

        It loads_comments_from_input_directory = () =>
            commentLoader.Verify(c => c.LoadCommentsFrom(inputPath));

        It gets_the_documentation_model_using_the_assemblies_and_comments = () =>
            docBuilder.Verify(b => b.Build(assemblies, comments));

        It outputs_the_documentation_to_the_output_directory = () =>
            docWriter.Verify(w => w.Write(model, outputPath));
    }
}