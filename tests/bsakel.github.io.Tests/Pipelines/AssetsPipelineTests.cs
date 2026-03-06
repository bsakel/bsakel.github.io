using BsakelBlog.Pipelines;
using Statiq.Common;
using Statiq.Core;
using Xunit;

namespace BsakelBlog.Tests.Pipelines;

public class AssetsPipelineTests
{
    private readonly AssetsPipeline _pipeline = new();

    [Fact]
    public void InputModules_ContainsReadFiles()
    {
        Assert.NotNull(_pipeline.InputModules);
        Assert.Single(_pipeline.InputModules);
        Assert.IsType<ReadFiles>(_pipeline.InputModules[0]);
    }

    [Fact]
    public void ProcessModules_IsNullOrEmpty()
    {
        Assert.True(
            _pipeline.ProcessModules is null || _pipeline.ProcessModules.Count == 0);
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
