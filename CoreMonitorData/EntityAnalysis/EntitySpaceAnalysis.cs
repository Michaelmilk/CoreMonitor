using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMonitorCore.EntityAnalysis
{
    public class EntitySpaceAnalysisDto : EntityAnalysis
    {
        public string EntitySpaceName { get; set; }
        public string EntitySpaceVersion { get; set; }
        public EntitySpaceAnalysisDto(int id, string name, string createdBy, string createdTime, string updatedBy, string updatedTime, string customerId, string customerEnv, string entitySpaceName, string entitySpaceVersion) : base(id, name, createdBy, createdTime, updatedBy, updatedTime, customerId, customerEnv)
        {
            this.EntitySpaceName = entitySpaceName;
            this.EntitySpaceVersion = entitySpaceVersion;
        }
    }
}
