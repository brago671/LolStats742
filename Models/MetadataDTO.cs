using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStats742.Models
{
    internal class MetadataDTO
    {
        public string DataVersion{ get; set; }
        public string  MatchId { get; set; }
        public List<string> Partisipants {  get; set; } 
    }
}
