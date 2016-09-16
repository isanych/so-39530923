using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;

internal static class so39530923
{
    private static void Test(MSBuildWorkspace workspace)
    {
        using (workspace)
        {
            var solution = workspace.OpenSolutionAsync(@"..\..\..\Espera\Espera.sln").Result;
            Console.WriteLine($"{solution.FilePath} from https://github.com/flagbug/Espera");
            foreach (var project in solution.Projects)
            {
                Console.WriteLine($"{project.Name} has {project.MetadataReferences.Count} references");
            }
        }
    }

    private static void Main()
    {
        Console.WriteLine("No workarounds");
        Test(MSBuildWorkspace.Create());
        Console.WriteLine("\nWorkarounds from https://github.com/dotnet/roslyn/issues/2824 & co");
        var workspace = MSBuildWorkspace.Create(new Dictionary<string, string>
        {
            ["CheckForSystemRuntimeDependency"] = "true",
            ["DesignTimeBuild"] = "true",
            ["IntelliSenseBuild"] = "true",
            ["BuildingInsideVisualStudio"] = "true"
        });
        workspace.LoadMetadataForReferencedProjects = true;
        Test(workspace);
    }
}
