using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Yaml;

namespace BsakelBlog.Pipelines;

public class DraftsPipeline : Pipeline
{
    public DraftsPipeline()
    {
        InputModules = new ModuleList
        {
            new ExecuteIf(
                Config.FromContext(ctx => ctx.Settings.GetBool("IsPreview")),
                new ReadFiles("drafts/*.md"))
        };

        ProcessModules = new ModuleList
        {
            new ExtractFrontMatter(new ParseYaml()),
            new RenderMarkdown(),
            new SetDestination(
                Config.FromDocument(doc =>
                {
                    var fileName = doc.Source.FileNameWithoutExtension.ToString();
                    return new NormalizedPath($"drafts/{fileName}.html");
                })),
            new RenderRazor()
                .WithViewStart(new NormalizedPath("/_ViewStart.cshtml"))
        };

        OutputModules = new ModuleList
        {
            new WriteFiles()
        };
    }
}
