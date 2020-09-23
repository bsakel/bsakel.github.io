using System.Threading.Tasks;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace bsakel.github.io
{
    class Program
    {
        public static async Task<int> Main(string[] args) =>
            await Bootstrapper
                .Factory
                .CreateWeb(args)
                .DeployToGitHubPages(
                    "bsakel",
                    "bsakel.github.io",
                    Config.FromSetting<string>("GITHUB_TOKEN")
                )
                .RunAsync();
    }       
}
