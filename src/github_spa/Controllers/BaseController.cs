using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json.Linq;

namespace github_spa.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        protected const string GITHUB_ADDRESS = "api.github.com";
        protected const string USER_AGENT = "TestApp";
        protected string GITHUB_AUTH_TOKEN = string.Empty;

        protected BaseController()
        {
            string tokenFromEnvironment = Environment.GetEnvironmentVariable("GITHUB_TOKEN");

            if (string.IsNullOrEmpty(tokenFromEnvironment))
            {
                throw new ArgumentNullException("Environment variable 'GITHUB_TOKEN' is not set." +
                    " Please set and restart server.");
            }

            GITHUB_AUTH_TOKEN = "token " + tokenFromEnvironment;
        }

        protected async Task<JArray> GetManyFromGithub(string uri)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", GITHUB_AUTH_TOKEN);
            client.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);
            var content = await client.GetStringAsync(uri);

            return JArray.Parse(content);
        }

        protected async Task<JObject> GetSingleFromGithub(string uri)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", GITHUB_AUTH_TOKEN);
            client.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);
            var content = await client.GetStringAsync(uri);

            return JObject.Parse(content);
        }

        protected UriBuilder GetGithubApiUri()
        {
            return new UriBuilder("https", GITHUB_ADDRESS);
        }

        protected UriBuilder GetGithubApiUri(string path)
        {
            return new UriBuilder("https", GITHUB_ADDRESS)
            {
                Path = path
            };
        }
    }
}
