using ElectoralCalculator.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElectoralCalculator.ViewModel
{
    public class LogViewModel : ViewModelBase
    {
        MainViewModel _mainVM;
        VotingViewModel _votingVm;
        VoicesStatisticViewModel _statisticVM;
        public VotingViewModel VotingVM
        {get { return _votingVm; }
            set { _votingVm = value; RaisePropertyChanged("VotingVM"); }
            }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value != _surname)
                {
                    _surname = value;
                    RaisePropertyChanged("Surname");
                }
            }
        }
        private string _pesel;
        public string Pesel
        {
            get { return _pesel; }
            set
            {
                if (value != _pesel)
                {
                    _pesel = value;
                    RaisePropertyChanged("Pesel");
                }
            }
        }
        private Person _person;
        public Person Person{
            get {
                if (_person == null)
                {
                    _person = new Person();
                }
                return _person;
            }
            private set
            {
                _person = value;
                RaisePropertyChanged("Person");
            }
            }
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
        
       private VotingViewModel _votingViewModel;

        public LogViewModel() {
          //  VotingViewCommand = new RelayCommand(() => ExecuteVotingViewCommand());
        }
        public LogViewModel(MainViewModel mainVM)
        {
            VotingViewCommand = new RelayCommand(() => ExecuteVotingViewCommand(), canLog);
            _mainVM = mainVM;
        }
        public LogViewModel(MainViewModel mainVM, bool isLogOut)
        {
            IsAuthenticated = false;
            Person = null;
            VotingViewCommand = new RelayCommand(() => ExecuteVotingViewCommand(), canLog);
            _mainVM = mainVM;
        }
        public ICommand VotingViewCommand { get; private set; }
        private void ExecuteVotingViewCommand()
        {
            if (!IsAuthenticated)
            {
                LogOn();
            }
            if (IsAuthenticated)
            {
                DataOperation data = new DataOperation();
                if (data.canVote(long.Parse(Pesel)) == true)
                {
                    VotingVM = new VotingViewModel(Person, IsAuthenticated, _mainVM);
                    _mainVM.CurrentViewModel = VotingVM;
                }
                else
                {
                    _statisticVM = new VoicesStatisticViewModel(_mainVM, IsAuthenticated);
                    _mainVM.CurrentViewModel = _statisticVM;
                }
            }
        }
        private bool canLog()
        {
            return !IsAuthenticated;
        }
        private void LogOn()
        {
            try
            {
                DataOperation databas = new DataOperation();
                if (IsValidData(Pesel,Name,Surname))
                {
                    databas.AddPerson(Name, Surname, long.Parse(Pesel));
                    Person.Name = Name; Person.Surname = Surname; Person.Pesel = long.Parse(Pesel);
                    IsAuthenticated = true;
                    databas.AddCandidates();
                    _mainVM.IsAuthenticated = IsAuthenticated;
                }
                else
                {
                    throw new FormatException();
                }
         
            }catch(Exception e)
            { System.Windows.MessageBox.Show(e.Message); }
        }
        private bool IsValidData(string pesel, string Name, string Surname)
        {
            Pesel validPesel = new Pesel(pesel);
            if(((Name != "") && (Surname != "")) && (Pesel != "") && (validPesel.IsValid == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
