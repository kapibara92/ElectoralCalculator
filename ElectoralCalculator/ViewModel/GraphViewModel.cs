using ElectoralCalculator.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralCalculator.ViewModel
{
    public class GraphViewModel : ViewModelBase
    {
        private int _invalidVotes;
        public int InvalidVotes
        {
            get { return _invalidVotes; }
            set { _invalidVotes = value; RaisePropertyChanged("InvalidVotes"); }
        }
        private Collection<CandidateStatistic> _candidateVotes;
        public Collection<CandidateStatistic> CandidateVotes
        {
            get { return _candidateVotes; }
            set
            {
                _candidateVotes = value;
                RaisePropertyChanged("CandidateVotes");
            }
        }
        private Collection<PartyStatistic> _partyVotes;
        public Collection<PartyStatistic> PartyVotes
        {
            get { return _partyVotes; }
            set
            {
                _partyVotes = value;
                RaisePropertyChanged("PartyVotes");
            }
        }
        public GraphViewModel()
        { }
        public GraphViewModel(ObservableCollection<CandidateStatistic> candidate, ObservableCollection<PartyStatistic> parties, int invalidVotes)
        {
            this.InvalidVotes = invalidVotes;
            this.CandidateVotes = candidate;
            this.PartyVotes = parties;
        }
    }
}
