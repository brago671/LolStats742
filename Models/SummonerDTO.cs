﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStats742.Models
{
    internal class SummonerDTO
    {
        public string AccountId { get; set; }
        public int MyProperty { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Puuid { get; set; }
        public long SummonerLevel {  get; set; }
    }
}
