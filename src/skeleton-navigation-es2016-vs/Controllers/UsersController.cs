using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<JArray> GetUsers()
        {
            return await GetManyFromGithub(GetGithubApiUri("users").ToString());
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<JObject> GetUser(string username)
        {
            string userPathEscaped = $"users/{WebUtility.HtmlEncode(username)}";
            var result = await GetSingleFromGithub(GetGithubApiUri(userPathEscaped).ToString());

            return result;
        }
    }
}