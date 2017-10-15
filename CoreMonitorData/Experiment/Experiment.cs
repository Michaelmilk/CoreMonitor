using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMonitorCore.Experiment
{
    public class ExperimentDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public AnalysisType AnalysisType {get;set;}
        public string CreatedBy {get;set;}
        public string CreatedTime {get;set;}
        public string UpdatedBy {get;set;}
        public string UpdatedTime {get;set;}
        public string EntitySpaceName {get;set;}
        public string EntitySpaceUrl {get;set;}
        public string EntityViewName {get;set;}
        public string EntityViewUrl {get;set;}
        public string CustomerId {get;set;}
        public string CustomerEnv {get;set;}

        public ExperimentDto(int id, string name, AnalysisType type, string createdBy, string createdTime, string updatedBy, string updatedTime)
        {
            this.Id = id;
            this.Name = name;
            this.AnalysisType = type;
            this.CreatedBy = createdBy;
        }
    }
}
