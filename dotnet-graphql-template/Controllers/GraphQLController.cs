using System.Threading.Tasks;
using Configuration.GraphQL;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [Route("api/graphql")]
    public class GraphQLController : Controller
    {
        private readonly ILogger _logger;
        private readonly GraphQLRoot _rootQuery;

        public GraphQLController(ILogger<GraphQLController> logger, GraphQLRoot rootQuery)
        {
            _logger = logger;
            _rootQuery = rootQuery;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryRequest queryRequest)
        {
            _logger.LogInformation($"Got query: {queryRequest.Query}");
            var schema = new Schema {Query = _rootQuery};

            ExecutionResult result = await new DocumentExecuter()
                .ExecuteAsync(_ =>
                {
                    _.Schema = schema;
                    _.Query = queryRequest.Query;
                })
                .ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}