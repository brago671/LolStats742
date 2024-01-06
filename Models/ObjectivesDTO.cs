using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStats742.Models
{
    public class ObjectivesDTO
    {
        public ObjectiveDTO Baron{ get; set; }
        public ObjectiveDTO Champion { get; set; }
        public ObjectiveDTO Dragon { get; set; }
        public ObjectiveDTO Inhibitor { get; set; }
        public ObjectiveDTO RiftHerald { get; set; }
        public ObjectiveDTO Tower { get; set; }
    }
}
