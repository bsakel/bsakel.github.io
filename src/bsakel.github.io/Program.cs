using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Common;
using Statiq.Hosting;

bool preview = args.Contains("preview");
string[] filteredArgs = args.Where(a => a != "preview").ToArray();

if (preview)
{
    var cacheDir = Path.Combine(Directory.GetCurrentDirectory(), "cache");
    var outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
    if (Directory.Exists(cacheDir)) Directory.Delete(cacheDir, true);
    if (Directory.Exists(outputDir)) Directory.Delete(outputDir, true);
}

var bootstrapper = Bootstrapper
    .Factory
    .CreateDefault(filteredArgs);

if (preview)
{
    bootstrapper = bootstrapper.AddSetting("IsPreview", true);
}

await bootstrapper.RunAsync();

if (preview)
{
    var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output");
    var server = new Server(outputPath, 5080);
    await server.StartAsync();
    Console.WriteLine("Preview server running at http://localhost:5080");
    Console.WriteLine("Press Enter to stop.");
    Console.ReadLine();
}

return 0;
