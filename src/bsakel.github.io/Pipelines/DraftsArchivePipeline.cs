using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace BsakelBlog.Pipelines;

public class DraftsArchivePipeline : Pipeline
{
    public DraftsArchivePipeline()
    {
        Dependencies.Add(nameof(DraftsPipeline));

        ProcessModules = new ModuleList
        {
            new ExecuteIf(
                Config.FromContext(ctx => ctx.Settings.GetBool("IsPreview")),
                new ReplaceDocuments(nameof(DraftsPipeline)),
                new OrderDocuments(Config.FromDocument(doc => doc.GetDateTime("Published")))
                    .Descending(),
                new PaginateDocuments(int.MaxValue),
                new SetDestination(new NormalizedPath("drafts/index.html")),
                new SetMetadata("Title", "Drafts"),
                new MergeContent(new ReadFiles("drafts/index.cshtml")),
                new RenderRazor()
                    .WithViewStart(new NormalizedPath("/_ViewStart.cshtml")))
        };

        OutputModules = new ModuleList
        {
            new WriteFiles()
        };
    }
}
