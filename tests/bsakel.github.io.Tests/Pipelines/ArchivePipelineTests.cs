using BsakelBlog.Pipelines;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Xunit;

namespace BsakelBlog.Tests.Pipelines;

public class ArchivePipelineTests
{
    private readonly ArchivePipeline _pipeline = new();

    [Fact]
    public void DependsOnPostsPipeline()
    {
        Assert.Contains(nameof(PostsPipeline), _pipeline.Dependencies);
    }

    [Fact]
    public void InputModules_IsNullOrEmpty()
    {
        Assert.True(
            _pipeline.InputModules is null || _pipeline.InputModules.Count == 0);
    }

    [Fact]
    public void ProcessModules_StartsWithReplaceDocuments()
    {
        Assert.NotNull(_pipeline.ProcessModules);
        Assert.IsType<ReplaceDocuments>(_pipeline.ProcessModules[0]);
    }

    [Fact]
    public void ProcessModules_HasCorrectModulesInOrder()
    {
        Assert.NotNull(_pipeline.ProcessModules);
        Assert.Equal(7, _pipeline.ProcessModules.Count);
        Assert.IsType<ReplaceDocuments>(_pipeline.ProcessModules[0]);
        Assert.IsType<OrderDocuments>(_pipeline.ProcessModules[1]);
        Assert.IsType<PaginateDocuments>(_pipeline.ProcessModules[2]);
        Assert.IsType<SetDestination>(_pipeline.ProcessModules[3]);
        Assert.IsType<SetMetadata>(_pipeline.ProcessModules[4]);
        Assert.IsType<MergeContent>(_pipeline.ProcessModules[5]);
        Assert.IsType<RenderRazor>(_pipeline.ProcessModules[6]);
    }

    [Fact]
    public void OutputModules_ContainsWriteFiles()
    {
        Assert.NotNull(_pipeline.OutputModules);
        Assert.Single(_pipeline.OutputModules);
        Assert.IsType<WriteFiles>(_pipeline.OutputModules[0]);
    }
}
