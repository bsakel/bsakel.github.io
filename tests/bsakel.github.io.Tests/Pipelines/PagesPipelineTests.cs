using BsakelBlog.Pipelines;
using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Yaml;
using Xunit;

namespace BsakelBlog.Tests.Pipelines;

public class PagesPipelineTests
{
    private readonly PagesPipeline _pipeline = new();

    [Fact]
    public void InputModules_ContainsReadFiles()
    {
        Assert.NotNull(_pipeline.InputModules);
        Assert.Single(_pipeline.InputModules);
        Assert.IsType<ReadFiles>(_pipeline.InputModules[0]);
    }

    [Fact]
    public void ProcessModules_HasCorrectModulesInOrder()
    {
        Assert.NotNull(_pipeline.ProcessModules);
        Assert.Equal(4, _pipeline.ProcessModules.Count);
        Assert.IsType<ExtractFrontMatter>(_pipeline.ProcessModules[0]);
        Assert.IsType<RenderMarkdown>(_pipeline.ProcessModules[1]);
        Assert.IsType<SetDestination>(_pipeline.ProcessModules[2]);
        Assert.IsType<RenderRazor>(_pipeline.ProcessModules[3]);
    }

    [Fact]
    public void OutputModules_ContainsWriteFiles()
    {
        Assert.NotNull(_pipeline.OutputModules);
        Assert.Single(_pipeline.OutputModules);
        Assert.IsType<WriteFiles>(_pipeline.OutputModules[0]);
    }

    [Fact]
    public void HasNoDependencies()
    {
        Assert.Empty(_pipeline.Dependencies);
    }
}
