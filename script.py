import os

def create_solution_structure(solution_name):
  # Define the directory structure
  directories = [
    f"{solution_name}",
    f"{solution_name}/{solution_name}",
    f"{solution_name}/{solution_name}.Tests",
    f"{solution_name}/{solution_name}/Properties",
    f"{solution_name}/{solution_name}.Tests/Properties"
  ]

  # Create the directories
  for directory in directories:
    os.makedirs(directory, exist_ok=True)

  # Create the .sln file
  with open(f"{solution_name}/{solution_name}.sln", 'w') as sln_file:
    sln_file.write(f"Microsoft Visual Studio Solution File, Format Version 12.00\n")
    sln_file.write(f"# Visual Studio Version 16\n")
    sln_file.write(f"VisualStudioVersion = 16.0.28701.123\n")
    sln_file.write(f"MinimumVisualStudioVersion = 10.0.40219.1\n")
    sln_file.write(f"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{solution_name}\", \"{solution_name}\\{solution_name}.csproj\", \"{{GUID}}\"\n")
    sln_file.write(f"EndProject\n")
    sln_file.write(f"Project(\"{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}\") = \"{solution_name}.Tests\", \"{solution_name}.Tests\\{solution_name}.Tests.csproj\", \"{{GUID}}\"\n")
    sln_file.write(f"EndProject\n")
    sln_file.write(f"Global\n")
    sln_file.write(f"\tGlobalSection(SolutionConfigurationPlatforms) = preSolution\n")
    sln_file.write(f"\t\tDebug|Any CPU = Debug|Any CPU\n")
    sln_file.write(f"\t\tRelease|Any CPU = Release|Any CPU\n")
    sln_file.write(f"\tEndGlobalSection\n")
    sln_file.write(f"\tGlobalSection(ProjectConfigurationPlatforms) = postSolution\n")
    sln_file.write(f"\t\t{{GUID}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n")
    sln_file.write(f"\t\t{{GUID}}.Debug|Any CPU.Build.0 = Debug|Any CPU\n")
    sln_file.write(f"\t\t{{GUID}}.Release|Any CPU.ActiveCfg = Release|Any CPU\n")
    sln_file.write(f"\t\t{{GUID}}.Release|Any CPU.Build.0 = Release|Any CPU\n")
    sln_file.write(f"\tEndGlobalSection\n")
    sln_file.write(f"EndGlobal\n")

  # Create the .csproj files
  for project in [solution_name, f"{solution_name}.Tests"]:
    with open(f"{solution_name}/{project}/{project}.csproj", 'w') as csproj_file:
      csproj_file.write(f"<Project Sdk=\"Microsoft.NET.Sdk\">\n")
      csproj_file.write(f"  <PropertyGroup>\n")
      csproj_file.write(f"    <OutputType>Exe</OutputType>\n")
      csproj_file.write(f"    <TargetFramework>net5.0</TargetFramework>\n")
      csproj_file.write(f"  </PropertyGroup>\n")
      csproj_file.write(f"</Project>\n")

if __name__ == "__main__":
  solution_name = "MySolution"
  create_solution_structure(solution_name)