using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json.Linq;

namespace github_spa.Controllers
{
    public class SearchController : GithubController
    {
        [HttpGet]
        [Route("users/{username}")]
        public async Task<JObject> GetUser(string username, [FromQuery] int page = 1, [FromQuery] int perPage = 100)
        {
            string userSearchPath = $"search/users";
            string userQuery = $"q={WebUtility.HtmlEncode(username)}&page={WebUtility.HtmlEncode(page.ToString())}&per_page={WebUtility.HtmlEncode(perPage.ToString())}";
            var results = await GetSingleFromGithub(GetGithubApiUri(userSearchPath, userQuery).ToString());

            return results;
        }
    }
}