using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralCalculator.Models
{
    public class PartyStatistic
    {
        public string Party { get; set; }
        public int NumberVotes { get; set; }
        public PartyStatistic(string party)
        {
            Party = party;
        }
        public PartyStatistic(string party, int votes)
        {
            Party = party;
            NumberVotes = votes;
        }
    }
}
