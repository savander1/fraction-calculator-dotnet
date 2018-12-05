#tool "nuget:?package=Microsoft.TestPlatform"
#addin "nuget:?package=Cake.DoInDirectory"
#addin "nuget:?package=Cake.Npm"

var target = Argument("target", "Default");


Task("Clean")
  .Does(() =>
  {
    DotNetCoreClean("");
  });

Task("Restore")
  .Does(() =>
  {
    DotNetCoreRestore("");
    DoInDirectory("./fraction-calculator-dotnet.ui", () => {
        NpmInstall();
    });
  });

Task("Build")
  .Does(() =>
  {
    DotNetCoreMSBuild();
  });

Task("Test")
  .Does(() => {
    
    var testSettings = new VSTestSettings{
        ToolPath = Context.Tools.Resolve("vstest.console.exe"),
        Parallel = true
    }.WithLogger("Console");
    VSTest("fraction-calculator-dotnet.Tests/bin/Debug/netcoreapp2.1/fraction-calculator-dotnet.Tests.dll", testSettings);
    DoInDirectory("./fraction-calculator-dotnet.ui", () => {
        NpmRunScript("test");
    });
  });

Task("CIBuild")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build");

Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("Test");

RunTarget(target);