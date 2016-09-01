using ElectoralCalculator.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectoralCalculator.ViewModel
{
    public class VotingViewModel :ViewModelBase
    {
        MainViewModel _mainVm;

       static VoicesStatisticViewModel _statisticVM;
        public VoicesStatisticViewModel StatisticVM
        {
            get { return _statisticVM; }
            set { _statisticVM = value;  RaisePropertyChanged("StatisticVM"); }
        }

        private bool _isAuthenticated;
        public bool IsAuthenticated
        {get { return _isAuthenticated; }
        }
        private Person _person;
        public Person Person
        {
            get { return _person; }
            private set { _person = value; }
        }
        private ObservableCollection<CandidatesVoices> _candidates;
        public ObservableCollection<CandidatesVoices> Candidates
        {
            get { return _candidates; }
            private set
            {
                if (_candidates != value)
                {
                    _candidates = value;
                    RaisePropertyChanged("Candidates");
                }
            }
        }

        public VotingViewModel(Person PersonLogin, bool isAuthenticated, MainViewModel mainVM)
        {
            _mainVm = mainVM;
            _isAuthenticated = isAuthenticated;
            Person = PersonLogin;
            DataOperation data = new DataOperation();
            var candidate = data.allCandidates();
            Candidates = new ObservableCollection<CandidatesVoices>();
            foreach(Candidate can in candidate)
            {
                Candidates.Add(new CandidatesVoices(can));
            }
        }
        private RelayCommand votingCommand;
        public ICommand VotingCommand { get {
                if (votingCommand == null)
                {
                    votingCommand = new RelayCommand(() => Voting());
                }
                return votingCommand;
            } }
        public bool CanVoting()
        {
            bool vot=false;
            if (Person != null)
            {
                vot = !Person.Vote;
            }
            return vot;
        }
        public void Voting()
        {
            if (Person != null)
            {
                if (Person.Vote != true)
                {
                    DataOperation data = new DataOperation();
                    Candidate Candidate = selectedCandidate();
                    data.AddVoice(Person.Pesel, Candidate);
                    data.ChangeVote(Person.Pesel);
                    Person.Vote = true;
                }
                StatisticVM = new VoicesStatisticViewModel(_mainVm, false);
                _mainVm.CurrentViewModel = StatisticVM;

            }
        }
        public Candidate selectedCandidate()
        {
            if (Candidates != null)
            {
                List<CandidatesVoices> can = Candidates.Where(s => s.IsSelect == true).ToList<CandidatesVoices>();
                if (can.Count > 1 || can.Count == 0)
                {
                    return null;
                }
                else
                {
                    Candidate ct = new Candidate();
                    ct.Id = can[0].ID;
                    ct.Name = can[0].Name;
                    ct.Party = can[0].Party;
                    return ct;
                }
            }
            else{ return null;}
        }



    }
}
