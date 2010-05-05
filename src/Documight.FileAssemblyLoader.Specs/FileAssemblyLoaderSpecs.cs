using System;
using System.IO;
using System.Reflection;
using Documight.Domain.Loaders;
using Machine.Specifications;

namespace Documight.FileAssemblyLoader.Specs
{
    public class FileAssemblyLoaderSpecs
    {
        protected static IAssemblyLoader loader;

        Establish context = () =>
            loader = new FileAssemblyLoader();
    }

    public class When_loading_from_a_valid_path_with_assemblies : FileAssemblyLoaderSpecs
    {
        protected static Assembly[] assemblies;

        Because of = () =>
            assemblies = loader.LoadAssembliesFrom(Environment.CurrentDirectory + @"\Fixtures\");

        It returns_all_assemblies_in_the_directory = () =>
            assemblies.Length.ShouldEqual(1);
    }

    public class When_loading_from_a_valid_path_without_assemblies : FileAssemblyLoaderSpecs
    {
        static Assembly[] assemblies;

        Because of = () =>
           assemblies = loader.LoadAssembliesFrom(Environment.CurrentDirectory + @"\..\");

        It does_not_load_any_assemblies = () =>
            assemblies.Length.ShouldEqual(0);
    }

    public class When_loading_assemblies_from_invalid_path : FileAssemblyLoaderSpecs
    {
        static Exception result;

        Because of = () =>
            result = Catch.Exception(() => loader.LoadAssembliesFrom("invalid"));

        It does_not_load_assemblies = () =>
            result.ShouldBeOfType(typeof(DirectoryNotFoundException));
    }
}