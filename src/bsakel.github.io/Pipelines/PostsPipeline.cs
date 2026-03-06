using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Razor;
using Statiq.Yaml;

namespace BsakelBlog.Pipelines;

public class PostsPipeline : Pipeline
{
    public PostsPipeline()
    {
        InputModules = new ModuleList
        {
            new ReadFiles("posts/*.md")
        };

        ProcessModules = new ModuleList
        {
            new ExtractFrontMatter(new ParseYaml()),
            new RenderMarkdown(),
            new SetDestination(
                Config.FromDocument(doc =>
                {
                    var fileName = doc.Source.FileNameWithoutExtension.ToString();
                    return new NormalizedPath($"posts/{fileName}.html");
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
