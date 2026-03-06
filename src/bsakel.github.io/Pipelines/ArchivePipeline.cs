using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace BsakelBlog.Pipelines;

public class ArchivePipeline : Pipeline
{
    public ArchivePipeline()
    {
        Dependencies.Add(nameof(PostsPipeline));

        ProcessModules = new ModuleList
        {
            new ReplaceDocuments(nameof(PostsPipeline)),
            new OrderDocuments(Config.FromDocument(doc => doc.GetDateTime("Published")))
                .Descending(),
            new PaginateDocuments(10),
            new SetDestination(
                Config.FromDocument(doc =>
                {
                    var index = doc.GetInt(Keys.Index, 1);
                    return index == 1
                        ? new NormalizedPath("index.html")
                        : new NormalizedPath($"page/{index}/index.html");
                })),
            new SetMetadata("Title", "Posts"),
            new MergeContent(new ReadFiles("index.cshtml")),
            new RenderRazor()
                .WithViewStart(new NormalizedPath("/_ViewStart.cshtml"))
        };

        OutputModules = new ModuleList
        {
            new WriteFiles()
        };
    }
}
