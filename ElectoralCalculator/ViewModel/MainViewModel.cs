using ElectoralCalculator.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Linq;
using System.Windows.Input;
using test;

namespace ElectoralCalculator.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        static LogViewModel _logViewModel ;
        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get {
                if (_logViewModel != null)
                {
                    return _logViewModel.IsAuthenticated;
                }
                else { return false; }

            }
            set
            {
                if (value != _isAuthenticated)
                {
                    _isAuthenticated = value;

                }
                //logIn = new RelayCommand(() => ExecuteLogViewCommand(), canLogView);
                //logOutCommand = new RelayCommand(() => ExecuteLogOutCommand(), canLogOut);
                //logOutCommand.RaiseCanExecuteChanged();
                //logIn.RaiseCanExecuteChanged();
            }
        }
        readonly static VoicesStatisticViewModel _statisticVM;
        public static VoicesStatisticViewModel StatisticVM
        {

            get
            {
                if (_votingViewModel != null)
                {
                    return _votingViewModel.StatisticVM;
                }
                else { return null; }
            }
        }
        readonly static VotingViewModel _votingViewModel;
        public VotingViewModel VotingVM
        {
            get {
                if (_logViewModel != null)
                {
                    return _logViewModel.VotingVM;
                }
                else
                {
                    return null;
                }
            }
        }
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value) return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._logViewModel;
            DataOperation dataOperation = new DataOperation();
            dataOperation.ChangeVote(920102286);

            //  VotingViewCommand = new RelayCommand(() => ExecuteVotingViewCommand());
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private RelayCommand logIn;
        public ICommand LogViewCommand { get {
                if (logIn == null)
                {
                    logIn= new RelayCommand(() => ExecuteLogViewCommand());

                }
                return logIn;
            } }
        private bool canLogView()
        {
            return !IsAuthenticated;
        }
        private void ExecuteLogViewCommand()
        {

            if (_logViewModel == null)
            {
                _logViewModel = new LogViewModel(this);
            }
            if (IsAuthenticated == true)
            {
                CurrentViewModel = VotingVM;
            }
            else
            {
                CurrentViewModel = MainViewModel._logViewModel;
            }
        }
        private RelayCommand logOutCommand;
        public ICommand LogOutCommand
        {
            get
            {
                if (logOutCommand == null)
                {
                    logOutCommand = new RelayCommand(() => ExecuteLogOutCommand());
                }
                return logOutCommand;
            }

        }
        private bool canLogOut()
        {
            return IsAuthenticated;
        }
        private void ExecuteLogOutCommand()
        {
            if (IsAuthenticated)
            {
                _logViewModel = new LogViewModel(this, false);
                CurrentViewModel = MainViewModel._logViewModel;
            }
        }

    }
}