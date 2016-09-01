using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralCalculator.Models
{
    public class CandidateStatistic
    {
        public string CandidateName { get; set; }
        public string Party { get; set; }
        public int Votes { get; set; }
        public CandidateStatistic(Candidate candidat)
        {
            CandidateName = candidat.Name;
            Party = candidat.Party;
        }
        public CandidateStatistic(Candidate candidat, int votes)
        {
            CandidateName = candidat.Name;
            Party = candidat.Party;
            this.Votes = votes;
        }
    }
}
