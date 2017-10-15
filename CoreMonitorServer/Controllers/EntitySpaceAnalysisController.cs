using CoreMonitorCore.EntityAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CoreMonitorServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntitySpaceAnalysisController : ApiController
    {
        [Route("api/entityspaceanalysis")]
        [HttpGet]
        public IHttpActionResult GetEntitySpaceAnalysisDtos()
        {
            List<EntitySpaceAnalysisDto> enttitySpaceAnalysisDtos = new List<EntitySpaceAnalysisDto>()
            {
                new EntitySpaceAnalysisDto(1, "spaceAnalysis", "jixge", "10/15/2017", "jixge", "10/15/2017", "WarpStar", "Prod", "social_net_user", "160.1.1"),
                new EntitySpaceAnalysisDto(2, "spaceAnalysis", "jixge", "10/15/2017", "jixge", "10/15/2017", "WarpStar", "Prod", "social_net_user", "160.1.2"),
                new EntitySpaceAnalysisDto(3, "spaceAnalysis", "jixge", "10/15/2017", "jixge", "10/15/2017", "WarpStar", "Prod", "social_net_user", "160.1.3"),
            };
            return Ok(enttitySpaceAnalysisDtos);
        }

        [Route("api/entityspaceanalysis/{id}")]
        [HttpGet]
        public IHttpActionResult GetEntitySpaceAnalysisById(int id)
        {
            var entityAnalysis = new EntitySpaceAnalysisDto(1, "spaceAnalysis", "jixge", "10/15/2017", "jixge", "10/15/2017", "WarpStar", "Prod", "social_net_user", "160.1.1");
            return Ok(entityAnalysis);
        }
    }
}
