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
    public class VoicesStatisticViewModel : ViewModelBase
    {
        MainViewModel _mainVM;
        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                _isAuthenticated = value;
                RaisePropertyChanged("IsAuthenticated");
            }
        }
        private int _invalidVotes;
        public int InvalidVotes
        {
            get { return _invalidVotes; }
            set { _invalidVotes = value; RaisePropertyChanged("InvalidVotes"); }
        }
        private int _validVotes;
        public int ValidVotes
        {
            get { return _validVotes; }
            set { _validVotes = value; RaisePropertyChanged("ValidVotes"); }
        }
        private ObservableCollection<CandidateStatistic> _candidateVotes;
        public ObservableCollection<CandidateStatistic> CandidateVotes
        {
            get { return _candidateVotes; }
            set
            {
                _candidateVotes = value;
                RaisePropertyChanged("CandidateVotes");
            }
        }
        private ObservableCollection<PartyStatistic> _partyVotes;
        public ObservableCollection<PartyStatistic> PartyVotes
        {
            get { return _partyVotes; }
            set
            {
                _partyVotes = value;
                RaisePropertyChanged("PartyVotes");
            }
        }

        private VotingViewModel _votingViewModel;

        public VoicesStatisticViewModel()
        {
            //  VotingViewCommand = new RelayCommand(() => ExecuteVotingViewCommand());
        }
        public VoicesStatisticViewModel(MainViewModel mainVM, bool isAuthentized)
        {
            this.IsAuthenticated = isAuthentized;
            _mainVM = mainVM;
            LoadData();
        }
        //private RelayCommand logOutCommand;
        //public ICommand LogOutCommand
        //{
        //    get
        //    {
        //        if (logOutCommand == null)
        //        {
        //            logOutCommand = new RelayCommand(() => ExecuteLogOutCommand());
        //        }
        //        return logOutCommand;
        //    }
        private RelayCommand _votingViewCommand;
        public ICommand VotingViewCommand {
            get { if (_votingViewCommand == null) {
                    _votingViewCommand = new RelayCommand(() => ShowGraph());
                } return _votingViewCommand;
            }
        }
        public void ShowGraph() {
            GraphViewModel ChartVM = new GraphViewModel(CandidateVotes, PartyVotes, InvalidVotes);
            GraphBar view= new GraphBar(ChartVM);
            view.Show();
        }
        public void LoadData()
        {
            DataOperation data = new DataOperation();
            CandidateVotes = data.numberCandidatesVotes();
            InvalidVotes = data.NumberInvalidVotes();
            ValidVotes = data.NumberValidVotes();
            PartyVotes = data.numberPartyVotes();
        }
        private RelayCommand _pdfSaveComaand;
        public ICommand PdfSaveCommand
        {
            get { if (_pdfSaveComaand == null)
                {
                    _pdfSaveComaand = new RelayCommand(() => generatePDF());
                }return _pdfSaveComaand; }
        }

        private void generatePDF()
        {
            PDFcreator newPdf = new PDFcreator();
            newPdf.createTitle("Votes Statistics");
            newPdf.addCandidateVotes(CandidateVotes, "Distribution of votes for individual candidates");
            newPdf.AddParagraph("Invalid votes", InvalidVotes.ToString());
            newPdf.AddParagraph("Valid votes", ValidVotes.ToString());
            newPdf.newPage();
            newPdf.addVotesStatistic(PartyVotes, "Distribution of votes for particular party");
            newPdf.SavePdf();
        }
    }
    //MainViewModel _mainVM;
    //private bool _isAuthenticated;
    //public bool IsAuthenticated
    //{
    //    get { return _isAuthenticated; }
    //    set { _isAuthenticated = value; RaisePropertyChanged("IsAuthenticated"); }
    //}
    //public VoicesStatisticViewModel(bool isAuthorized)
    //{
    //    IsAuthenticated = isAuthorized;
    //}
    //public VoicesStatisticViewModel(MainViewModel mainVM) {
    //    _mainVM = mainVM;
    }
