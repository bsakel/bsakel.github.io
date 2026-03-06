using Statiq.Common;
using Statiq.Core;

namespace BsakelBlog.Pipelines;

public class AssetsPipeline : Pipeline
{
    public AssetsPipeline()
    {
        InputModules = new ModuleList
        {
            new ReadFiles("assets/**/*")
        };

        OutputModules = new ModuleList
        {
            new WriteFiles()
        };
    }
}
