using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Yaml;

namespace BsakelBlog.Pipelines;

public class PagesPipeline : Pipeline
{
    public PagesPipeline()
    {
        InputModules = new ModuleList
        {
            new ReadFiles("{!posts/,}*.md")
        };

        ProcessModules = new ModuleList
        {
            new ExtractFrontMatter(new ParseYaml()),
            new RenderMarkdown(),
            new SetDestination(".html"),
            new RenderRazor()
                .WithViewStart(new NormalizedPath("/_ViewStart.cshtml"))
        };

        OutputModules = new ModuleList
        {
            new WriteFiles()
        };
    }
}
