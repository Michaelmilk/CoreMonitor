using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMonitorCore.EntityAnalysis
{
    public class EntityAnalysis
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedTime { get; set; }
        public string CustomerId { get; set; }
        public string CustomerEnv { get; set; }

        public EntityAnalysis(int id, string name, string createdBy, string createdTime, string updatedBy, string updatedTime, string customerId, string customerEnv)
        {
            this.Id = id;
            this.Name = name;
            this.CreatedBy = createdBy;
            this.CreatedTime = createdTime;
            this.UpdatedBy = updatedBy;
            this.UpdatedTime = updatedTime;
            this.CustomerId = customerId;
            this.CustomerEnv = customerEnv;
        }
    }
}
