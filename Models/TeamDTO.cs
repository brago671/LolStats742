using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStats742.Models
{
    public class TeamDTO
    {
        public List<BanDTO> Ban { get; set; }
        public ObjectivesDTO Objectives { get; set; }
        public int TeamId { get; set; }
        public bool Win { get; set; }
    }
}