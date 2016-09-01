using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralCalculator.Models
{
   public class CandidatesVoices
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public bool IsSelect { get; set; }
        public CandidatesVoices(Candidate candidate)
        {
            this.Name = candidate.Name;
            this.Party = candidate.Party;
            this.ID = candidate.Id;
        }
    }
}
