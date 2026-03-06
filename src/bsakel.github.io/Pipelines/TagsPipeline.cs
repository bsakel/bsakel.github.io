using System;
using System.Collections.Generic;
using System.Linq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace BsakelBlog.Pipelines;

public class TagsPipeline : Pipeline
{
    public TagsPipeline()
    {
        Dependencies.Add(nameof(PostsPipeline));
        Dependencies.Add(nameof(DraftsPipeline));

        ProcessModules = new ModuleList
        {
            new ExecuteConfig(
                Config.FromContext(ctx =>
                {
                    var posts = ctx.Outputs.FromPipeline(nameof(PostsPipeline));
                    if (ctx.Settings.GetBool("IsPreview"))
                    {
                        var drafts = ctx.Outputs.FromPipeline(nameof(DraftsPipeline))
                            .Select(d => d.Clone(new MetadataItems { { "IsDraft", true } }));
                        return (IEnumerable<IDocument>)posts.Concat(drafts).ToList();
                    }
                    return (IEnumerable<IDocument>)posts;
                })),
            new OrderDocuments(Config.FromDocument(doc => doc.GetDateTime("Published")))
                .Descending(),
            new GroupDocuments("Tags"),
            new ExecuteConfig(
                Config.FromContext(async ctx =>
                {
                    var inputs = ctx.Inputs.ToList();
                    var results = new List<IDocument>();

                    // Per-tag pages: each group doc gets a destination
                    foreach (var groupDoc in inputs)
                    {
                        var tagName = groupDoc.GetString(Keys.GroupKey);
                        var slug = tagName.ToLower().Replace(" ", "-");
                        var tagPage = groupDoc.Clone(
                            new NormalizedPath($"tags/{slug}/index.html"),
                            new MetadataItems
                            {
                                { "Title", tagName }
                            });
                        results.Add(tagPage);
                    }

                    // Overview page: children are the tag group documents
                    var overviewPage = ctx.CreateDocument(
                        new NormalizedPath("tags/index.html"),
                        new MetadataItems
                        {
                            { "Title", "Tags" },
                            { Keys.Children, (IReadOnlyList<IDocument>)results.ToList() }
                        });
                    results.Add(overviewPage);

                    return (IEnumerable<IDocument>)results;
                })),
            new MergeContent(new ReadFiles("tags/index.cshtml")),
            new RenderRazor()
                .WithViewStart(new NormalizedPath("/_ViewStart.cshtml"))
        };

        OutputModules = new ModuleList
        {
            new WriteFiles()
        };
    }
}
